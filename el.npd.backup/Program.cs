using System;

namespace el.npd.backup
{
    class Program
    {
        static void Main(string[] args)
        {
            new Backup()
                //.Config(args)
                .Config(
                    "-hlocalhost",
                    "-p:5432",
                    "/user=elsistemas",
                    "--senha", "elerp",
                    "--database=eldados")
                .Run();
        }
    }
}
