using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dm.Common.Models
{
    public class Registration
    {
        public int UserID { get; set; }
        
        public int roleId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }

        public bool Status { get; set; }

        public int createdBy { get; set; }

        public DateTime? createdDate { get; set; }

       

    }
}
