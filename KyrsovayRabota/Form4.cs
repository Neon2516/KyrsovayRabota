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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buttons.vopros13(comboBox1, this, new Form17());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Test1.arr_ques[12, 0] = 13;
            Test1.arr_ques[12, 1] = 0;
            Form newForm = new Form17();
            newForm.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
