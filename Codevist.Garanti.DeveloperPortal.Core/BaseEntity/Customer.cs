using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    [XmlRoot(ElementName = "Customer")]
    public class Customer
    {
        [XmlElement(ElementName = "IPAddress")]
        public string IPAddress { get; set; }
        [XmlElement(ElementName = "EmailAddress")]
        public string EmailAddress { get; set; }
    }
}
