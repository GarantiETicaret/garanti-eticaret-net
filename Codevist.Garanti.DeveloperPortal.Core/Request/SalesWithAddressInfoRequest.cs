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
    [XmlInclude(typeof(SalesWithAddressInfoOrderRequest))]
    public class SalesWithAddressInfoRequest : VPOSRequest
    {
        public static string Execute(SalesWithAddressInfoRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class SalesWithAddressInfoOrderRequest : Order
    {
        [XmlArray("AddressList"), XmlArrayItem(typeof(Address), ElementName = "Address", IsNullable = true)]
        public List<Address> AddressList { get; set; }
    }
   
    public class Address
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "Company")]
        public string Company { get; set; }
        [XmlElement(ElementName = "Text")]
        public string Text { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "PostalCode")]
        public string PostalCode { get; set; }
        [XmlElement(ElementName = "PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
