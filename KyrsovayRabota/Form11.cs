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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buttons.vopros7(trackBar1, this, new Form12());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[6, 0] = 7;
            Test1.arr_ques[6, 1] = 0;
            Form newForm = new Form12();
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
