using System;
using System.Text;
using System.Collections.Generic;

namespace el.npd.backup
{
    public class Backup
    {
        private BackupConfig _config;

        public Backup Config(params string[] config)
        {
            _config = new BackupConfig(config);
            return this;
        }

        public void Run()
        {
            _config.VarDump();
#if DEBUG
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine($"{Environment.NewLine} pressione uma tecla para continuar...");
                Console.ReadKey(true);
            }
#endif        
        }
    }
}
