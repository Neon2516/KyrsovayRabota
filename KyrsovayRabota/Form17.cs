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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test1.arr_ques[13, 0] = 14;
            if (comboBox1.Text == "")
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if ((comboBox1.Text == "Безопасность"))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[13, 1] = 1;
                Form newForm = new Form18();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[13, 1] = 0;
                Form newForm = new Form18();
                newForm.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[13, 0] = 14;
            Test1.arr_ques[13, 1] = 0;
            Form newForm = new Form18();
            newForm.Show();
            this.Hide();
        }
    }
}
