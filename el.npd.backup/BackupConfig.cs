using System;

namespace el.npd.backup
{
    public class BackupConfig
    {
        public string Servidor { get; set; }
        public string Porta { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string BancoDados { get; set; }

        public BackupConfig(params string[] args)
        {
            var config = new ConfigSet
            {
                { "nome ou ip do servidor", "h|host|servidor",          v => Servidor   = v },
                { "porta do servico",       "p|port|porta",             v => Porta      = v },
                { "nome do usuario",        "u|user|usuario",           v => Usuario    = v },
                { "senha do usuario",       "w|pass|password|senha",    v => Senha      = v },
                { "nome do banco de dados", "d|data|database|banco",    v => BancoDados = v }
            };

            config.Parse(args);
        }
    }
}
