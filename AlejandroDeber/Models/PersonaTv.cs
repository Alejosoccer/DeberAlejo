using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroDeber.Models
{
    public class PersonaTv
    {
        [ForeignKey("Television")]
        public int TelevisionId { get; set; }
        public Television Televison { get; set; }

        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}
