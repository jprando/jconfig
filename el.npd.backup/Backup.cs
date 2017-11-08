using System;
using System.Collections.Generic;
using System.Text;

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

        }
    }
}
