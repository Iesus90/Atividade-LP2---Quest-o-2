using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Atividade1
{
    public class Cliente
    {
        private int idCliente;
        public string Nome { get; set; }

        [Key]
        public int IdCliente {
            get { return idCliente; }
            set { idCliente = value; }
        }
    }

    
}
