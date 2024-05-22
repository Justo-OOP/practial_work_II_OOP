using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_work_II
{
    public class Subtract : Operation
    {
        public Subtract(double op1, double op2)
        {
        }
        public Subtract(string sign, double op1, double op2)
        {
        }
        public double operate(double op1, double op2)
        {
            return op1 - op2;
        }
        public double operateSign(string sign, double op1, double op2)
        {
            sign += op1 - op2;
            return Convert.ToDouble(sign);
        }
    }
}
