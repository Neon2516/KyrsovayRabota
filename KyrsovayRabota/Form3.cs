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
using KyrsovayDLL;

namespace KyrsovayRabota
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Buttons.vopros1(textBox1, this, new Form7());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[0, 0] = 1;
            Test1.arr_ques[0, 1] = 0;
            Form newForm = new Form7();
            newForm.Show();
            this.Hide();

        }
    }
}
