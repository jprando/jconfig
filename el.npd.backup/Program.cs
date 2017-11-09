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
            using(StringBuilder text = new StringBuilder())
            {
                text.WriteLine($"\r\n #VARDUMP {tipo.FullName}\r\n");
                foreach (var item in props)
                {
                    var valor = item.GetValue(variavel);
                    text.WriteLine($" {item.Name,-18} : {valor}");
                }
                Console.WriteLine(text.ToString());
            }
        }
    }
}
