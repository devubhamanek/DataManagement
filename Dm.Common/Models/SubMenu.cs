using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dm.Common.Models
{
   public class SubMenu
    {
        public int Id { get; set; }
        
        public string name { get; set; }

        public SelectList listOfCategory { get; set; }

    }
}
