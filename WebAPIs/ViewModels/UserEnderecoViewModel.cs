namespace WebAPIs.ViewModels
{
    public class UserEnderecoViewModel
    {
        public int Id { get; set; }

        public string Endereco { get; set; }

        public string CEP { get; set; }

        public string Pais { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string Municipio { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }
    }
}