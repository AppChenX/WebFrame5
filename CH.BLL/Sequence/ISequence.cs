using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.BLL.Sequence
{
    public interface ISequence
    {

        object Next(string m="N");
    }
}
