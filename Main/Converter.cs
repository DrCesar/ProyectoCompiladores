using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Converter
    {

        public Converter()
        {

        }

        public AutomataD AfnToAfd(Automata a)
        {
            DStates d = new DStates();
            List<Estado> temp = new List<Estado>();
            EstadoD e;
            AutomataD b = new AutomataD();

            temp = a.eClosure(a.getInicio());
            d.Add(new EstadoD(temp));
            b.setInicio(d[0]);
            a.getAlfa().Remove("@");
            b.setAlfa(a.getAlfa());
            d.setNMarcado();

            while(d.getNMarcado() != null)
            {
                d.marcar();
                b.addContEstados(d.getNMarcado());
                foreach (var i in b.getAlfa())
                {
                    temp = a.eClosure(a.move(d.getNMarcado().getEstadosAFN(), i));
                    e = new EstadoD(temp);
                    if (!d.contieneE(e))
                    {
                        d.Add(e);
                        if (e.contieneE(a.getFin()))
                            b.addFin(e);
                        d.getNMarcado().agregarTransicion(e, i);
                    }
                    else
                    {
                        d.getNMarcado().agregarTransicion(d.Find(t => t.getEstadosAFN().All(e.getEstadosAFN().Contains) && e.getEstadosAFN().All(t.getEstadosAFN().Contains)), i);
                    } 
                }
                d.setNMarcado();
            }

            return b;
        }




        public AutomataD DirectAFD(ArbolSin a)
        {
            DStates d = new DStates();
            List<Nodo> temp = new List<Nodo>();
            EstadoD e;
            AutomataD b = new AutomataD();

            d.Add(new EstadoD(a.getRaiz().getFPos()));
            b.setInicio(d[0]);
            b.setAlfa(a.getAlfa());
            d.setNMarcado();

            while(d.getNMarcado() != null)
            {
                d.marcar();
                b.addContEstados(d.getNMarcado());
                foreach (var i in b.getAlfa())
                {
                    temp = a.getFollowPos(d.getNMarcado().getNodosD(), i);
                    e = new EstadoD(temp);
                    if (!d.contieneN(e))
                    {
                        d.Add(e);
                        if (e.cotieneN(a.getFin()))
                            b.addFin(e);
                        d.getNMarcado().agregarTransicion(e, i);
                    }
                    else
                    {
                        d.getNMarcado().agregarTransicion(d.Find(t => t.getNodosD().All(e.getNodosD().Contains) && e.getNodosD().All(t.getNodosD().Contains)), i);
                    }  
                }
                d.setNMarcado();
            }

            return b;
        }

    }
}
