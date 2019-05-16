using System;
using System.Collections.Generic;
using System.Text;

namespace HiveBrite.Functions.Model
{
    public class CreateWrapper
    {
        public bool Success { get; set; }
        public ErrorObject ErrorObject { get; set; } = new ErrorObject();
    }

    public class ErrorObject
    {
        public int status { get; set; }
        public string errors { get; set; }
    }

}
