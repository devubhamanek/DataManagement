using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Dm.Common.Models
{
    public class MasterMenu
    {
       
        public string parentCategoryId { get; set; }

        public string parentCategoryId_1 { get; set; }

        public string parentCategoryId_2 { get; set; }

        public string parentCategoryId_3 { get; set; }

        public int level { get; set; }
     
        public string name { get; set; }
    }
}
