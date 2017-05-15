using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.PowerUnit.Models
{
    public class MeasureSearchCriteria : Base
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MeasureSearchCriteria()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Now;
        }
    }
}
