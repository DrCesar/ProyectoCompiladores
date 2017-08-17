using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class AutomataD : Automata
    {


        public AutomataD()
        {
            this.fin = new List<Estado>();
            this.contEstados = new List<Estado>();
            cantEstados = 0;
        }

        public void addFin(EstadoD e)
        {
            this.fin.Add(e);
        }

        public void setAlfa(List<string> s)
        {
            this.alfa = s;
        }

        public void addContEstados(EstadoD e)
        {
            this.cantEstados++;
            e.setNum(cantEstados.ToString());
            this.contEstados.Add(e);
        }

        public List<Estado> moveD(List<Estado> l, string s)
        {
            List<Estado> r = new List<Estado>();

            foreach(var i in l)
                foreach (var j in i.getConexiones())
                    if (j.getInf() == s)
                        r.Add(j.getDest());
            
            return r;
        }

        public void simularD(string s)
        {
            List<Estado> l = new List<Estado>();

            l.Add(this.inicio);
            foreach (var i in s)
                l = moveD(l, s[i].ToString());

            if (l.All(fin.Contains))
                Console.WriteLine("El String " + s + " si es un posible resultado");
            else
                Console.WriteLine("El String " + s + " no es un posible resultado");
        }


        





        public void setUp()
        {

        }

        public override void numEstados()
        {

        }

    }
}
