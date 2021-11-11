using System;
using System.Collections.Generic;

#nullable disable

namespace spmedical.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }
        public int? IdEndereco { get; set; }
        public string NomeClinica { get; set; }
        public string Cnpj { get; set; }
        public string RazaoVisita { get; set; }
        public TimeSpan ClinicaAberta { get; set; }
        public TimeSpan ClinicaFechada { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
