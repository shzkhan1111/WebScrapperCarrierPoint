using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperCarrierPoint
{
    internal class ScraperConfig
    {
        public int MinWeight { get; set; }
        public int MaxWeight { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public int DeliveryDateOffset { get; set; }
        public int MinMileage { get; set; }
        public int MaxMileage { get; set; }
        public string OriginCity { get; set; }
        public string OriginState { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationState { get; set; }
    }
}
