using System;
using System.Collections.Generic;
using System.Text;

namespace HiveBrite.Functions.Model
{
    public class CreateInterest
    {
        public UserInterests user { get; set; }
    }

    public class UserInterests
    {
        public List<User_Custom_Attributes> custom_attributes { get; set; } = new List<User_Custom_Attributes>();
    }

    public class User_Custom_Attributes
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<string> value { get; set; }
        public string type { get; set; }
    }

}
