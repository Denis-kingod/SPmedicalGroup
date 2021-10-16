using System;
using System.Collections.Generic;

#nullable disable

namespace SP_MedicalGroup.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clinicas = new HashSet<Clinica>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdEndereco { get; set; }
        public string NomeRua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public virtual ICollection<Clinica> Clinicas { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
