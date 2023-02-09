using System.Text;
using Fluxor;
using Newtonsoft.Json;

namespace SalesOrderApp.Services
{
    public class OrderHttpService: IOrderHttpService
    {
        private string _baseAddress = "https://localhost:7215/";
        private readonly IDispatcher _dispatcher;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public OrderHttpService(IHttpClientFactory httpClientFactory, IDispatcher dispatcher, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _dispatcher = dispatcher;
            _configuration = configuration;
        }

        public async Task<bool> AddAsync(Order order)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string jsonInString = JsonConvert.SerializeObject(order);
            var stringContent = new StringContent(jsonInString, Encoding.UTF8, "application/json");
            try
            {
                string url = string.Format("{0}/order/add-order", _configuration["ApiBasePath"]);  
                var httpResponseMessage = await httpClient.PostAsync(url, stringContent);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    _dispatcher.Dispatch(new OrderSaveSuccessAction());
                    return true;
                }
                var data = await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return false;
        }
        public async Task<bool> EditAsync(Order order)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string jsonInString = JsonConvert.SerializeObject(order);
            var stringContent = new StringContent(jsonInString, Encoding.UTF8, "application/json");
            string url = string.Format("{0}/order/update-order/{1}", _configuration["ApiBasePath"], order.Id);
            var httpResponseMessage = await httpClient.PutAsync(url, stringContent);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                _dispatcher.Dispatch(new OrderSaveSuccessAction());
                return true;
            }
            return false;
        }
        public async Task<bool> GetAsync(int? id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string url = string.Format("{0}/order/get-order/{1}", _configuration["ApiBasePath"], id);
            var httpResponseMessage = await httpClient.GetAsync(url);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                 Order order = JsonConvert.DeserializeObject<Order>(await httpResponseMessage.Content.ReadAsStringAsync());
                _dispatcher.Dispatch(new GetOrderAction(order));
                return true;
            }
            return false;
        }

        public async Task<bool> GetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            string url = string.Format("{0}/order/get-orders", _configuration["ApiBasePath"]);
            var httpResponseMessage = await httpClient.GetAsync(url);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                IEnumerable<Order> order = JsonConvert.DeserializeObject<IEnumerable<Order>>(await httpResponseMessage.Content.ReadAsStringAsync());
                _dispatcher.Dispatch(new GetOrdersAction(order.ToList()));
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string url = string.Format("{0}/order/remove-order/{1}", _configuration["ApiBasePath"], id);
            var httpResponseMessage = await httpClient.DeleteAsync(url);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}

