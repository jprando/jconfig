using System;
using System.Text;

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
            StringBuilder texto = new StringBuilder();
            texto.AppendLine($"{Environment.NewLine} #VARDUMP {tipo.FullName}{Environment.NewLine}");
            foreach (var item in props)
            {
                try
                {
                    var valor = item.GetValue(variavel);
                    texto.AppendLine($" {item.Name,-18} : {valor}");
                }
                catch (Exception) { }
            }
            Console.WriteLine(texto.ToString());

        }
    }
}
