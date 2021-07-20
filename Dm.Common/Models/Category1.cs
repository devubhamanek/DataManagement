using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Dm.Common.Models
{
    public class Category1
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Select a mainCategory")]
        public string mainCategory { get; set; }
        [Required(ErrorMessage = "Select a subCategory1")]
        public string subCategory1 { get; set; }
        [Required]
        public string name { get; set; }

        public SelectList listOfCategory { get; set; }

        public SelectList listOfCategory1 { get; set; }
    }


}
