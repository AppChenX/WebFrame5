using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;
namespace CH.Model
{
    
    public class SysMenuEx2:SysMenu
    {
        [Column(Name = "Checked", SkipOnInsert = true, SkipOnUpdate = true)]
        public bool Checked
        {
            get;
            set;
        }
        [Column(Name ="NCHECK",SkipOnInsert =true,SkipOnUpdate =true)]
        public bool NCheck
        {
            get;
            set;
        }  
    }
}
