using System;

namespace Tasks.Components
{
    public class YearViewComponent
    {
        public string Invoke() {
            return DateTime.Now.Year.ToString(); ;
        }
    }
}
