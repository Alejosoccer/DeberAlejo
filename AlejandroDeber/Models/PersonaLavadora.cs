using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroDeber.Models
{
    public class PersonaLavadora
    {
        //Romper tablas de lavadora

        [ForeignKey("Lavadora")]
        public int LavadoraId { get; set; }
        public Lavadora Lavadora { get; set; }

        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}
