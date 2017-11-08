using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace el.npd.backup
{
    public class ConfigSet : ICollection<Options>
    {
        private IList<Options> _lista = new List<Options>();

        public int Count => _lista.Count;

        public bool IsReadOnly => _lista.IsReadOnly;

        private IEnumerable<string> JoinPrefix(string[] args)
        {
            if (args == null) yield break;
            foreach (var a in args)
            {
                if (a.Length == 1)
                    yield return $"-{a}";
                else
                    yield return $"--{a}";
                yield return $"/{a}";
            }
        }

        // TODO
        // aceitar parametros que nao precisa ser informado um valor
        // exemplo h|help v|verbose d|debug
        internal void Parse(params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                string iParametro = null;
                var config = this.FirstOrDefault(cp => JoinPrefix(cp.Parametro).Any(pp => args[i].StartsWith(iParametro = pp)));
                if (config != null)
                {
                    if (args[i] == iParametro)
                    {
                        if (args.Length > i + 1)
                        {
                            i++;
                            config.SetValue(args[i]);
                        }
                    }
                    else if (args[i].StartsWith(iParametro, true, null))
                    {
                        var valor = args[i].Substring(iParametro.Length);
                        if (valor.StartsWith(':') || valor.StartsWith('='))
                            valor = valor.Substring(1);
                        config.SetValue(valor);
                    }
                }
                else throw new Exception($"parametro '{iParametro}' não é valido");
            }
        }

        public void Add(string descricao, string nome, Action<string> setValue)
            => _lista.Add(new Options(nome, descricao, setValue));

        IEnumerator IEnumerable.GetEnumerator() => _lista.GetEnumerator();
        public IEnumerator<Options> GetEnumerator() => _lista.GetEnumerator();
        public bool Contains(Options item) => _lista.Contains(item);

        public void Add(Options item) => throw new NotImplementedException();
        public void Clear() => throw new NotImplementedException();
        public void CopyTo(Options[] array, int arrayIndex) => throw new NotImplementedException();
        public bool Remove(Options item) => throw new NotImplementedException();
    }
}
