using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.CSharp.Models
{
    // Klasa generyczna
    public class Printer<TItem>
    {
        public void Print(TItem item)
        {
            Console.WriteLine(item);
        }

        public TItem Get()
        {
            return default(TItem);
        }
    }
}
