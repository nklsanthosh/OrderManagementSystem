using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrderManagementSystem.Models;

namespace OMS_Solution.Models
{

    public class CustomerDetails
    {

        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }

        public int? CustomerAge { get; set; }

        public string CustomerGender { get; set; }
        [Required]
        public int CustomerPhone { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public int UserRoleId { get; set; }
        // public string UserRoleName { get; set; }

        //public UserRole userRole { get; set; }


    }
}