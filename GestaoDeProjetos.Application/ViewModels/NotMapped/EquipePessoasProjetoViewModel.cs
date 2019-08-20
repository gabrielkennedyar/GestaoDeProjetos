using System;
using System.ComponentModel.DataAnnotations;


namespace GestaoDeProjetos.Application.ViewModels.NotMapped
{
    public class EquipePessoasProjetoViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da Equipe")]
        [Display(Name = "Nome da Equipe")]
        public string Nome { get; set; }

        [Display(Name = "Coordenador")]
        public string CoordenadorId { get; set; }

        [Required(ErrorMessage = "Informe a descrição do projeto")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Integrantes")]
        public string[] IntegrantesId { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime DataCadastro { get; set; }
    }
}
