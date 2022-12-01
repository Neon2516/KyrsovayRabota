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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Buttons.vopros12(radioButton1, radioButton2, radioButton3, this, new Form4());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[11, 0] = 12;
            Test1.arr_ques[11, 1] = 0;
            Form newForm = new Form4();
            newForm.Show();
            this.Hide();
        }
    }
}
