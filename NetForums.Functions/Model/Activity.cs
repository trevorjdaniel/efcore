using System;
using System.Collections.Generic;
using System.Text;

namespace NetForums.Functions.Model
{
    public class Activity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Committee { get; set; }
        public string Period { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Recno { get; set; }
    }
}
