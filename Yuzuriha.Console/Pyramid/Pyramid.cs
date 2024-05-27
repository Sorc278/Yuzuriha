using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzuriha.Console.Pyramid;
public class Pyramid
{
    private readonly List<Mat> _levels = [];
    public Pyramid(Mat frame)
    {
        while(frame.Width > 10)
        {
            _levels.Add(frame);
            frame = frame.Resize(new Size(frame.Width / 2, frame.Height / 2));
        }
    }

    public IReadOnlyList<Mat> Levels => _levels;
}
