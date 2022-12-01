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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test1.arr_ques[14, 0] = 15;
            if (checkedListBox1.CheckedItems.Count == 0)
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (((string)checkedListBox1.CheckedItems[0] == "Все этапы работы должны быть зафиксированы") &&
                     ((string)checkedListBox1.CheckedItems[1] == "Каждый этап последователен") &&
                     ((string)checkedListBox1.CheckedItems[2] == "Пропуск этапов плана запрещен") &&
                     ((string)checkedListBox1.CheckedItems[3] == "Откат на прошлый этап невозможен, ничего менять нельзя"))
            {   
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[14, 1] = 1;
                Form newForm = new Form19();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[14, 1] = 0;
                Form newForm = new Form19();
                newForm.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[14, 0] = 15;
            Test1.arr_ques[14, 1] = 0;
            Form newForm = new Form19();
            newForm.Show();
            this.Hide();
        }
    }
}
