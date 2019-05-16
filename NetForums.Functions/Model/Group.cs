using System;
using System.Collections.Generic;
using System.Text;

namespace NetForums.Functions.Model
{
    public class Group
    {
        public string group_name { get; set; }
        public string description { get; set; }
        public string group_type { get; set; }
        public string position { get; set; }
        public DateTime? end_date { get; set; }
        public string cst_recno { get; set; }
    }
}
