using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    [XmlRoot(ElementName = "Reward")]
    public class RewardRequest
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "UsedAmount")]
        public string UsedAmount { get; set; }
        [XmlElement(ElementName = "GainedAmount")]
        public string GainedAmount { get; set; }

    }

}
