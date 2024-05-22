using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practical_work_II
{
    public partial class Register : Form
    {
        private string name;
        private string mail;
        private string username;
        private string password1;
        private string password2;
        private List<User> users = new List<User>();
        ChangeState cs = new ChangeState();
        public Register(ChangeState cs)
        {
            this.cs = cs;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // name
        {
            name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // mail
        {
            mail = textBox2.Text;   
        }

        private void textBox3_TextChanged(object sender, EventArgs e) // username
        {
            username = textBox3.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e) // password 1
        {
            password1 = textBox5.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e) // password 2
        {
            password2 = textBox4.Text;  
        }

        private void button1_Click(object sender, EventArgs e) // Submit button
        {
            if (name == "" || mail == "" || username == "")
            {
                MessageBox.Show("The fields cannot be empty");
                return;
            }

            if (password1 != password2)
            {
                MessageBox.Show("Password do not match.");
                return;
            }

            if (!IsValidPassword(password1))
            {
                MessageBox.Show("Passwords must be at least 8 characters long, including one upper and one lower case letter, one number, and one special symbol.");
                return;
            }
            if (!IsValidPassword(password2))
            {
                MessageBox.Show("Passwords must be at least 8 characters long, including one upper and one lower case letter, one number, and one special symbol.");
                return;
            }

            if (name == username)
            {
                MessageBox.Show("Username can't be the same as your name.");
                return;
            }

            if (!checkBox1.Checked)
            {
                MessageBox.Show("You must accept the protection policy before continuing.");
                return;
            }

            User newUser = new User(name, password1, mail, username);
            users.Add(newUser);

            string path = "users.txt";
            try
            {
                StreamWriter sw = new StreamWriter(path);
                foreach (User user in users)
                {
                    sw.WriteLine(user.Print());
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            MessageBox.Show("Successfully registered user.");
            this.cs.ChangeStates(1);
            this.Close();
        }
        private bool IsValidPassword(string password)
        {
            int minLength = 8;
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            if (password.Length < minLength)
            {
                return false;
            }

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    hasSpecialChar = true;
                }

                if (hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar)
                {
                    return true;
                }
            }

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) // Acception policy
        {

        }
    }
}
