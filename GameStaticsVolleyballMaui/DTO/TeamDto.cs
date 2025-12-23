using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStaticsVolleyballMaui.DTO
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CoachName { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
