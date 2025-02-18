using L01_2022RR651_2022VM651.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L01_2022RR651_2022VM651.Models
{
    public class publicaciones
    {
        [Key]
        public int publicacionId { get; set; }
        public string? titulo { get; set; }
        public string? descripcion{ get; set; }
        public int usuarioId { get; set; }
    }
}
