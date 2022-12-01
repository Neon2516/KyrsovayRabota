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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Test1.arr_ques[9, 0] = 10;
            if ((listBox2.Text == "") || (listBox3.Text == ""))
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if ((listBox2.Items[0] == "Целостность данных / процессов") && (listBox3.Items[0] == "Масштабируемость"))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[9, 1] = 1;
                Form newForm = new Form15();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[9, 1] = 0;
                Form newForm = new Form15();

                newForm.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[9, 0] = 10;
            Test1.arr_ques[9, 1] = 0;
            Form newForm = new Form15();
            newForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                listBox2.Items.Add(listBox1.Text);
                listBox2.Text = Convert.ToString(listBox1.SelectedIndex == 0);
                listBox1.Items.RemoveAt(0);
            }
            if (listBox1.SelectedIndex == 1)
            {
                listBox2.Items.Add(listBox1.Text);
                listBox2.Text = Convert.ToString(listBox1.SelectedIndex == 1);
                listBox1.Items.RemoveAt(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                listBox3.Items.Add(listBox1.Text);
                listBox3.Text = Convert.ToString(listBox1.SelectedIndex == 0);
                listBox1.Items.RemoveAt(0);
            }
            if (listBox1.SelectedIndex == 1)
            {
                listBox3.Items.Add(listBox1.Text);
                listBox3.Text = Convert.ToString(listBox1.SelectedIndex == 1);
                listBox1.Items.RemoveAt(1);
            }
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            string[] a = new string[2];
            a[0] = "Целостность данных / процессов";
            a[1] = "Масштабируемость";
            for (int j = 0; j <= 1; j++)
                listBox1.Items.Add(a[j]);
        }
    }
}
