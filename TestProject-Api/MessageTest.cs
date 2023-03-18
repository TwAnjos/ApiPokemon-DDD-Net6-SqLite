
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TestProject_Api
{
    [TestClass]
    public class MessageTest
    {
        public static string Token { get; set;}

        [TestMethod]
        public void TestMethod1()
        {
            var result = ChamaApiPost("https://localhost:7171/api/GetAll").Result;

            var listaMessage = JsonConvert.DeserializeObject<Message[]>(result).ToList();

            Assert.IsTrue(listaMessage.Any());
        }

        public void GetToken()
        {
            string urlApiGeraToken = "https://localhost:7171/api/CriarTokenIdentity";

            using(var cliente = new HttpClient())
            {
                string login = "teste@teste.com";
                string senha = "@Teste1234";

                var dados = new
                {
                    email = login,
                    senha = senha,
                    cpf = "string"
                };

                string JsonObjeto = JsonConvert.SerializeObject(dados);
                var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");
                var resultado = cliente.PostAsync(urlApiGeraToken, content);
                resultado.Wait();

                if (resultado.Result.IsSuccessStatusCode)
                {
                    var tokenJson = resultado.Result.Content.ReadAsStringAsync();
                    Token = JsonConvert.DeserializeObject(tokenJson.Result).ToString();
                }
            }
            
        }

        public string ChamaApiGet(string url)
        {
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var response = cliente.GetStringAsync(url);
                response.Wait();
                return response.Result;
            }
        }

        public async Task<string> ChamaApiPost(string url, object dados = null)
        {
            string JsonObjeto = dados != null ? JsonConvert.SerializeObject(dados) : "";
            var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");
            GetToken();

            if(!string.IsNullOrWhiteSpace(Token))
            {
                using( var cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = cliente.PostAsync(url, content);
                    response.Wait();

                    if(response.Result.IsSuccessStatusCode)
                    {
                        var retorno = await response.Result.Content.ReadAsStringAsync();
                        return retorno;
                    }
                }

            }
            return "Token = IsNullOrWhiteSpace";
        }
    }
}