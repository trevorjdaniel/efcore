using System;
using System.Collections.Generic;
using System.Text;

namespace HiveBrite.Functions.Model
{
    public class HBAuthData
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public double expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public double created_at { get; set; }
    }
}
