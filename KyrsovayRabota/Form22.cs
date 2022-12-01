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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form newForm = new Form21();
            newForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Вы ввели не все данные! Заполните пустые поля.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Class1.Register(textBox1, textBox2);
            Form newForm = new Form21();
            newForm.Show();
            this.Hide();
        }
    }
}
