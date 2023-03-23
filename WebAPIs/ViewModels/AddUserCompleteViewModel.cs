using Entities.Entities;
using Entities.Enums;

namespace WebAPIs.ViewModels
{
    public class AddUserCompleteViewModel
    {
        public string Email { get; set; }
        public string senha { get; set; }
        public string? CPF { get; set; }
        public int? Idade { get; set; }
        public string? RG { get; set; }
        public char? Genero { get; set; }
        public TipoUsuario? Tipo { get; set; }
        public DateTime DtNascimento { get; set; }
        public virtual ICollection<Telefone>? Telefones { get; set; }
        public virtual ICollection<UserEndereco>? User_Enderecos { get; set; }

    }
}
