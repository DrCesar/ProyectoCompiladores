using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class EstadoD : Estado
    {
        private List<Estado> estadosAFN;
        private List<Nodo> nodosD;
        private bool marcado;

        public EstadoD()
        {
            this.estadosAFN = new List<Estado>();
        }

        public EstadoD(List<Estado> l)
        {
            this.estadosAFN = l;

            this.num = "";
            this.marcado = false;
            this.aceptacion = false;
            this.inicio = false;

            foreach (var i in estadosAFN)
            {
                if (i.getAceptacion())
                    this.aceptacion = true;
                if (i.getInicio())
                    this.inicio = true;
            }

        }

        public EstadoD(List<Nodo> l)
        {
            this.nodosD = l;

            this.num = "";
            this.marcado = false;
            this.aceptacion = false;
            this.inicio = false;
        }

        public void agregarTransicion(EstadoD e, String i)
        {
            this.conexiones.Add(new Transicion(i, e));
        }

        public void setMarcado(bool b)
        {
            this.marcado = b;
        }

        public bool getMarcado()
        {
            return this.marcado;
        }

        public void setEsdadosAFN(List<Estado> s)
        {
            this.estadosAFN = s;
        }

        public List<Estado> getEstadosAFN()
        {
            return this.estadosAFN;
        }

        public void setNodosD(List<Nodo> l)
        {
            this.nodosD = l;
        }

        public List<Nodo> getNodosD()
        {
            return this.nodosD;
        }

        public bool contieneE(Estado e)
        {
            if (estadosAFN.Contains(e))
                return true;
            else
                return false;
        }

        public bool cotieneN(Nodo n)
        {
            if (this.nodosD.Contains(n))
                return true;
            else
                return false;
        }

    }
}
