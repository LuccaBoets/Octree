using System;
using System.Drawing;

namespace Octree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Image image = Image.FromFile("..\\..\\..\\..\\testR.jpg");
            //Image image = Image.FromFile("..\\..\\..\\..\\testG.jpg");
            //Image image = Image.FromFile("..\\..\\..\\..\\testB.png");
            Image image = Image.FromFile("..\\..\\..\\..\\testYB.jpg");
            //Image image = Image.FromFile("..\\..\\..\\..\\testBR.jpg");

            //Image image = Image.FromFile("..\\..\\..\\..\\testIssam.png");
            //Image image = Image.FromFile("..\\..\\..\\..\\testIssam2.png");
            //Image image = Image.FromFile("..\\..\\..\\..\\testIssam3.png");

            //Image image = Image.FromFile("..\\..\\..\\..\\testOne.png");

            var colors = Control.run(image);

            Console.WriteLine(colors.Count);
            foreach (var color in colors)
            {
                Console.WriteLine($"<div style='background-color: rgb({color.R},{color.G},{color.B})'></div>");
            }
        }
    }
}
