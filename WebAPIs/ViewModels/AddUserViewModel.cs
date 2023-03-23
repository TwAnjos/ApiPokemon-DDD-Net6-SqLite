namespace WebAPIs.Models
{
    public class AddUserViewModel
    {
        public string email { get; set; }
        public string senha { get; set; }
        public string cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public int Idade { get; set; }
    }
}
