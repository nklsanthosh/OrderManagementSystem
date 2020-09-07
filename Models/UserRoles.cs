using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.Models
{
    public class UserRoles
    {
        [Required]
        public int roleId { get; set; }

        [Required]
        public string name { get; set; }
    }
}