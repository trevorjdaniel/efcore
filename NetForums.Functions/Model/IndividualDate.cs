using System;
using System.Collections.Generic;
using System.Text;

namespace NetForums.Functions.Model
{
    public class IndividualDate
    {
        public string ind_cst_key { get; set; }
        public DateTime? ind_add_date { get; set; }
        public DateTime? ind_change_date { get; set; }
        public DateTime? cst_add_date { get; set; }
        public DateTime? cst_change_date { get; set; }
        public DateTime? eml_add_date { get; set; }
        public string cst_recno { get; set; }
    }
}
