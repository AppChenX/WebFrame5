using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.Model
{
    public interface   ISequenceContext
    {

       
        
        /// <summary>
        /// 
        /// </summary>
        
        string CFormat
        {
            get;
            set;
        }
      
        int? NStep
        {
            get;
            set;
        } 
       string CPadchar
        {
            get;
            set;
        }
       
         int? CPadlen
        {
            get;
            set;
        }
      
   string CFormatType
        {
            get;
            set;
        }
       
      string CPrechar
        {
            get;
            set;
        }
        

    }
}
