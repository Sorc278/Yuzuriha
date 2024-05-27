using OpenCvSharp;
using OpenCvSharp.Features2D;
using OpenCvSharp.Flann;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzuriha.Console;
/*public class FlannMatcher
{
    public (double MinVal, Point CameraMove) Match(Mat previous, Mat current)
    {
        SIFT sift = SIFT.Create(); // update ctor
        Mat desc1 = new(), desc2 = new();
        sift.DetectAndCompute(previous, null, out KeyPoint[] kp1, desc1);
        sift.DetectAndCompute(previous, null, out KeyPoint[] kp2, desc2);

        IndexParams indexParams = new();
        indexParams.SetAlgorithm(1);
        indexParams.SetInt("trees", 5);
        SearchParams searchParams = new();
        searchParams.SetInt("checks", 50);
        FlannBasedMatcher matcher = new FlannBasedMatcher(indexParams, searchParams);
        DMatch[][] matches = matcher.KnnMatch(desc1, desc2, 2);
        return (minVal, minLoc - _origin);
    }
}
*/