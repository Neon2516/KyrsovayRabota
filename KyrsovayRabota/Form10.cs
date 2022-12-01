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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buttons.vopros6(checkBox1, checkBox2, checkBox3, this, new Form11());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[5, 0] = 6;
            Test1.arr_ques[5, 1] = 0;
            Form newForm = new Form11();
            newForm.Show();
            this.Hide();
        }
    }
}
