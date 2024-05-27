using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzuriha.Console;
public class Matcher
{
    private readonly Point _origin;
    private readonly Rect _rect;

    public Matcher()
    {
        _origin = new(660, 240);
        _rect = new(_origin, new Size(1200, 600));
    }

    public (double MinVal, Point CameraMove) Match(Mat previous, Mat current)
    {
        using Mat searchArea = current.SubMat(_rect);
        using Mat smallerSearchArea = searchArea.Resize(new Size(300, 150));
        using Mat smaller = previous.Resize(new Size(480, 270));
        using Mat errors = smaller.MatchTemplate(smallerSearchArea, TemplateMatchModes.SqDiffNormed);
        errors.MinMaxLoc(out double minVal, out _, out Point minLoc, out _);
        return (minVal, minLoc * 4 - _origin);
    }
}
