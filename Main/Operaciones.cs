namespace Main
{
    internal class Operaciones
    {

        public Operaciones()
        {

        }

        internal Automata adicion(Automata a, Automata b)
        {
            Estado ini = new Estado();
            Estado fin = new Estado();

            ini.agregarTransicion(a.getInicio(), "@");
            ini.agregarTransicion(b.getInicio(), "@");

            a.insertTransFin(fin, "@");
            b.insertTransFin(fin, "@");

            return new Automata(ini, fin);
        }

        internal Automata multiplicacion(Automata a, Automata b)
        {
            Estado ini = new Estado();
            Estado fin = new Estado();

            ini.agregarTransicion(a.getInicio(), "@");

            a.insertTransFin(b.getInicio(), "@");

            b.insertTransFin(fin, "@");

            return new Automata(ini, fin);
        }

        internal Automata kleene(Automata a)
        {
            Estado ini = new Estado();
            Estado fin = new Estado();

            ini.agregarTransicion(a.getInicio(), "@");
            ini.agregarTransicion(fin, "@");

            a.insertTransFin(fin, "@");
            a.insertTransFin(a.getInicio(), "@");

            return new Automata(ini, fin);
        }

    }
}