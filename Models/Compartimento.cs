
using System;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
namespace GuardaVolume.Models
{
    public class Compartimento
    {
         [Key]
        public int CompartimentoId { get; set; }

        public int Numero {get; set;}

        public string Tamanho {get; set;}

        public bool Disponivel {get;set;}

        public bool Trancado {get;set;}
        
         [ForeignKey("Usuario")]
        public int? UsuarioId {get; set;}

        [ForeignKey("Armario")]
        public int? ArmarioId {get; set;}

        public virtual Armario Armario {get; set;}

    }
}