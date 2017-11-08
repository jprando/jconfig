using System;
using System.Linq;

namespace el.npd.backup
{
    public class Options
    {
        public string[] Parametro { get; set; }
        public string Descricao { get; set; }
        public Action<string> SetValue { get; set; }

        public Options(string parametro, string descricao, Action<string> setValue)
        {
            if (string.IsNullOrWhiteSpace(parametro))
                throw new ArgumentNullException("parametro", "Parametro é obrigatório");

            var valorParametro = parametro.Split('|');
            if (valorParametro.Length == 0)
                throw new ArgumentException("Informe as opções de parametros separados por '|' ex: h|host", "parametro");

            Parametro = valorParametro.OrderByDescending(p => p.Length).ToArray();
            Descricao = descricao;
            SetValue = setValue;
        }

        public override string ToString()
            => $"{string.Join("|", Parametro)} {Descricao}";
    }
}