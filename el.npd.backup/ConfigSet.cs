using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace el.npd.backup
{
    public class ConfigSet : ICollection<Options>
    {
        private ICollection<Options> _lista = new Collection<Options>();

        internal void Parse(params string[] args)
        {
            Dictionary<string, string> parametros = ObterParametros(args);
            foreach (KeyValuePair<string, string> item in parametros)
            {
                var config = _lista.FirstOrDefault(cs => cs.Parametro.Contains(item.Key));
                if (config != null)
                    config.SetValue(item.Value);
                else throw new Exception($"O parametro '{item.Key}' não é valido");
            }
        }

        private static Dictionary<string, string> ObterParametros(string[] args)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            for (int i = 0; i < args.Length; i++)
            {
                string key = null, value = null;
                if (args[i].StartsWith("--") && args[i].Length > 3)
                    (i, key, value) = GerarParametro(args, i);
                else if (args[i].StartsWith('-') && args[i].Length > 1 && !args[i].StartsWith("--"))
                    (i, key, value) = GerarParametroSimples(args, i);
                else throw new Exception($"A opção informada não é um parametro: {args[i]}");
                if (!parametros.ContainsKey(key))
                    parametros.Add(key, value);
                else throw new Exception($"Mesmo parametro informado 2x: {key}");
            }
            return parametros;
        }

        private static Func<string, bool> eOutroParametro = s =>
            (s.Length > 3 && s.StartsWith("--")) ||
            (s.Length > 1 && s.StartsWith('-') && !s.StartsWith("--"));

        private static (int i, string key, string value) GerarParametro(string[] args, int i)
        {
            string value = null;
            string key = args[i].Substring(2);
            if (args.Length > i + 1)
                if (!eOutroParametro(args[++i]))
                    value = args[i];
                else i--;
            return (i, key, value);
        }

        private static (int i, string key, string value) GerarParametroSimples(string[] args, int i)
        {
            string value = null;
            string key = args[i].Substring(1, 1);
            if (args[i].Length > 2)
                value = args[i].Substring(2);
            else if (args.Length > i + 1)
                if (!eOutroParametro(args[++i]))
                    value = args[i];
                else i--;
            return (i, key, value);
        }

        public void Add(string descricao, string nome, Action<string> setValue)
            => _lista.Add(new Options(nome, descricao, setValue));

        #region ligacao
        public int Count => _lista.Count;
        public bool IsReadOnly => _lista.IsReadOnly;
        IEnumerator IEnumerable.GetEnumerator() => _lista.GetEnumerator();
        public IEnumerator<Options> GetEnumerator() => _lista.GetEnumerator();
        public bool Contains(Options item) => _lista.Contains(item);
        #endregion

        #region nao implementado
        public void Add(Options item) => throw new NotImplementedException();
        public void Clear() => throw new NotImplementedException();
        public void CopyTo(Options[] array, int arrayIndex) => throw new NotImplementedException();
        public bool Remove(Options item) => throw new NotImplementedException();
        #endregion
    }
}
