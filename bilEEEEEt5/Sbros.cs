using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bilEEEEEt5
{
    public partial class Sbros : Form
    {
        DataBase db = new DataBase();
        public Sbros()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = db.ExecuteSql($"select * from users where logins = '{textBox1.Text}'");
            var newpass = textBox2.Text;

            var chs = new[] { '@', '#', '%', ')', '(', '.', '<' };
            int s = 0, n = 0, b = 0;
            foreach (var c in newpass)
                if (char.IsDigit(c)) ++n;
                // else if (chs.Contains(c)) ++s; 
                else if (char.IsLetter(c)) ++b;


            if (n == 3 && b == 5 /* && s > 0 */ && newpass.Contains("@") & newpass.Contains("%") && newpass.Contains("#") && newpass.Contains(".") && newpass.Contains("(") && newpass.Contains(")") && newpass.Contains("<"))
            {
                try
                {
                    if (dt.Rows.Count > 0 && textBox2.Text.Length > 9)
                    {
                        db.ExecuteSqlNonQuery($"update users set passwords = '{textBox2.Text}' where logins = '{textBox1.Text}'");
                        MessageBox.Show("Пароль успешно изменён!");
                    }
                    else
                    {
                        MessageBox.Show("Такого пользователя не существует");
                    }
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }
            }
            else
            {
                MessageBox.Show("Что-то пошло не так! Проверьте пароль на соответствие шаблону (5 букв, 3 цифры и спец. символы ' @#%)(.< ' :");
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length == 15 & textBox2.Text.Contains("@") & textBox2.Text.Contains("#") & textBox2.Text.Contains("%") & textBox2.Text.Contains("(") & textBox2.Text.Contains("(") & textBox2.Text.Contains(".") & textBox2.Text.Contains("<"))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
