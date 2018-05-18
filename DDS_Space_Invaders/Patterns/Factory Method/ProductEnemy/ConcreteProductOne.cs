using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders.Factory
{
    class ConcreteProductOne : Product
    {
        // Rectangle bonus 

        public Graphics Draw(Graphics gr, Rectangle formArea, Random random)
        {
            Graphics graphics = gr;
            //gr.DrawEllipse(Pens.Green, 10, 10, 100, 100);

            Pen pen = new Pen(Color.Gold, 2);
            SolidBrush brush = new SolidBrush(Color.Gold);

            //gr.DrawEllipse(pen, 10, 10, 100, 20);
            gr.FillEllipse(brush, 10, 10, 10, 10);
            

            return graphics;
        }
    }
}
