using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using Temp_Converter.API.DTO;
using Temp_Converter.API.Interface;

namespace Temp_Converter.API.Repository
{
    public class AccountRepository : IAccount
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        public AccountRepository(IConfiguration configuration, HttpClient httpClient)
        {
            this.configuration = configuration;
            this.httpClient = httpClient;
        }

        private StringContent SerializeRequest(AccountCreationDTO newAccount)
        {
            var json = JsonConvert.SerializeObject(newAccount);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<HttpResponseMessage> SendRequest(StringContent requestBody)
        {
            var url = $"{configuration["VotingSystem"]}";
            return await httpClient.PostAsync(url, requestBody);
        }

        public async Task<string> CreateAccount(AccountCreationDTO newAccount)
        {
            try
            {
                var requestBody = SerializeRequest(newAccount);
                var request = await SendRequest(requestBody);
                var response = await request.Content.ReadAsStringAsync();

                if (request.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    throw new HttpRequestException($"Request failed with status code: {request.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                throw;
            }
        }
    }
}
