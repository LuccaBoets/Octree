using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Octree
{
    class Branch
    {

        public List<float[]> allPixelsInBoxHSV { get; set; } = new List<float[]>();
        public Range range { get; set; }
        public List<Branch> children { get; set; } = new List<Branch>();
        public int generation { get; set; }

        public Branch(List<float[]> allPixelsInBoxHSV, Range range, int generation)
        {
            this.allPixelsInBoxHSV = allPixelsInBoxHSV;
            this.range = range;
            this.generation = generation;
        }

        public Branch(Range range, int generation)
        {
            this.allPixelsInBoxHSV = new List<float[]>();
            this.range = range;
            this.generation = generation;
        }

        public void generate()
        {
            if (checkCondition())
            {
                Console.WriteLine(generation);
                List<Range> ranges = range.subdivide();
                foreach (var range in ranges)
                {
                    children.Add(new Branch(range, generation+1));
                }

                int count = 0;
                foreach (var colorHSV in allPixelsInBoxHSV)
                {
                    //Console.WriteLine($"{count}/{allPixelsInBoxHSV.Count} {colorHSV[0]}");
                    count++;
                    foreach (var branch in children)
                    {

                        if (branch.range.inRange(colorHSV))
                        {
                            branch.addPixelsInBoxHSV(colorHSV);
                            break;
                        }
                    }
                }

                foreach (var branch in children)
                {
                    branch.generate();
                }
            }
        }

        public void addPixelsInBoxHSV(float[] colorHSV)
        {
            this.allPixelsInBoxHSV.Add(colorHSV);
        }

        public bool checkCondition() // condition holds
        {
            if (Control.MaxGenerations >= generation)
            {
                return true;
            }

            return false;
        }

        public void show()
        {
            Console.WriteLine($"{generation} {allPixelsInBoxHSV.Count}");

            foreach (var branch in children)
            {
                branch.show();
            }
        }

        public List<Color> getColors()
        {
            List<Color> colors = new List<Color>();
            foreach (var branch in children)
            {
                colors = colors.Concat(branch.getColors()).ToList();
            }

            if (allPixelsInBoxHSV.Count == 0)
            {
                return new List<Color>();
            }

            if (children.Count == 0)
            {
                colors.Add(generateMixedColor());
            }

            return colors;
        }

        public Color generateMixedColor()
        {
            var red = 0;
            var green = 0;
            var blue = 0;
            foreach (var colorHVS in allPixelsInBoxHSV)
            {
                //var color = ColorFromHSV(colorHVS[0], colorHVS[1] / 100, colorHVS[2] / 100);
                Color color = Color.FromArgb((int)colorHVS[0], (int)colorHVS[1], (int)colorHVS[2]);
                red += color.R;
                green += color.G;
                blue += color.B;
            }

            return Color.FromArgb(1, red / allPixelsInBoxHSV.Count, green / allPixelsInBoxHSV.Count, blue / allPixelsInBoxHSV.Count);
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        public List<Branch> getAllBranches()
        {
            List<Branch> branches = new List<Branch>();

            branches.Add(this);

            foreach (var branch in children)
            {
                branches = branches.Concat(branch.getAllBranches()).ToList();
            }

            return branches;
        }

        public bool checkIfChild(Branch branch)
        {
            if (branch.allPixelsInBoxHSV.Count > allPixelsInBoxHSV.Count || branch.generation <= generation)
            {
                return false;
            }

            foreach (var child in children)
            {
                if (child.Equals(branch))
                {
                    return true;
                }
            }

            foreach (var child in children)
            {
                if (child.checkIfChild(branch))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
