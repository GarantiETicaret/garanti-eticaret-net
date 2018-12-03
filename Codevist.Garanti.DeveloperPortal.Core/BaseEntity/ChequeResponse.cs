using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    
    [XmlRoot(ElementName = "Cheque")]
    public class ChequeResponse
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }
        [XmlElement(ElementName = "Count")]
        public string Count { get; set; }
        [XmlElement(ElementName = "ExpireDate")]
        public string ExpireDate { get; set; }
        [XmlElement(ElementName = "UsageRate")]
        public string UsageRate { get; set; }
        [XmlElement(ElementName = "MinTxnAmount")]
        public string MinTxnAmount { get; set; }
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "Bitmap")]
        public string Bitmap { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }
}
