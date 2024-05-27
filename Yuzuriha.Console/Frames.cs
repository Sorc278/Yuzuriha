using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzuriha.Console;

public class Frames : IDisposable
{
    private readonly VideoCapture _video;
    private int _count, _max;

    public Frames(string videoPath, int max)
    {
        _video = new(videoPath);
        _video.Read(Previous);
        _max = max;
    }

    public Mat Previous { get; private set; } = new();
    public Mat Current { get; private set; } = new();

    public IEnumerable<(Mat Previous, Mat Current)> Read()
    {
        while (_video.Read(Current))
        {
            if (_count > _max) yield break;
            _count++;
            yield return (Previous.Clone(), Current.Clone());
            (Previous, Current) = (Current, Previous);
        }
    }

    public void Dispose()
    {
        _video.Dispose();
    }
}
