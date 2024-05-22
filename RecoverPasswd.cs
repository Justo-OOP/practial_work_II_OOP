using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practical_work_II
{
    public partial class RecoverPasswd : Form
    {
        private string username;
        private string password1;
        private string password2;
        private string usersFilePath = "users.txt";
        ChangeState cs = new ChangeState();

        List<User> usuarios = new List<User>();
        public RecoverPasswd(ChangeState cs)
        {
            this.cs = cs;
            ChargeAccounts();

            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e) // username
        {
            username = textBox3.Text;
        }
        public string GetUsername()
        {
            return username;
        }
        private void button1_Click(object sender, EventArgs e) // Change password button
        {
            bool exito = false;
            if(textBox3.Text != "")
            {
                if (password1 != password2)
                {
                    MessageBox.Show("Passwords do not match..");
                    return;
                }

                if (!IsValidPassword(password1))
                {
                    MessageBox.Show("Passwords must be at least 8 characters long, including one upper and one lower case letter, one number, and one special symbol.");
                    return;
                }

                foreach(User u in usuarios)
                {
                    if(u.GetUName() == textBox3.Text)
                    {
                        u.SetPassword(password1);
                        MessageBox.Show("Changes realized  -> " + u.Print());
                        exito= true;
                    }
                }

                if (exito == true)
                {
                    StreamWriter sw = new StreamWriter(usersFilePath);
                    foreach (User user in usuarios)
                    {
                        sw.WriteLine(user.Print());
                    }
                    sw.Close();

                    this.cs.ChangeStates(1);
                    this.Close();
                }
            }
        }
        public void ChargeAccounts()
        {
            if (!File.Exists(usersFilePath))
            {
                MessageBox.Show("User file not found");
                return;
            }
            StreamReader sr = new StreamReader(usersFilePath);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] attributes = line.Split(',');

                User u = new User(attributes[0], attributes[1], attributes[2], attributes[3]);
                usuarios.Add(u);
            }
            sr.Close();
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e) // New password 1
        {
            password1 = textBox1.Text;
        }
        private void textBox2_TextChanged_1(object sender, EventArgs e) // Repeat password 2
        {
            password2 = textBox2.Text;
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
    }
}