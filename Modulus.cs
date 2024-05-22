using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_work_II
{
    public class Modulus : Operation
    {
        private double result;
        public Modulus(double op1, double op2)
        {
        }
        public Modulus(string sign, double op1, double op2)
        {
        }
        public double operate(double op1, double op2)
        {
            if (op2 == 0 || op2 == 1) return 0;

            this.result = op1;
            while (this.result >= op2)
            {
                this.result -= op2;
            }
            return this.result;
        }
        public double operateSign(string sign, double op1, double op2)
        {
            if (op2 == 0 || op2 == 1) return 0;

            this.result = op1;
            while (this.result >= op2)
            {
                this.result -= op2;
            }
            return this.result;
        }
    }
}
