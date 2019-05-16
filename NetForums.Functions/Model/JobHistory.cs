using System;
using System.Collections.Generic;
using System.Text;

namespace NetForums.Functions.Model
{
    public class JobHistory
    {
        public string cst_key { get; set; }
        public string i02_local_government_flag { get; set; }
        public string i02_job_title { get; set; }
        public string i02_org_name { get; set; }
        public DateTime? i02_start_date { get; set; }
        public DateTime? i02_end_date { get; set; }
        public string i02_state { get; set; }
        public string i02_province { get; set; }
        public string i02_country { get; set; }
        public string cst_recno { get; set; }
    }
}
