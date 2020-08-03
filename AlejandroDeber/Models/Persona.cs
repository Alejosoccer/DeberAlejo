using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroDeber.Models
{
    public class Persona
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        //Relcion de un a muchos.
        public List<Lavadora> Lavadoras { get; set; } = new List<Lavadora>();
        public List<Nevera> Neveras { get; set; } = new List<Nevera>();
        public List<Television> Televisiones { get; set; } = new List<Television>();
        public List<Microonda> Microondas { get; set; } = new List<Microonda>();


        [NotMapped]
        [Display(Name = "FotoPersona")]
        public string FotoBase64 { get; set; }

        //Instancias de las clases

        private Lavadora lavadora;
        public Lavadora Lavadora
        {
            get { return lavadora; }
            set
            {
                lavadora = value;
            }
        }


        private Nevera nevera;
        public Nevera Nevera
        {
            get { return nevera; }
            set
            {
                nevera = value;
            }
        }


        private Television television;
        public Television Television
        {
            get { return television; }
            set
            {
                television = value;
            }
        }


        private Microonda microonda;
        public Microonda Tablet
        {
            get { return microonda; }
            set
            {
                microonda = value;
            }
        }


        public Persona()
        {
        }
    }
}

