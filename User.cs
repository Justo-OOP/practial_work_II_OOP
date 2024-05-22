using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_work_II
{
    public class User
    {
        private string name;
        private string password;
        private string mail;
        private string username;
        public User(string Name, string Password, string Email, string Username)
        {
            this.name = Name;
            this.password = Password;
            this.mail = Email;
            this.username = Username;
        }
        public string Print()
        {
            return $"{name},{password},{mail},{username}";
        }

        public void SetPassword(string new_pass)
        {
            this.password = new_pass;
        }

        public string GetUName()
        {
            return this.username;
        }

    }
}
