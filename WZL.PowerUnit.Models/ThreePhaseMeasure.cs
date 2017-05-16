using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.PowerUnit.Models
{
    public class ThreePhaseMeasure : Base
    {
        public int Id { get; set; }

        public float Frequency { get; set; }

        public Phase L1 { get; set; }

        public Phase L2 { get; set; }

        public Phase L3 { get; set; }

    }
}
