using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 

namespace Main
{
    [Serializable]
    internal class Estado
    {
        protected List<Transicion> conexiones;
        protected String num;
        protected bool inicio;
        protected bool aceptacion;


        public Estado()
        {
            this.num = "";
            this.conexiones = new List<Transicion>();
        }

        public Estado(string s)
        {
            this.num = "";
        }

        public Estado(String s, Estado e)
        {
            this.num = s;
            this.conexiones = new List<Transicion>();
        }

        public void agregarTransicion(Estado e, String i)
        {
            this.conexiones.Add(new Transicion(i, e));
        }

        public void setNum(String s)
        {
            this.num = s;
        }

        public String getNum()
        {
            return this.num;
        }

        public void setConexiones(List<Transicion> l)
        {
            this.conexiones = l;
        }

        public List<Transicion> getConexiones()
        {
            return this.conexiones;
        }

        public void setInicio(bool b)
        {
            this.inicio = b;
        }

        public bool getInicio()
        {
            return this.inicio;
        }

        public void setAceptacion(bool b)
        {
            this.aceptacion = b;
        }

        public bool getAceptacion()
        {
            return this.aceptacion;
        }







        internal string toString()
        {
            string trans = "";

            foreach (var i in conexiones)
            {
                trans = trans + " " + i.toString();
            }

            return "[" + this.num + " " + trans + "]";
        }

    }
}

