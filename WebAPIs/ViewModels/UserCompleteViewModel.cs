using Entities.Entities;
using Entities.Enums;

namespace WebAPIs.ViewModels
{
    public class UserCompleteViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public int? Idade { get; set; }
        public Genero? Genero { get; set; }
        public TipoUsuario? Tipo { get; set; }
        public DateTime DtNascimento { get; set; }
        public virtual TelefoneViewModel? Telefones { get; set; }
        public virtual UserEnderecoViewModel? User_Enderecos { get; set; }

    }
}
