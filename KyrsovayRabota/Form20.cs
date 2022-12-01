using KyrsovayDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KyrsovayRabota
{
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            Test1.vivodDvymern(dataGridView1, Test1.arr_ques);
            for (int i = 0; i < Test1.arr_ques.GetLength(0); i++)
            {
                if (Test1.arr_ques[i, 1] == 1) count++;
            }
            label2.Text = ("Количество правильных ответов: " + Convert.ToString(count));
            MessageBox.Show("Запись результатов ответов тестовой программы с выводом в DGV успешно выполнена!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button6.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            label1.Text = ("Правильные ответы составляют " + Convert.ToString( (int) ((Test1.KOL / 18.0) * 100) ) + "%");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart1.Series["Правильные"].Points.AddY(Test1.KOL);
            chart1.Series["Неправильные"].Points.AddY(16 - Test1.KOL);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataBase.add();
            DataBase.add_struct();
            DataBase.add_zap(Test1.arr_ques);
            открытьAccessФайлToolStripMenuItem.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("")) {
                int k = Class1.vvod(textBox1);
                Class1.deleteStroky(k - 1, ref Test1.arr_ques);
                Test1.vivodDvymern(dataGridView1, Test1.arr_ques);
            }
            else
            {
                MessageBox.Show("Вы не вписали значение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Class1.SortMas();
            Test1.vivodOdnomern(dataGridView2, Test1.arr_ques);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Class1.ZapisExcel();
            открытьToolStripMenuItem.Enabled = true;
            открытьФотографиюДиаграммыToolStripMenuItem1.Enabled = true;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.xlsm;*.xlsx";
            otkr.Filter = "Microsoft Excel (*xlsm*)|*.xls*";
            otkr.Title = "Выберите документ Excel";
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            System.Diagnostics.Process.Start(otkr.FileName);
        }

        private void открытьФотографиюДиаграммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.pdf";
            otkr.Filter = "Pdf Files|*.pdf";
            var path = Directory.GetCurrentDirectory();
            Clipboard.SetText(path);
            MessageBox.Show("Ссылка на путь файла скопирована в буфер обмена", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            otkr.Title = "Выберите документ PDF, который находится по пути: " + path;
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Class1.ZapisPDF();
            открытьФотографиюДиаграммыToolStripMenuItem.Enabled = true;
        }

        private void открытьФотографиюДиаграммыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.jpg";
            otkr.Filter = "Image Files|*.jpg";
            var path = Directory.GetCurrentDirectory();
            Clipboard.SetText(path);
            MessageBox.Show("Ссылка на путь файла скопирована в буфер обмена", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            otkr.Title = "Выберите фотографию, который находится по пути: " + path;
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }

        private void открытьAccessФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog otkr = new OpenFileDialog();
            otkr.DefaultExt = "*.jpg";
            otkr.Filter = "Microsoft Access |*.accdb";
            var path = Directory.GetCurrentDirectory();
            Clipboard.SetText(path);
            MessageBox.Show("Ссылка на путь файла скопирована в буфер обмена", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            otkr.Title = "Выберите Access файл, который находится по пути: " + path;
            if (otkr.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл", "Открыть", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Diagnostics.Process.Start(otkr.FileName);
        }
    }
}

