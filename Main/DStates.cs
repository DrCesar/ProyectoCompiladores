using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class DStates : List<EstadoD>
    {
        private int x;
        protected EstadoD nMarcado;


        public DStates()
        {

        }

        public EstadoD getNMarcado()
        {
            return this.nMarcado;
        }


        public bool contieneE(EstadoD e)
        {
            if(this.Count != 0)
            {
                foreach (var i in this)
                {
                    if (i.getEstadosAFN().All(e.getEstadosAFN().Contains) && e.getEstadosAFN().All(i.getEstadosAFN().Contains))
                        return true;
                }
            }

            return false;
        }

        public bool contieneN(EstadoD e)
        {
            if (this.Count != 0)
            {
                foreach (var i in this)
                {
                    if (i.getNodosD().All(e.getNodosD().Contains) && e.getNodosD().All(i.getNodosD().Contains))
                        return true;
                }
            }

            return false;
        }

        public void marcar()
        {
            nMarcado.setMarcado(true);
        }


        public void setNMarcado()
        {
            bool r = false;

            if (this.Count != 0)
            {
                foreach (var i in this)
                {
                    if (!i.getMarcado())
                    {
                        this.nMarcado = i;
                        r = true;
                    }
                }
            }
            if(!r)
                this.nMarcado = null;
        }

    }
}
