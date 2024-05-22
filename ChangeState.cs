using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_work_II
{
    public class ChangeState
    {
        private byte state;
        public ChangeState() 
        {
            this.state = 1;
        }
        public void ChangeStates(byte state)
        {
            this.state = state;
        }
        public byte GetStates()
        {
            return this.state;
        }
    }
}
