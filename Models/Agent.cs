using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OrderManagement.RazorWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Agents")]
    public class Agent
    {
        [Key]
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
