using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Blob : Creature
    {
        public Blob() { }

        public Blob(IGene isBlue)
            : base(new Dictionary<string, IGene> { { "isBlue", isBlue } })
        {

        }

        public bool IsBlue { get { return GeneActive("isBlue", true); } }
    }
}
