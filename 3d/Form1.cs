using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _3d
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Draw(int w, int h, Graphics g, Pen pen)
        {
            g.Clear(Color.White);

            int iterations = (int)numericUpDown1.Value;
            int size = 2;

            Point[] points =
            {
                new Point(w/2, h/2),
                new Point(w/2, h/2 + size)
            };

            for (int i = 0; i < iterations; i++)
            {
                g.DrawLines(pen, points = Dragon(i, points));
            }
            
        }

        private Point[] Dragon(int iter, Point[] points)
        {
            List<Point> pt = new List<Point>();
            double radian = (90 / 180d) * Math.PI;

            int dx = points[points.Length - 1].X, 
                dy = points[points.Length - 1].Y;
                        
            for (int i = 0; i < points.Length; i++)
            {
                pt.Add(points[i]);
            }

            for (int i = points.Length-1; i > 0; i--)
            {
                pt.Add(new Point((int)(dx + Math.Cos(radian) * (points[i-1].X - dx) - Math.Sin(radian) * (points[i-1].Y - dy)),
                                (int)(dy + Math.Sin(radian) * (points[i-1].X - dx) + Math.Cos(radian) * (points[i-1].Y - dy))));
            }

            Point[] newPoints = new Point[pt.Count];

            for (int i = 0; i < pt.Count; i++)
                newPoints[i] = pt[i];

            return newPoints;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 1);
            Graphics g = pictureBox1.CreateGraphics();
            
            Draw(pictureBox1.Width, pictureBox1.Height, g, myPen);
        }
    }
}