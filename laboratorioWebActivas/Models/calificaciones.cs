using L01_2022RR651_2022VM651.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L01_2022RR651_2022VM651.Models
{
    public class calificaciones
    {
        [Key]
        public int calificacionId { get; set; }
        public int publicacionId { get; set; }
        public int usuarioId { get; set; }
        public string? calificacion { get; set; }
    }
}
