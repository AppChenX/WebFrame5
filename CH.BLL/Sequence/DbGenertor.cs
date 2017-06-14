using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.BLL.Sequence
{
    public class DbGenertor : Generator
    {
        public   override ISequence Creator()
        {


            return new SequenceTimeDbLoop();
           
        }
    }
}
