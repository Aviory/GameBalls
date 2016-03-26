using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balls
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            Timer tm = new Timer();
            tm.Interval = 20;
            tm.Tick += new EventHandler(OnTimerEvent);
            tm.Start();
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            foreach (ball p in pictureBox1.Controls)
            {
                p.move();
            }
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBox1.Controls.Add(new ball(e.Location));
            }
        }

        private void mouseUP(object sender, MouseEventArgs e){}
        private void onMouse(object sender, EventArgs e){}
    }
}
