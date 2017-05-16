using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZL.PowerUnit.Models;
using WZL.Services;

namespace WZL.PowerUnit.DAL
{
    public class DbThreePhaseMeasuresService : IThreePhaseMeasuresService
    {
        public void Add(ThreePhaseMeasure measure)
        {
            using (var context = new PowerUnitContext())
            {
                context.ThreePhaseMeasures.Add(measure);

                context.SaveChanges();
            }
        }
    }
}
