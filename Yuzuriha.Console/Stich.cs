using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzuriha.Console;
public class Stich : IDisposable
{
    private readonly List<(Point Position, Mat Frame)> _frames = [];

    public Stich(Mat frame)
    {
        Add(frame, new());
    }

    public bool Single => _frames.Count == 1;

    public void Add(Mat frame, Point pos) => _frames.Add((pos, frame.Clone()));

    public Mat Compose()
    {
        List<Point> positions = _frames.Select(f => f.Position).ToList();
        int xAdjust = -positions.Min(p => p.X);
        int yAdjust = -positions.Min(p => p.Y);
        int maxX = positions.Max(p => p.X);
        int maxY = positions.Max(p => p.Y);
        Mat stich = new(new Size(maxX + xAdjust + 1920, maxY + yAdjust + 1080), _frames[0].Frame.Type());
        foreach ((Point p, Mat f) in _frames)
        {
            using Mat target = stich.SubMat(p.Y + yAdjust, p.Y + yAdjust + 1080, p.X + xAdjust, p.X + xAdjust + 1920);
            f.CopyTo(target);
            // use mean of overlapping frames for each pixel
        }
        return stich;
    }

    public void Dispose()
    {
        foreach((var _, Mat frame) in _frames) frame.Dispose();
    }
}
