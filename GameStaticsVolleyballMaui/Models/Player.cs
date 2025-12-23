using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStaticsVolleyballMaui.Models;
using GameStatisticsVolleball.Models;


namespace GameStaticsVolleyballMaui.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string FullName { get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Range(1, 99)]
        public int Number { get; set; }
        [Required]
        [Range(0, 250)]
        public int Height { get; set; }
        [Required]
        [Range(0, 150)]
        public int Width { get; set; }

        [Required]
        public int PositionId { get; set; }
        [Required]
        public int TeamId { get; set; }
        // Навигационные св-ва
        public Position Position { get; set; } = null!;
        public Team Team { get; set; } = null!;
    }
}
