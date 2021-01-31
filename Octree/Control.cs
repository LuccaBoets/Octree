using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Octree
{
    public class Control
    {
        public static int MaxGenerations { get; set; } = 4;
        public static int MaxColors { get; set; } = 8;
        public static List<Color> run(Image image)
        {
            var allPixelColors = new List<float[]>();

            Bitmap picture = new Bitmap(image);
            float maxHeu = 0;
            float minHeu = 100;
            for (int i = 0; i < picture.Width; i++)
            {
                for (int j = 0; j < picture.Height; j++)
                {
                    var color = picture.GetPixel(i, j);

                    allPixelColors.Add(getValue(color));
                }
            }
            Console.WriteLine(maxHeu);
            //Branch branch = new Branch(allPixelColors, new Range(0, 0, 0, 360, 100, 100), 1);
            Branch branch = new Branch(allPixelColors, new Range(0, 0, 0, 255, 255, 255), 1);
            branch.generate();
            branch.show();

            Console.WriteLine("Count");
            var temp1 = getColors(branch);

            List<Color> colors = new List<Color>();
            foreach (var temp2 in temp1)
            {
                if (temp2.allPixelsInBoxHSV.Count != 0)
                {
                    colors.Add(temp2.generateMixedColor());
                }
            }

            return colors;
            //return branch.getColors();
        }

        private static float[] getValue(Color color)
        {
            float r = (float)color.R / 255.0f;
            float g = (float)color.G / 255.0f;
            float b = (float)color.B / 255.0f;

            //float max, min;

            //max = r; min = r;

            //if (g > max) max = g;
            //if (b > max) max = b;

            //if (g < min) min = g;
            //if (b < min) min = b;

            //var brightness = (max + min) / 2;

            //float[] temp = { color.GetHue(), color.GetSaturation() * 100, ((float)(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B)) };
            float[] temp = { color.R, color.G, color.B};
            return temp;
        }

        private static List<Branch> getColors(Branch branch)
        {
            var branches = branch.getAllBranches().OrderByDescending(o => o.allPixelsInBoxHSV.Count).ToList();
            var topBranches = branches.Take(MaxColors).ToList();
            branches.RemoveRange(0, MaxColors);
            return checkTopColors(branches, topBranches);
        }

        private static List<Branch> checkTopColors(List<Branch> branches, List<Branch> topBranches)
        {
            bool wrong = false;
            Branch wrongBranch = null;
            foreach (var branchItem in topBranches)
            {
                Console.WriteLine($"{branchItem.allPixelsInBoxHSV.Count} {branchItem.generation}");

                foreach (var branchItem2 in topBranches)
                {
                    if (branchItem.checkIfChild(branchItem2))
                    {
                        wrongBranch = branchItem;
                        wrong = true;
                        break;
                    }
                }

                if (wrong)
                {
                    break;
                }
            }

            if (wrong)
            {
                topBranches.Remove(wrongBranch);
                topBranches.Add(branches.First());
                branches.RemoveAt(0);
                checkTopColors(branches, topBranches);
            }

            return topBranches;
        }

        public static List<Color> run(Bitmap picture)
        {
            var allPixelColors = new List<float[]>();

            float maxHeu = 0;
            float minHeu = 100;
            for (int i = 0; i < picture.Width; i++)
            {
                for (int j = 0; j < picture.Height; j++)
                {
                    var color = picture.GetPixel(i, j);


                    float r = (float)color.R / 255.0f;
                    float g = (float)color.G / 255.0f;
                    float b = (float)color.B / 255.0f;

                    float max, min;

                    max = r; min = r;

                    if (g > max) max = g;
                    if (b > max) max = b;

                    if (g < min) min = g;
                    if (b < min) min = b;

                    var brightness = (max + min) / 2;



                    float[] temp = { color.GetHue(), color.GetSaturation() * 100, ((float)(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B)) };
                    allPixelColors.Add(temp);
                    if (minHeu > color.GetBrightness())
                    {
                        minHeu = color.GetBrightness();
                    }

                    if (maxHeu < color.GetBrightness())
                    {
                        maxHeu = color.GetBrightness();
                    }
                }
            }
            Console.WriteLine(maxHeu);
            Branch branch = new Branch(allPixelColors, new Range(0, 0, 0, 360, 100, 100), 1);
            branch.generate();
            branch.show();

            return branch.getColors();
        }
    }
}
