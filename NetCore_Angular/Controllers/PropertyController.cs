using Microsoft.AspNetCore.Mvc;
using NetCore_Angular.Models;
using NetCore_Angular.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NetCore_Angular.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PropertyController : ControllerBase
    {
        private readonly string dataSourceURL = "https://samplerspubcontent.blob.core.windows.net/public/properties.json";

        public IPropertyService PropertyService { get; }

        public PropertyController(IPropertyService propertyService)
        {
            PropertyService = propertyService;
        }

        [HttpGet]
        public async Task<List<PropertyDto>> GetProperties()
        {
            using (var httpClient = new HttpClient())
            {
                var propertyList = new PropertyList();
                propertyList = await httpClient.GetFromJsonAsync<PropertyList>(dataSourceURL);

                return PropertyService.GetPropertyListResponse(propertyList);
            };
        }

        [HttpPost]
        public async Task<int> SaveProperty(PropertyDto property)
        {
            return await PropertyService.SaveProperty(property);
        }
    }
}
