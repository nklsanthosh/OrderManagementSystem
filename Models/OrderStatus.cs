using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OMS_Solution.Models
{

    public class OrderStatus
    {

        public int statusId { get; set; }
        public string status { get; set; }
    }
}