using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
   
    public class RecurringRequest
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "TotalPaymentNum")]
        public string TotalPaymentNum { get; set; }
        [XmlElement(ElementName = "FrequencyType")]
        public string FrequencyType { get; set; }
        [XmlElement(ElementName = "FrequencyInterval")]
        public string FrequencyInterval { get; set; }
        [XmlElement(ElementName = "StartDate")]
        public string StartDate { get; set; }
    }
}
