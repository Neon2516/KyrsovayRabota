using KyrsovayDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsovayRabota
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buttons.vopros3(hScrollBar1, this, new Form8());
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            button1.Enabled = true;
            label2.Text = ("Ваш ответ: " + Convert.ToString(hScrollBar1.Value));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test1.arr_ques[2, 0] = 3;
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[2, 1] = 0;
            Form newForm = new Form8();
            newForm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
