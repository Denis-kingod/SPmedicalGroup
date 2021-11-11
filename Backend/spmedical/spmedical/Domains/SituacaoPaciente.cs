using System;
using System.Collections.Generic;

#nullable disable

namespace spmedical.Domains
{
    public partial class SituacaoPaciente
    {
        public SituacaoPaciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdSituacaoPaciente { get; set; }
        public string Avaliacao { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
