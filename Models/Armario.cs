using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuardaVolume.Models
{
    public class Armario
    {
         [Key]
        public int ArmarioId { get; set; }

        public string Regiao {get; set;}
        
        public string PontoY {get; set;}

        public string PontoX {get; set;}
        

        public virtual ICollection<Compartimento> Compartimentos { get; set; }


    }
}