using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vets.Models
{
    public class Donos
    {
        public Donos()
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
        public virtual ICollection<Animais> ListaDeAnimais { get; set; }
    }
}