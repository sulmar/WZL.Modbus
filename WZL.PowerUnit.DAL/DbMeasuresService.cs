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

            var endDate = criteria.EndDate.AddDays(1);

            using (var context = new PowerUnitContext())
            {
                // składnia za pomocą wyrażeń lambda
                 
                var measures = context.Measures
                    .Where(x => x.MeasureDate >= criteria.StartDate)
                    .Where(measure => measure.MeasureDate < endDate)
                    .OrderBy(measure => measure.MeasureDate)
                    .ToList();

                   

                // składnia podobna do SQL

                //var measures = (
                //                   from measure in context.Measures
                //                   where measure.MeasureDate >= criteria.StartDate
                //                      && measure.MeasureDate < endDate
                //                   orderby measure.MeasureDate
                //                   select measure
                //                )
                //               .ToList();
                              

                return measures;
            }
        }
    }
}
