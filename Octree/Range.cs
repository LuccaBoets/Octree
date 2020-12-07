using System;
using System.Collections.Generic;
using System.Text;

namespace Octree
{
    class Range
    {
        public float x1 { get; set; }
        public float y1 { get; set; }
        public float z1 { get; set; }
        public float x2 { get; set; }
        public float y2 { get; set; }
        public float z2 { get; set; }

        public Range(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.z1 = z1;
            this.x2 = x2;
            this.y2 = y2;
            this.z2 = z2;
        }

        public List<Range> subdivide()
        {
            List<Range> ranges = new List<Range>();
            float[] middle = { (x2 - x1) / 2, (y2 - y1) / 2, (z2 - z1) / 2 };

            ranges.Add(new Range(x1,y1,z1,middle[0],middle[1],middle[2]));          //000
            ranges.Add(new Range(x1, y1, middle[2], middle[0], middle[1], z2));     //001
            ranges.Add(new Range(x1, middle[1], z1, middle[0], y2, middle[2]));     //010
            ranges.Add(new Range(x1, middle[1], middle[2], middle[0], y2, z2));     //011
            ranges.Add(new Range(middle[0], y1,z1,x2,middle[1],middle[2]));         //100
            ranges.Add(new Range(middle[0], y1, middle[2], x2,middle[1],z2));       //101
            ranges.Add(new Range(middle[0], middle[1], z1, x2, y2, middle[2]));     //110
            ranges.Add(new Range(middle[0], middle[1], middle[2], x2, y2, z2));     //111

            return ranges;
        }

        public bool inRange(float[] colorHSV)
        {
            if (x1 <= colorHSV[0] && x2 >= colorHSV[0] && y1 <= colorHSV[1] && y2 >= colorHSV[1] && z1 <= colorHSV[2] && z2 >= colorHSV[2] )
            {
                return true;
            }
            return false;
        }
    }
}
