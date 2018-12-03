using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    [XmlRoot(ElementName = "Card")]
    public class Card
    {
        [XmlElement(ElementName = "Number")]
        public string Number { get; set; }
        [XmlElement(ElementName = "ExpireDate")]
        public string ExpireDate { get; set; }
        [XmlElement(ElementName = "CVV2")]
        public string CVV2 { get; set; }
    }
}
