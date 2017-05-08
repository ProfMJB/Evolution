using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public interface IGene
    {
        IGene Combine(IGene[] genes);
    }
}
