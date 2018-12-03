using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    public class GSMUnitSalesListRequest
    {
        [XmlElement("InstitutionCode")]
        public string InstitutionCode { get; set; }
        [XmlElement("SubscriberCode")]
        public string SubscriberCode { get; set; }
        [XmlElement("UnitID")]
        public string UnitID { get; set; }
        [XmlElement("Quantity")]
        public string Quantity { get; set; }
        [XmlElement("Amount")]
        public string Amount { get; set; }
    }
}
