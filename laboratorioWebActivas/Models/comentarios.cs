using L01_2022RR651_2022VM651.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L01_2022RR651_2022VM651.Models
{
    public class comentarios
    {
        [Key]
        public int cometarioId { get; set; }
        public int publicacionId { get; set; }
        public string? comentario { get; set; }
        public int usuarioId { get; set; }
    }
}
