using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Application = System.Windows.Forms.Application;
using Axis = Microsoft.Office.Interop.Excel.Axis;

namespace KyrsovayDLL
{
    public class Test1
    {
        public static int KOL = 0;
        public static int[,] arr_ques = new int[18, 2];
        public static void vivodDvymern(DataGridView grid, int[,] mas)
        {
            grid.Rows.Clear();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                
                grid.Rows.Add(mas[i, 0], mas[i, 1]);
            }
        }

        public static void vivodOdnomern(DataGridView grid, int[,] mas)
        {
            grid.Rows.Clear();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                grid.Rows.Add(mas[i, 1], 1);
            }
        }
    }

    public class Class1
    {
        public static void ZapisPDF()
        {
            var Document = new Document();
            var Zap = PdfWriter.GetInstance(Document, new
            System.IO.FileStream("Massivs.pdf", System.IO.FileMode.Create));
            Document.Open();
            var Shrift = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\times.ttf", "CP1251", BaseFont.EMBEDDED);

            var ft = new Font(Shrift, 10, Font.NORMAL, BaseColor.BLUE);
            //var ft = new Font(Font.TIMES_ROMAN, 10, Font.NORMAL, Color.BLUE);
            var tabl = new PdfPTable(1);
            var cell = new PdfPCell();
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.Colspan = 2;
            cell.Border = 0;
            cell.FixedHeight = 16.0F;
            cell.Phrase = new Phrase("Результаты ответов", ft);
            tabl.AddCell(cell);
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.Colspan = 1;
            cell.Border = 15;
            for (int i = 0; i < Test1.arr_ques.GetLength(0); i++)
            {
                cell.Phrase = new Phrase(Test1.arr_ques[i, 1].ToString(), ft);
                tabl.AddCell(cell);
            }
            tabl.TotalWidth = Document.PageSize.Width - 400;
            tabl.WriteSelectedRows(0, -1, 40, Document.PageSize.Height - 30,
            Zap.DirectContent);
            Document.Close();
            Zap.Close();
            System.Diagnostics.Process.Start("IExplore.exe", System.IO.Directory.GetCurrentDirectory() + @"\Massivs.pdf");
        }
        public static void ZapisExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;
                var t = Type.Missing;
                var Book = excelApp.Workbooks.Add(t);
                var Lists = Book.Worksheets;
                Microsoft.Office.Interop.Excel.Worksheet List = Lists.Item[1];
                List.Cells[1, 1] = "Результаты тестирования";
                List.Range["B1", t].Value2 = "Ответ";
                for (int i = 0; i < Test1.arr_ques.GetLength(0); i++)
                {
                    List.Range["A" + (i + 2), t].Value2 = "Вопрос " + Test1.arr_ques[i, 0];
                    List.Range["B" + (i + 2), t].Value2 = Test1.arr_ques[i, 1];
                }
                List.Range["A18", t].Value2 = "Правильных ответов:";
                int count = 0;
                for (int i = 0; i < Test1.arr_ques.GetLength(0); i++)
                {
                    if (Test1.arr_ques[i, 1] == 1) count++;
                }
                List.Range["B18", t].Value2 = Convert.ToString(count);
                List.Range["A19", t].Value2 = "Неправильных ответов:";
                List.Range["B19", t].Value2 = Convert.ToString(Test1.arr_ques.GetLength(0) - count);
                Microsoft.Office.Interop.Excel.Chart Diagr = excelApp.Charts.Add(t, t, t, t);
                Diagr.SetSourceData(List.Range["A18", "B19"], Microsoft.Office.Interop.Excel.XlRowCol.xlColumns);
                Diagr.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered;
                Diagr.HasLegend = false;
                Diagr.HasTitle = true;
                Diagr.ChartTitle.Caption = "РЕЗУЛЬТАТЫ ТЕСТА";
                Microsoft.Office.Interop.Excel.Axis Goriz_Os = Diagr.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory, Microsoft.Office.Interop.Excel.XlAxisGroup.xlPrimary);
                Goriz_Os.HasTitle = true;
                Goriz_Os.AxisTitle.Text = "ОТВЕТЫ";
                Microsoft.Office.Interop.Excel.Axis Vertic_Os = Diagr.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue, Microsoft.Office.Interop.Excel.XlAxisGroup.xlPrimary);
                Vertic_Os.HasTitle = true;
                Vertic_Os.AxisTitle.Text = "ВОПРОСЫ";
                var path = Directory.GetCurrentDirectory();
                excelApp.ActiveChart.Export(path + "\\Excel.jpg", t, t);
            }catch(Exception e) { }
        }
    

        
        public static void Avtoriz(Form A, Form B, TextBox t, TextBox t2)
        {

            string Log = t.Text;
            string Pass = t2.Text;
            var p = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = Users.mdb");
            p.Open();
            OleDbCommand command = new OleDbCommand("SELECT [login], [password] FROM [AUTHORIZATION]", p);
            OleDbDataReader reader = command.ExecuteReader();
            Boolean f = true;
            while (reader.Read() & (f))
            {
                if ((Log == reader[0].ToString()) & (Pass == reader[1].ToString()))
                {
                    MessageBox.Show("Сейчас вы будете перенаправлены на тестирование, удачи!", "Авторизация пройдена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f = false;
                    A.Hide();
                    B.Show();
                }
            }
            reader.Close();
            if (f)
            {
                MessageBox.Show("Введены неверные логин или пароль. Проверьте корректность введённых данных.", "Авторизация не пройдена!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void SortMas()
        {
            bool flag = true;
            int m = Test1.arr_ques.GetLength(0) - 1;
            while(m > 1 && flag)
            {
                flag = false;
                for(int i = 1; i < m; i++)
                {
                    if (Test1.arr_ques[i, 1] > Test1.arr_ques[i+1, 1])
                    {
                        int x = Test1.arr_ques[i, 1];
                        Test1.arr_ques[i, 1] = Test1.arr_ques[i + 1, 1];
                        Test1.arr_ques[i + 1, 1] = x;
                        flag = true;
                    }
                }
                m--;
            }
        }


        public static void Register(TextBox t, TextBox t2)
        {
            var p = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source= Users.mdb");
            p.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO [AUTHORIZATION] ([login], [password]) VALUES (@Login, @Password)", p);
            cmd.Parameters.AddWithValue("login", t.Text);
            cmd.Parameters.AddWithValue("password", t2.Text);
            cmd.ExecuteNonQueryAsync();
            MessageBox.Show("Данные добавлены!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void deleteStroky(int k, ref int[,] mas)
        {

            for (int i = k; i < mas.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = mas[i + 1, j];
                }
            }
            int[,] newMas = new int[mas.GetLength(0) - 1, mas.GetLength(1)];
            for (int i = 0; i < newMas.GetLength(0); i++)
                for (int j = 0; j < newMas.GetLength(1); j++)
                {
                    newMas[i, j] = mas[i, j];
                }
            mas = newMas.Clone() as int[,];
        }

        public static int vvod(TextBox t)
        {
            return Convert.ToInt32(t.Text);
        }
    }

    public class DataBase
    {
        public static void add()
        {
            var k = new ADOX.Catalog();
            try
            {
                if (File.Exists("DATABASE.accdb"))
                    File.Delete("DATABASE.accdb");

                k.Create("Provider=Microsoft.Jet.OLEDB.4.0; Data Source= DATABASE.accdb");
                MessageBox.Show("БД успешно создана", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Runtime.InteropServices.COMException sit)
            {
                MessageBox.Show(sit.Message);
            }
            finally
            {
                k = null;
            }
        }
        public static void add_struct()
        {
            var p = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source = DATABASE.accdb");
            p.Open();
            var c = new OleDbCommand("CREATE TABLE [Тест] ([Номер вопроса] counter, [Правильность ответа] char(2))", p);
            try
            {
                c.ExecuteNonQuery();
                MessageBox.Show("Структура БД записана", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Runtime.InteropServices.COMException sit)
            {
                MessageBox.Show(sit.Message);
            }
            p.Close();
        }
        public static void add_zap(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                var p = new
               OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source= DATABASE.accdb");
                p.Open();
                var c = new OleDbCommand("INSERT INTO[Тест] (" + "[Правильность ответа]) VALUES('" + arr[i, 1] + "')");
                c.Connection = p;
                c.ExecuteNonQuery();
                p.Close();
            }
            MessageBox.Show("Запись в БД внесена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("DATABASE.accdb");
        }
    }

    public class Buttons
    {
        public static void vopros1(TextBox textBox1, Form form_this, Form form_next)
        {
            Test1.arr_ques[0, 0] = 1;
            if (textBox1.Text == "")
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if ((textBox1.Text == "Анализ требований") || (textBox1.Text == "анализ требований"))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[0 , 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[0, 1] = 0;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros2(TextBox textBox1, Form form_this, Form form_next)
        {
            Test1.arr_ques[1, 0] = 2;
            if (textBox1.Text == "")
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if ((textBox1.Text == "Тестирование и отладка") || (textBox1.Text == "тестирование и отладка"))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[1, 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[1, 1] = 0;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros3(HScrollBar hScrollBar1, Form form_this, Form form_next)
        {
            Test1.arr_ques[2, 0] = 3;
            if (hScrollBar1.Value == 4)
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[2, 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[2, 1] = 0;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros5(CheckBox checkBox1, CheckBox checkBox2, CheckBox checkBox3, Form form_this, Form form_next)
        {
            Test1.arr_ques[4, 0] = 5;
            if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (checkBox3.Checked == false))
            {
                MessageBox.Show("Вы не ответили на вопрос! ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((checkBox1.Checked == false) && (checkBox2.Checked == true) && (checkBox3.Checked == true))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[4, 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[4, 1] = 0;
                Form newForm = form_next;

                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros6(CheckBox checkBox1, CheckBox checkBox2, CheckBox checkBox3, Form form_this, Form form_next)
        {
            Test1.arr_ques[5, 0] = 6;

            if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (checkBox3.Checked == false))
            {
                MessageBox.Show("Вы не ответили на вопрос! ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (checkBox3.Checked == true))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[5, 1] = 1;

                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[5, 1] = 0;
                Form newForm = form_next;

                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros7(TrackBar trackBar1, Form form_this, Form form_next)
        {
            Test1.arr_ques[6, 0] = 7;
            if (trackBar1.Value == 3)
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[6, 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[6, 1] = 0;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros12(RadioButton radioButton1, RadioButton radioButton2, RadioButton radioButton3, Form form_this, Form form_next)
        {
            Test1.arr_ques[11, 0] = 12;
            if ((radioButton1.Checked == false) && (radioButton2.Checked == false) && (radioButton3.Checked == false))
            {
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((radioButton3.Checked == false) && (radioButton1.Checked == false) && (radioButton2.Checked == true))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[11, 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[11, 1] = 0;
                Form newForm = form_next;

                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros13(ComboBox comboBox1, Form form_this, Form form_next)
        {
            Test1.arr_ques[12, 0] = 13;
            if (comboBox1.Text == "")
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if ((comboBox1.Text == "Эксплуатация и сопровождение"))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[12, 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[12, 1] = 0;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros16(CheckedListBox checkedListBox1, Form form_this, Form form_next)
        {
            Test1.arr_ques[15, 0] = 16;
            if (checkedListBox1.CheckedItems.Count == 0)
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (((string)checkedListBox1.CheckedItems[0] == "Не нуждается в наличии на начальном этапе полной спецификации требований") &&
                     ((string)checkedListBox1.CheckedItems[1] == "Быстрый выпуск минимального продукта дает оперативно получать обратную связь") &&
                     ((string)checkedListBox1.CheckedItems[2] == "Отсутствие фиксированного бюджета и сроков"))
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[15, 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
                
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[15, 1] = 0;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros17(NumericUpDown numUpDown, Form form_this, Form form_next)
        {
            Test1.arr_ques[16, 0] = 17;
            if (numUpDown.Value == 0)
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (numUpDown.Value == 5)
            {
                MessageBox.Show("Ответ верный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.KOL++;
                Test1.arr_ques[16, 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                MessageBox.Show("Ответ неверный! Следующий вопрос", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Test1.arr_ques[16, 1] = 0;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
        }

        public static void vopros18(NumericUpDown numUpDown, Form form_this, Form form_next)
        {
            Test1.arr_ques[17, 0] = 18;
            if (numUpDown.Value == 0)
                MessageBox.Show("Вы не ответили на вопрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (numUpDown.Value == 5)
            {
                Test1.KOL++;
                Test1.arr_ques[17, 1] = 1;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
            else
            {
                Test1.arr_ques[17, 1] = 0;
                Form newForm = form_next;
                newForm.Show();
                form_this.Hide();
            }
        }
    }
}



