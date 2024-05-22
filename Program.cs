using Microsoft.Win32;

namespace practical_work_II
{
    public class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ChangeState s = new ChangeState();
            ChangeState cs = new ChangeState();
            ApplicationConfiguration.Initialize();
            while (cs.GetStates() != 0)
            {
                switch (cs.GetStates())
                {
                    case 1:
                        Application.Run(new Form1(cs));
                        break;
                    case 2:
                        Application.Run(new Register(cs));
                        break;
                    case 3:
                        Application.Run(new RecoverPasswd(cs));
                        break;
                    case 4:
                        Application.Run(new Calculator(cs));
                        break;
                }
            }
        }
    }
}