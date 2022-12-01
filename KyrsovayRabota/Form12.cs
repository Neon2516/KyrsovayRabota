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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test1.arr_ques[7, 0] = 8;
            if (trackBar1.Value == 2)
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[7, 1] = 1;
                Form newForm = new Form13();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[7, 1] = 0;
                Form newForm = new Form13();
                newForm.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[7, 0] = 8;
            Test1.arr_ques[7, 1] = 0;
            Form newForm = new Form13();
            newForm.Show();
            this.Hide();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label7.Text = ("Ваш ответ: " + Convert.ToString(trackBar1.Value));
        }
    }
}
