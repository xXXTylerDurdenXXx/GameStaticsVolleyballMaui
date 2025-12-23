using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStaticsVolleyballMaui.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;
        [StringLength(200)]

        public string? Description { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
