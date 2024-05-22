using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace practical_work_II
{
    public class Operation
    {
        private double result;
        private string line;
        protected double op1;
        protected double op2;
        protected string operand;
        protected string sign;

        public Operation()
        {

        }

        public Operation(string op)
        {
            this.line = op;
        }
        public void Processline()
        {
            string[] linesnum = line.Split(' ');
            if (linesnum.Length == 3)
            {
                this.op1 = Convert.ToDouble(linesnum[0]);
                this.operand = (linesnum[1]);
                this.op2 = Convert.ToDouble(linesnum[2]);
            }
            else if (linesnum.Length == 4)
            {
                this.sign = linesnum[0];
                this.op1 = Convert.ToDouble(linesnum[1]);
                this.operand = (linesnum[2]);
                this.op2 = Convert.ToDouble(linesnum[3]);
                switch (operand)
                {
                    case "+":
                        Add a1 = new Add(sign, op1, op2);
                        this.result = a1.operateSign(sign, op1, op2);
                        break;
                    case "-":
                        Subtract s1 = new Subtract(sign, op1, op2);
                        this.result = s1.operateSign(sign, op1, op2);
                        break;
                    case "*":
                        Multiply m1 = new Multiply(op1, op2);
                        this.result = m1.operateSign(sign, op1, op2);
                        break;
                    case "/":
                        Divide d1 = new Divide(sign, op1, op2);
                        this.result = d1.operateSign(sign, op1, op2);
                        break;
                    case "mod":
                        Modulus mod1 = new Modulus(sign, op1, op2);
                        this.result = mod1.operateSign(sign, op1, op2);
                        break;
                    case "^":
                        Pow p1 = new Pow(sign, op1, op2);
                        this.result = p1.operateSign(sign, op1, op2);
                        break;
                }
            }
            switch (operand)
            {
                case "+":
                    Add a1 = new Add(op1, op2);
                    this.result = a1.operate(op1, op2);
                    break;
                case "-":
                    Subtract s1 = new Subtract(op1, op2);
                    this.result = s1.operate(op1, op2);
                    break;
                case "*":
                    Multiply m1 = new Multiply(op1, op2);
                    this.result = m1.operate(op1, op2);
                    break;
                case "/":
                    Divide d1 = new Divide(op1, op2);
                    this.result = d1.operate(op1, op2);
                    break;
                case "mod":
                    Modulus mod1 = new Modulus(op1, op2);
                    this.result = mod1.operate(op1, op2);
                    break;
                case "^":
                    Pow p1 = new Pow(op1, op2);
                    this.result = p1.operate(op1, op2);
                    break;
            }
        }
        public double Result()
        {
            return this.result;
        }
    }
}
