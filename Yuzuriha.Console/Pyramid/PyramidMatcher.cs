using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzuriha.Console.Pyramid;
public class PyramidMatcher
{
    public void Match(Pyramid previous, Pyramid current)
    {
        for (int level = previous.Levels.Count - 1; level >= 0; level--)
        {

        }
    }

    public void Match(Mat previous, Mat current)
    {
        int slideX = (int)(previous.Width * 0.5);
        int slideY = (int)(previous.Height * 0.5);
        Size size = new(previous.Width - slideX, previous.Height - slideY);
        Rect previousRect = new(new Point(0, 0), size);
        Rect currentRect = new(new Point(previous.Width + slideX, previous.Height + slideY), size);
        for (int x = -slideX; x < slideX; x++)
        {
            for (int y = -slideY; y < slideY; y++)
            {
                using Mat previousCrop = previous.SubMat(previousRect);
                using Mat currentCrop = current.SubMat(currentRect);
                Scalar mean = Cv2.Mean((previousCrop - currentCrop).Abs());
                System.Console.WriteLine(mean);
                if(y < 0) previousRect.Inflate(0, 1);
                else
                {
                    previousRect.Inflate(0, -1);
                    previousRect.Add(new Point(0, 1));
                }
            }
        }
    }
}
