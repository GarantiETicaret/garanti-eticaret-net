using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    [XmlRoot(ElementName = "Transaction")]
    public class TransactionResponse
    {
        [XmlElement(ElementName = "Response")]
        public Response Response { get; set; }
        [XmlElement(ElementName = "RetrefNum")]
        public string RetrefNum { get; set; }
        [XmlElement(ElementName = "AuthCode")]
        public string AuthCode { get; set; }
        [XmlElement(ElementName = "BatchNum")]
        public string BatchNum { get; set; }
        [XmlElement(ElementName = "SequenceNum")]
        public string SequenceNum { get; set; }
        [XmlElement(ElementName = "ProvDate")]
        public string ProvDate { get; set; }
        [XmlElement(ElementName = "CardNumberMasked")]
        public string CardNumberMasked { get; set; }
        [XmlElement(ElementName = "CardHolderName")]
        public string CardHolderName { get; set; }
        [XmlElement(ElementName = "CardType")]
        public string CardType { get; set; }
        [XmlElement(ElementName = "HashData")]
        public string HashData { get; set; }
        [XmlElement(ElementName = "HostMsgList")]
        public string HostMsgList { get; set; }
    }

}
