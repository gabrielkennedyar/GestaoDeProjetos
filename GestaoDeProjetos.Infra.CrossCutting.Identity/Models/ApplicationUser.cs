using Microsoft.AspNetCore.Identity;
using System;

namespace GestaoDeProjetos.Infra.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            // Inicie aqui os campos de AspNetUsers customizados que são obrigatórios para criar um Usuário na base
            DataCadastro = DateTime.Now;
        }

        public DateTime DataCadastro { get; private set; }

    }
}
