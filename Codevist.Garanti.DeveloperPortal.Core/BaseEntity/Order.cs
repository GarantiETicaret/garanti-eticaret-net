using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    [XmlRoot(ElementName = "Order")]
    public class Order
    {
        [XmlElement(ElementName = "OrderID")]
        public string OrderID { get; set; }
        [XmlElement(ElementName = "GroupID")]
        public string GroupID { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }
}
