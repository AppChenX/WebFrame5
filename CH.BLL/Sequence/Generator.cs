using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.BLL.Sequence
{
    public abstract class Generator
    { 
        public abstract ISequence Creator();
    }
}
