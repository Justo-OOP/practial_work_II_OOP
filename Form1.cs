using static System.Windows.Forms.AxHost;

namespace practical_work_II
{
    public partial class Form1 : Form
    {
        private ChangeState cs = new ChangeState();
        private string username;
        private string password;
        private string usersFilePath = "users.txt";
        public Form1(ChangeState cs)
        {
            this.cs = cs;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Sign in button
        {
            if (ValidCredentials(username, password))
            {
                this.cs.ChangeStates(4);
                this.Close();
                return;
            }
            MessageBox.Show("Username or password incorrect.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Username
        {
            username = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // Password
        {
            password = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e) // Forgot password button
        {
            this.cs.ChangeStates(3);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) // Register button
        {
            this.cs.ChangeStates(2);
            this.Close();
        }
        private bool ValidCredentials(string username, string password)
        {
            using (StreamReader sr = new StreamReader(usersFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] attributes = line.Split(',');
                    if (attributes[3] == username && attributes[1] == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}