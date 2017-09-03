using System;
using System.Collections.Generic;

namespace Main
{
    [Serializable]
    internal class Automata
    {
        protected Estado inicio;
        protected List<Estado> fin;
        protected int cantEstados;
        protected List<Estado> contEstados;
        protected List<string> alfa = new List<string>();

        public Automata()
        {
            inicio = new Estado();
            fin = new List<Estado>();
            this.cantEstados = 0;
            this.contEstados = new List<Estado>();
            numEstados();
        }

        public Automata(string s)
        {
            inicio = new Estado();
            fin = new List<Estado>();
            fin.Add(new Estado());
            inicio.agregarTransicion(fin[0], s);
            this.cantEstados = 0;
            this.contEstados = new List<Estado>();
            numEstados();
        }

        public Automata(Estado i, Estado f)
        {
            this.inicio = i;
            fin = new List<Estado>();
            this.fin.Add(f);
            this.cantEstados = 0;
            this.contEstados = new List<Estado>();
            numEstados();
        }

        internal Estado getInicio()
        {
            return this.inicio;
        }

        public void setInicio(Estado e)
        {
            this.inicio = e;
        }

        internal Estado getFin()
        {
            return this.fin[0];
        }

        internal void insertTransFin(Estado e, string s)
        {
            this.fin[0].agregarTransicion(e, s);
        }

        internal void insertTransIni(Estado e, string s)
        {
            this.inicio.agregarTransicion(e, s);
        }

        public List<string> getAlfa()
        {
            return this.alfa;
        }

        public List<Estado> eClosure(Estado e)
        {
            List<Estado> l = new List<Estado>();

            l.Add(inicio);
            return eClosure(l);
        }

        public List<Estado> eClosure(List<Estado> r)
        {
            bool a = true;
            int cont = 0;

            if(r.Count != 0)
                while (a)
                {
                    a = false;
                    foreach (var j in r[cont].getConexiones())
                        if (j.getInf().Contains("@") && !r.Contains(j.getDest()))
                        {
                            a = true;
                            r.Add(j.getDest());
                        }
                    if (cont < r.Count-1)
                        a = true;
                    else
                        a = false;
                    cont++;
                }
                
            return r;
        }

        public List<Estado> move(List<Estado> l, String s)
        {
            List<Estado> res = new List<Estado>();


            foreach (var i in l)
            {
                foreach (var j in i.getConexiones())
                {
                    if (j.getInf().Contains(s))
                    {
                        res.Add(j.getDest());
                    } 
                }
            }

            return res;
        }

        public virtual List<Estado> move(Estado e, String s)
        {
            List<Estado> res = new List<Estado>();
            
            foreach (var j in e.getConexiones())
            {
                if (j.getInf().Contains(s))
                {
                    res.Add(j.getDest());
                }
            }

            return res;
        }

        public void simular(String s)
        {
            List<Estado> l = new List<Estado>();

            l = eClosure(inicio);
            foreach (var i in s)
                l = eClosure(move(l,i.ToString()));

            if (l.Contains(fin[0]))
                Console.WriteLine("El String " + s + " si es un posible resultado");
            else
                Console.WriteLine("El String " + s + " no es un posible resultado");
        }







        internal void printEstados()
        {
            numEstados();
            string s = "Estados: {";

            s = s + "1";
            for(int i = 2; i <= cantEstados; i++)
            {
                s = s + ", "  + i.ToString();
            }

            s = s + "}";

            Console.WriteLine(s);      
        }

        internal void printAlfa()
        {
            string a = "";

            foreach (string i in alfa)
            {
                a = a + "," + i;
            }

            a = "Alfabeto: {" + a.Substring(1) + "}";

            Console.WriteLine(a);
        }

        public virtual void numEstados()
        {
            //this.inicio = numEstadosRec(this.inicio);
            cantEstados = 0;
            numEstadosRec(this.inicio);
            cantEstados = contEstados.Count;
        }

        public void numEstadosRec(Estado temp)
        {
            if (!contEstados.Contains(temp)) {
                cantEstados = cantEstados + 1;
                //temp.setNum(cantEstados.ToString());
                contEstados.Add(temp);
                foreach (var i in temp.getConexiones())
                {
                    if (!alfa.Contains(i.getInf()))
                        alfa.Add(i.getInf());
                    numEstadosRec(i.getDest());
                } 
            }
        }

        public virtual void toString()
        {
            string s = "";
            printAlfa();
            Console.WriteLine("Inicio: {"  + inicio.getNum() + "}");
            foreach (var i in fin)
                s = s + "," + i.getNum();
            Console.WriteLine("Aceptacion: {" + s + "}");
            foreach (var i in contEstados)
                Console.WriteLine(i.toString());
        }
    }
}