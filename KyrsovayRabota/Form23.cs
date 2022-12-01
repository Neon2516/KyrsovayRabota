using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsovayRabota
{
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Paint(object sender, PaintEventArgs e)
        {
            string str = "";
            Font fnt = new Font("Canvas", 10, FontStyle.Bold);
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            Graphics g = e.Graphics;
            Brush br = new LinearGradientBrush(new PointF(0, 0), new PointF(this.Width, this.Height), Color.Red, Color.MediumBlue);
            float sw = g.MeasureString(str, fnt).Width;
            float sh = g.MeasureString(str, fnt).Height;
            g.Clear(Color.NavajoWhite);
            Brush br1 = new SolidBrush(Color.LemonChiffon);
            g.FillEllipse(br1, 40, 40, w - 55, h - 55);
            g.DrawString(str, fnt, br, (w - sw) / 2, (h - sh) / 2);
            Pen pn = new Pen(Color.Aquamarine, 30);
            g.DrawEllipse(pn, 30, 30, w - 55, h - 55);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int k = 0;
            string[] str = {".", "..", "..."};
            progressBar1.Maximum = 10000;
            progressBar1.Value = 0;
            for (int i = 0; i < progressBar1.Maximum; i++)
            {
                progressBar1.Increment(1);
                label1.Text = (progressBar1.Value / 100).ToString() + "%";
                label1.Refresh();
                if (i % 1000 == 0)
                {
                    label2.Text = "Загрузка ответов тестирования" + str[k];
                    k++;
                    if (k == 3) k = 0;
                    label2.Refresh();
                }
            }
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Enabled = false;
                Form f20 = new Form20();
                f20.Show();
                this.Hide();
                
            }
        }

        private void Form23_Load(object sender, EventArgs e)
        {

        }
    }
}
