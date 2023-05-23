using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace midterm
{
    public partial class Form1 : Form
    {

        Random r = new Random();
        int q;
        int disx;
        int disy;
        public Form1()
        {
            InitializeComponent();
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            
            PictureBox a = new PictureBox();
            this.Controls.Add(a);
            a.Name = "a";
            a.Size = new Size(20, 20);
            a.BackColor = Color.FromArgb(r.Next(100, 255), r.Next(100, 255), r.Next(100, 255));
            cir(a);
            a.Left = r.Next(0, 1000);
            a.Top = r.Next(0, 1000);
            if (timer1.Interval >10)
            timer1.Interval -= 10;
            q++;
            label1.Text = q.ToString();
        }
        void cir(PictureBox pic)
        {
            GraphicsPath g = new GraphicsPath();
            g.AddEllipse(pic.ClientRectangle);
            Region region = new Region(g);
            pic.Region = region;
            g.Dispose();
            region.Dispose();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            point.Size = new Size(30, 30);
            point.BackColor = Color.Black;
            this.ClientSize = new Size(1000, 1000);
            cir(point);
            point.Left = 500;
            point.Top = 500;
            timer2.Interval = 1000;
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            point.Left += (-point.Left - 15 + Cursor.Position.X) / 20;
            point.Top += (-point.Top - 15 + Cursor.Position.Y) / 20;
            foreach (Control picbox in this.Controls)
            {
                {
                    if (picbox.Name == "a")
                    {
                        picbox.Left += (point.Left + 5 - picbox.Left) / 12;
                        picbox.Top += (point.Top + 5 - picbox.Top) / 12;
                        disx = point.Left + 5 - picbox.Left;
                        disy = point.Top + 5 - picbox.Top;
                        if (disx < 0) disx = -disx;
                        if (disy < 0) disy = -disy;
                        if (disx * disx + disy * disy < 625) {
                            timer1.Enabled = false;
                            timer2.Enabled = false;
                            MessageBox.Show("dead");
                            restart();
                        }
                    }
                }
            }
        }
        void restart()
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            point.Left = 500;
            point.Top = 500;
            List<Control> del = new List<Control>();
            foreach (Control d in this.Controls)
            {
                if (d.Name == "a")
                {
                    del.Add(d as PictureBox); 
                }
            }
            foreach (Control d in del)
            {
                this.Controls.Remove(d);
            }
            timer2.Interval = 1000;
            q = 0;
        }
    }
}
