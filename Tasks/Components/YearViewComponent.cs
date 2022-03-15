using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.Components
{
    public class YearViewComponent
    {
        public string Invoke() {
            return DateTime.Now.Year.ToString(); ;
        }
    }
}
