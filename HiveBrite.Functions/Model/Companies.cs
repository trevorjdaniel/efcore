using System;
using System.Collections.Generic;
using System.Text;

namespace HiveBrite.Functions.Model
{
    public class Companies
    {
        public List<CompanyProfileDetails> companies { get; set; }
    }

    public class CompanyProfileDetails
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
