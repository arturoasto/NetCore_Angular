using NetCore_Angular.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore_Angular.Services
{
    public interface IPropertyService
    {
        List<PropertyDto> GetPropertyListResponse(PropertyList propertyListFromJson);
        Task<int> SaveProperty(PropertyDto property);
    }
}
