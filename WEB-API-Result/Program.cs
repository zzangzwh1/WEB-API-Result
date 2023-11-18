using WEB_API_Result.Domain;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WEB_API_Result
{
    internal class Program
    {
        public static string BaseURL = @"https://localhost:7014";
        static async Task Main(string[] args)
        {
            GetNorthwindCustomers getCustomers = new GetNorthwindCustomers();
            Console.WriteLine("-----------");
            Console.WriteLine("[HttpGet] async Task GetNorthwindCustomers()");

            Console.WriteLine("-----------");
            await GetNorthwindCustomers();
            string customerID = "ALFKI";
            Console.WriteLine("-----------");
            Console.WriteLine("[HttpGet] async Task GetNorthwindCustomer()");

            Console.WriteLine("-----------");
            await GetNorthWindCustomer(customerID);

            Console.WriteLine("-----------");
            Console.WriteLine("[HttpGet]  static async Task IsPrime(int id)");

            Console.WriteLine("-----------");
            int primeNumber = 13;
            await IsPrime(primeNumber);

            Console.WriteLine("-----------");
            Console.WriteLine("[HttpGet] static async Task BinaryToDecimal(string id)");

            Console.WriteLine("-----------");
            string bToDec = "1110011";
            await BinaryToDecimal(bToDec);

            Console.WriteLine("-----------");
            Console.WriteLine("[HttpGet]  public static async Task DecimalToBinary(int id)");

            Console.WriteLine("-----------");
            int decToBinary = 115;
            await DecimalToBinary(decToBinary);
        }
        public static async Task GetNorthwindCustomers()
        {
            using (HttpClient httpApiClient = new HttpClient())
            {
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpApiClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpApiClient.BaseAddress = new Uri(BaseURL);

                HttpResponseMessage responseMessage = new HttpResponseMessage();
                string getWebApiContent = string.Empty;

                //let properties able to camelcase or pascal case
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;

                responseMessage = await httpApiClient.GetAsync("/api/GetCustomers");
                getWebApiContent = await responseMessage.Content.ReadAsStringAsync();

                List<GetNorthwindCustomers> datas = JsonSerializer.Deserialize<List<GetNorthwindCustomers>>(getWebApiContent, options);


                foreach (var data in datas)
                {
                    Console.WriteLine($"{data.CustomerID}\t{data.CompanyName}\t{data.ContactName}\t{data.ContactTitle}\t{data.Address}\t{data.City}\t {data.Region} \t{data.PostalCode}\t {data.Country}\t{data.Phone}\t{data.Fax}");
                }


            }
        }
        public static async Task GetNorthWindCustomer(string customerID)
        {
            using (HttpClient webApiClient = new HttpClient())
            {
                webApiClient.BaseAddress = new Uri(BaseURL);
                webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                HttpResponseMessage responeMessage = await webApiClient.GetAsync($"/api/GetCustomers/{customerID}");

                if (responeMessage.IsSuccessStatusCode)
                {
                    GetNorthwindCustomers data = new GetNorthwindCustomers();
                    string getWebApiContent = await responeMessage.Content.ReadAsStringAsync();
                    data = JsonSerializer.Deserialize<GetNorthwindCustomers>(getWebApiContent, options);
                    Console.WriteLine($"{data.CustomerID}\t{data.CompanyName}\t{data.ContactName}\t{data.ContactTitle}\t{data.Address}\t{data.City}\t {data.Region} \t{data.PostalCode}\t {data.Country}\t{data.Phone}\t{data.Fax}");
                }
                else
                {
                    Console.WriteLine("API Request FAILED!");
                }

            }
        }
        public static async Task IsPrime(int id)
        {
            using (HttpClient webApiClient = new HttpClient())
            {
                webApiClient.BaseAddress = new Uri(BaseURL);
                webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                HttpResponseMessage responeMessage = await webApiClient.GetAsync($"/api/Prime/{id}");

                if (responeMessage.IsSuccessStatusCode)
                {

                    string getWebApiContent = await responeMessage.Content.ReadAsStringAsync();
                    bool isPrime = JsonSerializer.Deserialize<bool>(getWebApiContent, options);

                    Console.WriteLine($"{id} is Prime Number :  {isPrime}");
                }
                else
                {
                    Console.WriteLine("API Request FAILED!");
                }

            }

        }
        public static async Task BinaryToDecimal(string id)
        {
            using (HttpClient webApiClient = new HttpClient())
            {
                webApiClient.BaseAddress = new Uri(BaseURL);
                webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                HttpResponseMessage responeMessage = await webApiClient.GetAsync($"/api/BinaryToDecimal/{id}");

                if (responeMessage.IsSuccessStatusCode)
                {

                    string getWebApiContent = await responeMessage.Content.ReadAsStringAsync();
                    int Decimal = JsonSerializer.Deserialize<int>(getWebApiContent, options);

                    Console.WriteLine($"Binary : {id}  Convert To Decimal:  {Decimal}");
                }
                else
                {
                    Console.WriteLine("API Request FAILED!");
                }

            }

        }
        public static async Task DecimalToBinary(int id)
        {
            using (HttpClient webApiClient = new HttpClient())
            {
                webApiClient.BaseAddress = new Uri(BaseURL);
                webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                HttpResponseMessage responeMessage = await webApiClient.GetAsync($"/api/DecimalToBinary/{id}");

                if (responeMessage.IsSuccessStatusCode)
                {

                    string getWebApiContent = await responeMessage.Content.ReadAsStringAsync();
                    string binary = JsonSerializer.Deserialize<string>(getWebApiContent, options);

                    Console.WriteLine($"Decimal : {id}  Convert To Binary:  {binary}");
                }
                else
                {
                    Console.WriteLine("API Request FAILED!");
                }

            }

        }
    }
}