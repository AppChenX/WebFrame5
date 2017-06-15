using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.BLL.Sequence
{
    public class GuidGenerator : Generator
    {
        public override ISequence Creator()
        {


            return new SequenceGuid();

        }
    }
}
