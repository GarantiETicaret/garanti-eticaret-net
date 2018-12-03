using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{

    [XmlRoot(ElementName = "Reward")]
    public class RewardResponse
    {
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "TotalAmount")]
        public string TotalAmount { get; set; }
        [XmlElement(ElementName = "LastTxnGainAmount")]
        public string LastTxnGainAmount { get; set; }
    }

}
