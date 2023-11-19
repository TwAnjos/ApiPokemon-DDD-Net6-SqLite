using Entities.Entities;
using Newtonsoft.Json;

namespace TestProject_Api
{
    [TestClass]
    public class FileTest
    {
        public List<UserShawandpartners> UserList { get; set; }
        public Task<HttpResponseMessage> TaskResponse { get; set; }

        [TestMethod]
        public void FindUsersTestOk()
        {
            string url = "https://localhost:5000/api/Users";
            string query = "?q=tom";
            GetData(url, query);

            Assert.IsTrue(UserList.Any());
        }

        [TestMethod]
        public void FindUsersError()
        {
            string url = "https://localhost:5000/api/Users";
            string query = "?q=";
            GetData(url, query);

            Assert.IsTrue(TaskResponse.Result.ReasonPhrase == "Not Found");
        }

        private async void GetData(string url, string query)
        {
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Clear();
                TaskResponse = cliente.GetAsync(url + query);
                TaskResponse.Wait();

                if (TaskResponse.Result.IsSuccessStatusCode)
                {
                    var result = await TaskResponse.Result.Content.ReadAsStringAsync();
                    UserList = JsonConvert.DeserializeObject<List<UserShawandpartners>>(result);
                }
            }
        }
    }
}