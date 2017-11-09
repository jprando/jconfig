using System;

namespace el.npd.backup
{
    class Program
    {
        static void Main(string[] args) => new Backup().Config(args).Run();
    }

    public static class ProgramUtils
    {
        public static void VarDump(this object variavel)
        {
            var tipo = variavel.GetType();
            var props = tipo.GetProperties();
            Console.WriteLine();
            Console.WriteLine($" #VARDUMP {tipo.FullName}");
            Console.WriteLine();
            foreach (var item in props)
            {
                var valor = item.GetValue(variavel);
                Console.WriteLine($" {item.Name,-18} : {valor}");
            }
            Console.WriteLine();
        }
    }
}
