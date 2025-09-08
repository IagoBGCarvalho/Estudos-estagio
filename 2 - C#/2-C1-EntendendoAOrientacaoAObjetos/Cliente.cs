using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_C1_EntendendoAOrientacaoAObjetos
{
    public class Cliente
    {
        // É possível usar o template do visual studio para criar propriedades automaticamente utilizando: "prop" + tab
        public string Nome { get; set; } = "";
        public string CPF { get; set; } = "";
        public string Profissao { get; set; } = "";
    }
}
