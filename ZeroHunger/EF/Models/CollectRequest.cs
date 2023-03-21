using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class CollectRequest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } = "Not Assigned";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime ExpireAt { get; set; }

        [ForeignKey("Restaurants")]
        public int Restaurant_id { get; set; }

        [ForeignKey("Employees")]
        public int? Employee_id { get; set; }

        public virtual Restaurant Restaurants { get; set; }
        public virtual Employee Employees { get; set; }
    }
}