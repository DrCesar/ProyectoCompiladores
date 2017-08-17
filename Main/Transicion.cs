
using System;

namespace Main
{
    [Serializable]
    internal class Transicion
    {
        private Estado dest;
        private string inf;

        public Transicion(string i, Estado e)
        {
            this.dest = e;
            this.inf = i;
        }

        public void setInf(string s)
        {
            this.inf = s;
        }

        public string getInf()
        {
            return this.inf;
        }

        public void setDest(Estado e)
        {
            this.dest = e;
        }

        public Estado getDest()
        {
            return this.dest;
        }

        internal string toString()
        {
            if(dest != null)
                return "(" + inf + "," + dest.getNum() + ")";
            return "()";
        }

    }
}