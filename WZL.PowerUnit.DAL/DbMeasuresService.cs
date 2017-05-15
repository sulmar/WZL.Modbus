using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZL.PowerUnit.Models;
using WZL.Services;

namespace WZL.PowerUnit.DAL
{
    public class DbMeasuresService : IMeasuresService
    {
        public void Add(Measure measure)
        {
            // Utworzenie instancji kontekstu
            using (var context = new PowerUnitContext())
            {
                // Dodanie do kontekstu
                context.Measures.Add(measure);

                // Zapis do bazy danych
                context.SaveChanges();
            }
        }

        public List<Measure> Get(MeasureSearchCriteria criteria)
        {
            using (var context = new PowerUnitContext())
            {
                var measures = context.Measures.ToList();

                return measures;
            }
        }
    }
}
