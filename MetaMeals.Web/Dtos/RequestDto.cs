using static MetaMeals.Web.Utility.StaticData;
using Microsoft.AspNetCore.Mvc;

namespace MetaMeals.Web.Dtos
{
    public class RequestDto
    {

        public ApiType ApiType { get; set; } = ApiType.GET;

        public Object Data { get; set; }

        public String Url { get; set; }

        public String AccessToken { get; set; }
    }
}
