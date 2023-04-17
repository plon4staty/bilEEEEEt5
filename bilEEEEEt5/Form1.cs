using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bilEEEEEt5
{


    public partial class Form1 : Form
    {
        DataBase db = new DataBase();
        public Form1()
        {
            InitializeComponent();
        }

        private int count;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            if (count < 3)
            {
                try
                {
                    DataTable users = db.ExecuteSql($"select * from users where logins = '{textBox1.Text}' and passwords = '{textBox2.Text}'");
                    if (users.Rows.Count > 0)
                    {
                        MessageBox.Show("Вы успешно вошли!");
                    }
                    else
                    {
                        MessageBox.Show($"Вы ввели неправильного пользователя, у Вас осталось {3 - count} попытки");
                    }
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так");
                }
            }
            else
            {
                MessageBox.Show("Похоже, Вы забыли пароль, предлагаю поменять пароль!");
                Sbros newPassword = new Sbros();
                newPassword.Show();
                this.Hide();
            }
        }
    }
}




  
