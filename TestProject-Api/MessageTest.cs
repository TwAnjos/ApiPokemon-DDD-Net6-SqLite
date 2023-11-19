using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace TestProject_Api
{
    [TestClass]
    public class MessageTest
    {
        public static string Token { get; set; }

        [TestMethod]
        public void MessageTestGetALL()
        {
            var result = CallApi("https://localhost:5000/api/GetAll").Result;

            var listMessage = JsonConvert.DeserializeObject<Message[]>(result).ToList();

            Assert.IsTrue(listMessage.Any());
        }

        public void GetToken()
        {
            string urlApiGetToken = "https://localhost:5000/api/GerarTokenAPI";

            using (var client = new HttpClient())
            {
                string login = "thiago@thiago.com";
                string senha = "@Tt123";

                var data = new
                {
                    email = login,
                    senha = senha,
                    cpf = "string"
                };

                string JsonObjet = JsonConvert.SerializeObject(data);
                var content = new StringContent(JsonObjet, Encoding.UTF8, "application/json");
                var result = client.PostAsync(urlApiGetToken, content);
                result.Wait();

                if (result.Result.IsSuccessStatusCode)
                {
                    var tokenJson = result.Result.Content.ReadAsStringAsync();
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

        public async Task<string> CallApi(string url, object dados = null)
        {
            ///string JsonObjeto = dados != null ? JsonConvert.SerializeObject(dados) : "";
            //var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");
            GetToken();

            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var cliente = new HttpClient())
                {
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    //var response = cliente.PostAsync(url, content);
                    Task<HttpResponseMessage> response = cliente.GetAsync(url);
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var objReturned = await response.Result.Content.ReadAsStringAsync();
                        return objReturned;
                    }
                }
            }
            return "Token = IsNullOrWhiteSpace";
        }
    }
}