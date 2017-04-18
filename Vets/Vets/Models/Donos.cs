using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vets.Models
{
    public class Donos
    {
        /*public Donos()
        {
            //construtor da classe que vai ser utilizado
            //para inicializar o atributo "ListaDeAnimais"
            ListaDeAnimais = new HashSet<Animais>();
        }
        public int DonosID { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        //relacionar os "donos" com os "animais"
        //1 dono tem muitos animais
        public virtual ICollection<Animais> ListaDeAnimais { get; set; } */


        // vai representar os dados da tabela dos DONOS

        // criar o construtor desta classe
        // e carregar a lista de Animais
        public Donos()
        {
            ListaDeAnimais = new HashSet<Animais>();
        }


        [Key]
        public int DonoID { get; set; }

        [Required]
        public string Nome { set; get; }

        [Required]
        public string NIF { get; set; }

        // especificar que um DONO tem muitos ANIMAIS
        public ICollection<Animais> ListaDeAnimais { get; set; }


    }
}