using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZL.PowerUnit.Models;

namespace WZL.PowerUnit.DAL
{
    public class PowerUnitContext : DbContext
    {

        // Klasy, które mają być utrwalane w bazie danych
        public DbSet<Measure> Measures { get; set; }

        // W konstruktorze podajemy nazwę wpisu 
        // w pliku konfiguracyjnym w sekcji connection strings
        public PowerUnitContext()
            : base("PowerUnitConnection")
        {

        }
    }
}
