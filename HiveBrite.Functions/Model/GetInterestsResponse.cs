using System;
using System.Collections.Generic;
using System.Text;

namespace HiveBrite.Functions.Model
{
    public class GetInterestsResponse
    {
        public List<Customizable_Attributes> customizable_attributes { get; set; }
    }

    public class Customizable_Attributes
    {
        public int id { get; set; }
        public object customizable_id { get; set; }
        public string type { get; set; }
        public string customizable_type { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public string tooltip { get; set; }
        public string placeholder { get; set; }
        public bool multi { get; set; }
        public object text_size { get; set; }
        public string visibility { get; set; }
        public bool user_editable { get; set; }
        public bool required { get; set; }
        public List<string> options { get; set; }
        public object json_options { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}
