using System;
using System.Collections.Generic;
using System.Text;
using ICMASync.Data.Context;

namespace ICMASync.Data
{
    public interface IBaseContextFactory
    {
        BaseContext Create();
    }
}
