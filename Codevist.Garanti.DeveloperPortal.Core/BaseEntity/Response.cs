using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    [XmlRoot(ElementName = "Response")]
    public class Response
    {
        [XmlElement(ElementName = "Source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "Code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "ReasonCode")]
        public string ReasonCode { get; set; }
        [XmlElement(ElementName = "Message")]
        public string Message { get; set; }
        [XmlElement(ElementName = "ErrorMsg")]
        public string ErrorMsg { get; set; }
        [XmlElement(ElementName = "SysErrMsg")]
        public string SysErrMsg { get; set; }
    }
}
