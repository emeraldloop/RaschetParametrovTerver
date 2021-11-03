using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LR1_zadanie2
{
    public partial class Form1 : Form
    {
        private List<double> data; // данные для обработки
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) // вывод диспресии на экран
        {
            if (data == null)
            {
                MessageBox.Show("Загрузите данные!", "Ошибка!");
                return;
            }
            MessageBox.Show("Дисперсия равна " + countD(),"Расчёт");
        }
        private double countD() // расчет диспресии
        {
            double D=0;
            if (radioButton1.Checked == true) // нормальное распределение
            {
                double sigma = 0;
                foreach (float a in data)
                    sigma += Math.Pow(a - data.Average(), 2);
                D = sigma / (data.Count - 1);
            }
            if (radioButton2.Checked == true) // равномерное распределение
            {
                D = Math.Pow(data.Max() - data.Min(), 2) / 12;
            }
            return Math.Round(D,5);
        }

        private void button3_Click(object sender, EventArgs e) // вывод СКО на экран
        {
            if (data == null)
            {
                MessageBox.Show("Загрузите данные!","Ошибка!");
                return;
            }
            MessageBox.Show("СКО равно "+countSKO(), "Расчёт");
        }
        private double countSKO() // расчет СКО
        {
            double SKO;
            SKO = Math.Sqrt(countD());
            return Math.Round(SKO, 5);
        }
        private void button4_Click(object sender, EventArgs e) // загрузка данных
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            data = new List<double>(); // данные для обработки
            for (int i=0;i<fileText.Length;i++) 
            {
                if(fileText[i]==' ')
                { 
                    StringBuilder number=new StringBuilder();
                    for (int j = 0; j < i; j++)
                        number.Append(fileText[j]);
                    data.Add(Convert.ToDouble(number.ToString()));
                    fileText=fileText.Remove(0, i);
                    i = 0;
                }
            }
            MessageBox.Show("Файл открыт");
        }
        private void button1_Click(object sender, EventArgs e) // Вывод мат ожидания на экран
        {
            if(data==null)
            {
                MessageBox.Show("Загрузите данные!", "Ошибка!");
                return;
            }
            MessageBox.Show("Математическое ожидание равно " + countM(),"Расчёт");
        }
        
        private double countM() // расчёт мат ожидания
        {
            double M=0;
            if (radioButton1.Checked == true) //нормальное распределение
            {
                M = data.Average();
            }
            if (radioButton2.Checked == true) // равномерное распределение
            {
                M = (data.Max() - data.Min()) / 2;
            }
            return Math.Round(M, 5);
        } 
    }
}
