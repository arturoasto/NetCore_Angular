using NetCore_Angular.Models;
using NetCore_Angular.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Angular.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _context;
        public PropertyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PropertyDto> GetPropertyListResponse(PropertyList propertyListFromJson)
        {
            return propertyListFromJson.Properties.Select(x => new PropertyDto
            {
                Address = x.Address.FullAddress,
                ListPrice = x.Financial?.ListPrice,
                MonthlyRent = x.Financial?.MonthlyRent,
                GrossYield = x.Financial?.GrossYield,
                YearBuilt = x.Physical?.YearBuilt
            }).ToList();
        }

        public async Task<int> SaveProperty(PropertyDto property)
        {
            Property newProperty = new()
            {
                Address = property.Address,
                GrossYield = property.GrossYield,
                ListPrice = property.ListPrice,
                MonthlyRent = property.MonthlyRent,
                YearBuilt = property.YearBuilt
            };

            _context.Properties.Add(newProperty);
            await _context.SaveChangesAsync();
            return newProperty.Id;
        }
    }
}
