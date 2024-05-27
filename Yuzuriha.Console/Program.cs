using OpenCvSharp;
using Yuzuriha.Console;

if (args.Length == 0) return;
string videoPath = args[0];
string videoName = Path.GetFileNameWithoutExtension(videoPath);
Console.WriteLine($"Stiching {videoName}");
if (Directory.Exists(videoName)) Directory.Delete(videoName, true);
Directory.CreateDirectory(videoName);

int i = 0;
using Frames frames = new(videoPath, int.MaxValue);
Matcher matcher = new();
Point totalCameraMove = new();
Stich stich = new(frames.Previous);
var matched = frames.Read().AsParallel().AsOrdered()
    .WithMergeOptions(ParallelMergeOptions.NotBuffered)
    .Select(framePair => (framePair, matcher.Match(framePair.Previous, framePair.Current)))
    .AsSequential();
foreach((var fp, var m) in matched)
{
    Console.WriteLine(i++);
    Console.WriteLine($"{m.MinVal} {m.CameraMove}");
    if(m.MinVal < 0.02)
    {
        totalCameraMove += m.CameraMove;
        stich.Add(fp.Current, totalCameraMove);
        fp.Current.Dispose();
        fp.Previous.Dispose();
        continue;
    }
    if (!stich.Single)
    {
        using Mat stiched = stich.Compose();
        if(stiched.Width > 1929 || stiched.Height > 1089)
        {
            var filename = Path.Combine(videoName, $"{i}.jpg");
            stiched.ImWrite(filename);
        }
    }
    stich.Dispose();
    totalCameraMove = new();
    stich = new(fp.Current);
    fp.Current.Dispose();
    fp.Previous.Dispose();
}