using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_work_II
{
    public class Pow : Operation
    {
        private double result;
        public Pow(double op1, double op2) 
        {
        }
        public Pow(string sign, double op1, double op2)
        {
        }
        public double operate(double op1, double op2)
        {
            for (int i = 0; i <= op2; i++)
            {
                this.result = op1 * op1;
            }   
            return this.result;
        }
        public double operateSign(string sign, double op1, double op2)
        {
            for (int i = 0; i <= op2; i++)
            {
                this.result = op1 * op1;
            }
            return this.result;
        }
    }
}
