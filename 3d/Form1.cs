using System;
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

            int iterations = (int)numericUpDown1.Value;
            int size = 400;


            PointF[] points =
            {
                new PointF(w/2, h/3),
                new PointF(w/2, h/3 + size)
            };

            Dragon(iterations, points, g, pen);

        }
    
        private void Dragon(int iter, PointF[] points, Graphics g, Pen pen) { 
        
            float dx, dy;

            if (iter == 0)
                g.DrawLine(pen, points[0], points[1]);
            else
            {
                dx = (points[1].X + points[0].X) / 2 + (points[1].Y - points[0].Y) / 2;
                dy = (points[1].Y + points[0].Y) / 2 - (points[1].X - points[0].X) / 2;
                PointF[] point1 =
                {
                    new PointF(points[0].X, points[0].Y),
                    new PointF(dx, dy)
                };
                PointF[] point2 =
                {
                    new PointF(points[1].X, points[1].Y),
                    new PointF(dx, dy)
                };
                Dragon(iter-1, point1, g, pen);
                Dragon(iter-1, point2, g, pen);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen Pen1 = new Pen(Color.White, 1);
            Pen Pen2 = new Pen(Color.Blue, 1);
            Pen Pen3 = new Pen(Color.BlueViolet, 1);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.Black);

            Draw(pictureBox1.Width, pictureBox1.Height, g, Pen1);
            Draw(pictureBox1.Width-400, pictureBox1.Height, g, Pen2);
            Draw(pictureBox1.Width+400, pictureBox1.Height, g, Pen3);
        }
    }
}