using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MheanMaa.Settings
{
    public class DBSettings : IDBSettings
    {
        public string ConnectionString { get; set; }
        public string DBName { get; set; }
        public string DogsColName { get; set; }
        public string DonatesColName { get; set; }
    }

    public interface IDBSettings
    {
        public string ConnectionString { get; set; }
        public string DBName { get; set; }
        public string DogsColName { get; set; }
        public string DonatesColName { get; set; }
        
    }
}
