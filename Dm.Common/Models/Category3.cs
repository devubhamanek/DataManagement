using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dm.Common.Models
{
    public class Category3
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select a mainCategory")]
        public string mainCategory { get; set; }
        [Required(ErrorMessage = "Select a subCategory1")]
        public string subCategory1 { get; set; }
        [Required(ErrorMessage = "Select a subCategory2")]
        public string subCategory2 { get; set; }
        [Required(ErrorMessage = "Select a subCategory3")]
        public string subCategory3 { get; set; }
      
        public string name { get; set; }

        public string InOut { get; set; }

        public SelectList listOfCategory { get; set; }

        public SelectList listOfCategory1 { get; set; }

        public SelectList listOfCategory2 { get; set; }

        public SelectList listOfCategory3 { get; set; }
    }
}
