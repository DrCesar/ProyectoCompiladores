using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    [Serializable]
    class Nodo
    {
        protected Nodo der;
        protected Nodo izq;
        protected bool nulla;
        protected String info;
        protected String num;
        protected List<Nodo> fPos;
        protected List<Nodo> lPos;
        protected List<Nodo> folPos;

        public Nodo()
        {

        }

        public Nodo(string s)
        {
            this.info = s;
            if (s != "@")
                this.nulla = false;
            else
                this.nulla = true;
            this.lPos = new List<Nodo>();
            this.fPos = new List<Nodo>();
            this.folPos = new List<Nodo>();
        }

        public Nodo(string s, Nodo d)
        {
            this.info = s;
            this.der = d;
            this.nulla = true;

            this.fPos = d.getFPos();
            this.lPos = d.getLPos();

            foreach (var i in this.lPos)
                foreach (var j in this.fPos)
                    i.getFolPos().Add(j);       
        }

        public Nodo(string s,Nodo d, Nodo i)
        {
            this.info = s;
            this.der = d;
            this.izq = i;
            if(s == "|")
            {
                this.nulla = this.der.getNulla() || this.izq.getNulla();

                this.fPos = setPos(this.der.getFPos(), this.izq.getFPos());
                this.lPos = setPos(this.der.getLPos(), this.izq.getLPos());
            }
            else
            {
                this.nulla = this.der.getNulla() && this.izq.getNulla();

                if (this.izq.getNulla())
                    this.fPos = setPos(this.der.getFPos(), this.izq.getFPos());
                else
                    this.fPos = this.izq.getFPos();

                if (this.der.getNulla())
                    this.lPos = setPos(this.der.getLPos(), this.izq.getLPos());
                else
                    this.lPos = this.der.getLPos();

                foreach (var k in this.izq.getLPos())
                    foreach (var j in this.der.getFPos())
                        k.getFolPos().Add(j);
            }
        }


        public void setInfo(string s)
        {
            this.info = s;
        }

        public string getInfo()
        {
            return this.info;
        }

        public void setNum(string s)
        {
            this.num = s;
        }

        public string getNum()
        {
            return this.num;
        }

        public void setDer(Nodo n)
        {
            this.der = n;
        }

        public Nodo getDer()
        {
            return this.der;
        }

        public void setIzq(Nodo i)
        {
            this.izq = i;
        }

        public Nodo getIzq()
        {
            return this.izq;
        }

        public void setNulla(bool b)
        {
            this.nulla = b;
        }

        public bool getNulla()
        {
            return this.nulla;
        }

        public void setFPos(List<Nodo> l)
        {
            this.fPos = l;
        }

        public List<Nodo> getFPos()
        {
            return this.fPos;
        }

        public void setLPos(List<Nodo> l)
        {
            this.lPos = l;
        }

        public List<Nodo> getLPos()
        {
            return this.lPos;
        }

        public void setFolPos(List<Nodo> l)
        {
            this.folPos = l;
        }

        public List<Nodo> getFolPos()
        {
            return this.folPos;
        }

        public List<Nodo> setPos(List<Nodo> d, List<Nodo> i)
        {
            List<Nodo> l = new List<Nodo>();

            foreach (var j in d)
                if (!l.Contains(j))
                    l.Add(j);
            foreach (var j in i)
                if (!l.Contains(j))
                    l.Add(j);

            return l;
        }

    }
}
