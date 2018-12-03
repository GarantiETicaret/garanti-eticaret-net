using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    [XmlRoot(ElementName = "SettlementInq")]
    public class SettlementInq
    {
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
    }
}
