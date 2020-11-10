using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage ="Favor de llenar esto joputa")]
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Int16 Edad { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
