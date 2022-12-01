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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Test1.arr_ques[10, 0] = 11;
            if ((radioButton1.Checked == false) && (radioButton2.Checked == false) && (radioButton3.Checked == false))
            {
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((radioButton3.Checked == false) && (radioButton1.Checked == true) && (radioButton2.Checked == false))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[10, 1] = 1;
                Form newForm = new Form16();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[10, 1] = 0;
                Form newForm = new Form16();

                newForm.Show();
                this.Hide();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[10, 0] = 11;
            Test1.arr_ques[10, 1] = 0;
            Form newForm = new Form16();
            newForm.Show();
            this.Hide();

        }
    }
}
