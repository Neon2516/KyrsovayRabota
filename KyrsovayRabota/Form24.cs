﻿using System;
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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buttons.vopros18(numericUpDown1, this, new Form23());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test1.arr_ques[17, 0] = 18;
            Test1.arr_ques[17, 1] = 0;
            Form newForm = new Form23();
            newForm.Show();
            this.Hide();
        }
    }
}
