using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vets.Models
{
    public class Veterinarios
    {

        public Veterinarios()
        {
            Consultas = new HashSet<Consultas>();
        }

        [Key] //força a criação de uma chave primária
        public int VeterinarioID { get; set; }


        [Required] // é obrigatório preencher o atributo 'nome'
        [StringLength(30)] // o tamanho máximo é 30
        public string Nome { get; set; } //atributo 'nome'

        [StringLength(50)]
        public string Rua { get; set; }

        [StringLength(10)]
        public string NumPorta { get; set; }

        [StringLength(10)]
        public string Andar { get; set; }

        [StringLength(30)]
        public string CodPostal { get; set; }

        [StringLength(9)]
        public string NIF { get; set; }

        //formata o tipo de dados na BD
        [Column(TypeName = "date")]
        public DateTime? DataEntradaClinica { get; set; } // o ? torna o atributo de preenchimento facultativo

        [Required]
        [StringLength(30)]
        public string NumCedulaProf { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataInscOrdem { get; set; }

        [StringLength(50)]
        public string Faculdade { get; set; }

        public virtual ICollection<Consultas> Consultas { get; set; }


    }
}