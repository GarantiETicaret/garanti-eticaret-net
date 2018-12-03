using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    [XmlRoot(ElementName = "Terminal")]
    public class Terminal
    {
        [XmlElement(ElementName = "ProvUserID")]
        public string ProvUserID { get; set; }
        [XmlElement(ElementName = "HashData")]
        public string HashData { get; set; }
        [XmlElement(ElementName = "UserID")]
        public string UserID { get; set; }
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "MerchantID")]
        public string MerchantID { get; set; }
    }

}
