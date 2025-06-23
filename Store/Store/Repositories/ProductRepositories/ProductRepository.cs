global using Store.Interfaces.ProductInterfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Store.DTO;
using System.Net.Http.Headers;
using System.Text;

namespace Store.Repositories.ProductRepositories
{
    public class ProductRepository : IProduct
    {
        private readonly IHttpClientFactory httpClient;
        private readonly AppSettings appSettings;
        public ProductRepository(IHttpClientFactory httpClient, IOptions<AppSettings> appSettings)
        {

            this.httpClient = httpClient;
            this.appSettings = appSettings.Value;
        }
        public async Task<ResponseDetail> AddProduct(ProductCreateDTO product)
        {
            var response = new ResponseDetail();
            try
            {
                //Create your client
                var client = httpClient.CreateClient();
                //serialize the object to json
                var jsonBody = JsonConvert.SerializeObject(product);
              
                var stringContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var url = $"{appSettings.ThirdPartyBaseUrl}{appSettings.AddProductUrl}";

                //I save the username and password to my appsettings.json...
                var username = appSettings.Username;
                var password = appSettings.Password;

                //I had to do it this way because i used basic auth to send my requests initially on postman and basic auth converts
                // Your credentials to base 64 string and appends it to the basicword
                //That's what is happening down here...
                var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));

                //Below is where i added the authtoken generated to the Auth header...The line 44 would have worked too but 43 is better
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
                //client.DefaultRequestHeaders.Add("Authorization", $"Basic {authToken}");

                var request = await client.PostAsync(url, stringContent);
                if (!request.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
                var responseContent = await request.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<ResponseDetail>(responseContent);
                if(jsonResponse == null || jsonResponse.IsSuccessful == false)
                {
                    throw new JsonSerializationException(responseContent);
                }
                response = jsonResponse;
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
