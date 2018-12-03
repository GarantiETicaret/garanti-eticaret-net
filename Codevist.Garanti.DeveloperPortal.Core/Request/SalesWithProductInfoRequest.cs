using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.Request
{
    [XmlRoot("GVPSRequest")]
    [XmlInclude(typeof(SalesTransactionRequest))]
    [XmlInclude(typeof(SalesWithProductInfoOrderRequest))]
    public class SalesWithProductInfoRequest : VPOSRequest
    {
        public static string Execute(SalesWithProductInfoRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class SalesWithProductInfoOrderRequest : Order
    {
        [XmlArray("ItemList"), XmlArrayItem(typeof(Item), ElementName = "Item", IsNullable = true)]
        public List<Item> ItemList { get; set; }
    }

    
    public class Item
    {
        [XmlElement(ElementName = "Number")]
        public int Number { get; set; }
        [XmlElement(ElementName = "ProductID")]
        public string ProductID { get; set; }
        [XmlElement(ElementName = "ProductCode")]
        public string ProductCode { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public int Quantity { get; set; }
        [XmlElement(ElementName = "Price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "TotalAmount")]
        public string TotalAmount { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }


}
