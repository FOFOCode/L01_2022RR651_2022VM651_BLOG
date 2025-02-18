using L01_2022RR651_2022VM651.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L01_2022RR651_2022VM651.Models
{
    public class roles
    {
        [Key]
        public int rolId { get; set; }
        public string? rol { get; set; }
    }
}
