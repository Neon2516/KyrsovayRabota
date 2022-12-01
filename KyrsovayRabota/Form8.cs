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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test1.arr_ques[3, 0] = 4;
            if (hScrollBar1.Value == 8)
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[3, 1] = 1;
                Form newForm = new Form9();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[3, 1] = 0;
                Form newForm = new Form9();
                newForm.Show();
                this.Hide();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            button1.Enabled = true;
            label2.Text = ("Ваш ответ: " + Convert.ToString(hScrollBar1.Value));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[3, 0] = 4;
            Test1.arr_ques[3, 1] = 0;
            Form newForm = new Form9();
            newForm.Show();
            this.Hide();
        }
    }
}
