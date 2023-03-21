using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<CollectRequest> CollectRequests { get; set; }
        public Employee()
        {
            CollectRequests = new List<CollectRequest>();
        }
    }
}