using MetaMeals.Web.Dtos;
using MetaMeals.Web.Service.IService;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using  static MetaMeals.Web.Utility.StaticData;
using Newtonsoft.Json;
using System.Text;
using System.Net;


namespace MetaMeals.Web.Service
{
    public class BaseService : IBaseService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory) {

            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient("MetaMeals.API");

                HttpRequestMessage message = new();

                message.Headers.Add("Accept", "application/json");

                HttpResponseMessage? apiResponse;

                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                {

                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                switch (requestDto.ApiType)
                {

                    case ApiType.POST:

                        message.Method = HttpMethod.Post;
                        break;

                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await httpClient.SendAsync(message);

                switch (apiResponse.StatusCode)
                {

                    case HttpStatusCode.NotFound:

                        return new()
                        {
                            IsSuccess = false,
                            Message = "Not Found"
                        };

                    case HttpStatusCode.Unauthorized:

                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unauthorized"
                        };

                    case HttpStatusCode.Forbidden:

                        return new()
                        {
                            IsSuccess = false,
                            Message = "Access Denied"
                        };

                    case HttpStatusCode.InternalServerError:

                        return new()
                        {
                            IsSuccess = false,
                            Message = "Internal server Error"
                        };

                    default:

                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;

                }

            }

            catch (Exception ex)
            {

                var dto = new ResponseDto
                {

                    IsSuccess = false,
                    Message = ex.Message.ToString(),
                };

                return dto;

            }

        } 
        

    }   
}
