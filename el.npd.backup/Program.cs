using System;

namespace el.npd.backup
{
    class Program
    {
        static void Main(string[] args)
            => new Backup() //.Config(args)
            .Config("-hservidordb", "-p:portadb", "/user=usariodb", "--senha", "senhadb", "--database=dadosdb")
            .Run();
    }
}
