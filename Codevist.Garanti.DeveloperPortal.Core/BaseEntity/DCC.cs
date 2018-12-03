using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    public class DCC
    {
        [XmlElement("Currency")]
        public int Currency { get; set; }
    }
}
