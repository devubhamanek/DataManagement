using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Dm.Common.Models
{
    public class Category
    {

        public int Id { get; set; }

        public int parentCategoryId { get; set; }
        [Required(ErrorMessage = "Select a mainCategory")]
        public string mainCategory { get; set; }
        [Required]
        public string name { get; set; }

        public SelectList listOfCategory { get; set; }
    }
}
