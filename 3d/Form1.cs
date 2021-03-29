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
            int size = 400;

            Point[] points =
                {
                    new Point(w/2, h/2),
                    new Point(w/2, h/2 + size)
                };

            Dragon(points[0], points[1], iterations, g, pen);
            
        }

        private void Dragon(Point p1, Point p2, int iter, Graphics g, Pen pen)
        {
            int xn, yn;
            if (iter > 0)
            {
                xn = (p1.X + p2.X) / 2 + (p2.Y - p1.Y) / 2;
                yn = (p1.Y + p2.Y) / 2 - (p2.X - p1.X) / 2;
                Dragon(new Point(p2.X, p2.Y), new Point(xn, yn), iter - 1, g, pen);
                Dragon(new Point(p1.X, p1.Y), new Point(xn, yn), iter - 1, g, pen);
            }
            g.DrawLine(pen, p1, p2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 1);
            Graphics g = pictureBox1.CreateGraphics();

            Draw(pictureBox1.Width, pictureBox1.Height, g, myPen);
        }
    }
}