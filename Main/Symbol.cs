using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Symbol
    {
        private string sym;
        private bool oper;

        public Symbol(string s, bool b)
        {
            this.oper = b;
            this.sym = s;
        }

        public string getSym()
        {
            return this.sym;
        }

        public bool isOper()
        {
            return this.oper;
        }
    }
}
