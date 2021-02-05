using System.Collections.Generic;

namespace NetCore_Angular.Models
{
    public class PropertyList
    {
        public List<PropertyJson> Properties { get; set; }
    }

    public class PropertyJson
    {
        public Address Address { get; set; }
        public Physical Physical { get; set; }
        public Financial Financial { get; set; }
    }

    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipPlus4 { get; set; }

        public string FullAddress => $"{Address1} {Address2} {City} {Country} {District} {State} {Zip} {ZipPlus4}".Trim();
    }

    public class Financial
    {
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }

        private decimal grossYield;
        public string GrossYield
        {
            get
            {
                if (ListPrice == 0 || MonthlyRent == 0)
                    grossYield = 0;                 
                else
                    grossYield = MonthlyRent * 12 / ListPrice;
                
                return grossYield.ToString("P2");
            }            
        }
    }

    public class Physical
    {
        public int YearBuilt { get; set; }
    }
}
