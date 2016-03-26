using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balls
{
    public class ball: PictureBox
    {
        int dx = 0;
        int dy = 0;
        int filX = 30;
        int filY = 30;
        static Random rnd = new Random();
        Color color;

        public ball(Point p)
        {
            this.Location = p;
            this.Width = 30;
            this.Height = 30;
            color = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            dx = (rnd.Next(10) - 5);
            dy = (rnd.Next(10) - 5);
        }
        public ball(Point p, int x)
        {

            this.Location = p;
            this.Width = 12;
            this.Height = 12;
            color = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            dx = (rnd.Next(10) - 5);
            dy = (rnd.Next(10) - 5);
            filX = 12;
            filY = 12;
            
        }
        
        public void move()
        {

            Point p=Location;
            if (p.X < 0 || p.X + 30 > Parent.Width)
                dx = -dx;
            if (p.Y < 0 || p.Y + 30 > Parent.Height)
                dy = -dy;
            collizion(p); 
            p.Offset(dx, dy);
            Location = p;
        }
        private void collizion(Point p)
        {
            Rectangle rect = DisplayRectangle;
            rect.Location = Location;
            for (int i=0;i<Parent.Controls.Count;i++)
            {
                Rectangle rectne = Parent.Controls[i].DisplayRectangle;
                rectne.Location = Parent.Controls[i].Location;
                if (rect.IntersectsWith(rectne)&&rectne!=rect)
                {
                    dx = -dx;
                    dy = -dy;
                    p.Offset(dx,dy);
                }

            }
                
                
                //if(nextRect.IntersectsWith(fomrrect) && nextRect != fomrrect && nextRect.Width == fomrrect.Width)
            
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe);
            SolidBrush sb = new SolidBrush(color);
            pe.Graphics.FillEllipse(sb, 0, 0, filX, filY);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point p = Location;
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 1; i < 8; i++)
                {
                    Parent.Controls.Add(new ball(p, 1));
                    for (int j = 0; j < 100; j++)
                    {

                    }
                }
                Parent.Controls.Remove(this);
            }
        }
    }
}
//if (this.Location.X+3== ball.Location.X+filX-3 && this.Location.Y-3 == ball.Location.Y - filY + 3 ||
//    ball.Location.X + 3 == this.Location.X + filX - 3 && ball.Location.Y - 3 == this.Location.Y - filY + 3||
//    ball.Location.X + 3 == this.Location.X + filX - 3 && ball.Location.Y - filY+3 == this.Location.Y - 3||
//    this.Location.X + 3 == ball.Location.X + filX - 3 && this.Location.Y - filY + 3 == ball.Location.Y - 3)
//{
//    this.dx = -dx;
//    this.dy = -dy;
//    ball.dx = -dx;
//    ball.dy = -dy;
//}