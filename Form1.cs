using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtNumber.Text = Properties.Settings.Default.number.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = 0;
            try
            {
                number = int.Parse(this.txtNumber.Text);
                int maxdigit = Logic.Maximum(number);
                if (number < 100 || number > 999)
                {
                    MessageBox.Show("Некоректный ввод! Введите трёхзначное число!");
                }
                else
                {
                    MessageBox.Show("Наибольшая цифра числа: " + maxdigit);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.number = number;
            Properties.Settings.Default.Save();
        }
    }
}
public class Logic
{
    public static int Maximum(int number)
    {
        int maxdigit = 0;
        if ((number % 10) > maxdigit)
        {
            maxdigit = number % 10;
        }
        number = number / 10;
        if ((number % 10) > maxdigit)
        {
            maxdigit = number % 10;
        }
        number = number / 10;
        if (number > maxdigit)
        {
            maxdigit = number;
        }
        return maxdigit;
    }
}
