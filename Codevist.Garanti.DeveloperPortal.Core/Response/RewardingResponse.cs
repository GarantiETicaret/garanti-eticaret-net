using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;

namespace Codevist.Garanti.DeveloperPortal.Core.Request
{
    [XmlRoot("GVPSResponse")]
    public class RewardingResponse : VPOSResponse
    {
        [XmlElement(ElementName = "Transaction")]
        public RewardingTransactionResponse Transaction { get; set; }
    }


 
    public class RewardingTransactionResponse:TransactionResponse
    {
        [XmlElement(ElementName = "RewardInqResult")]
        public RewardInqResult RewardInqResult { get; set; }
    }

   public class RewardInqResult
    {
        [XmlArray("RewardList"), XmlArrayItem(typeof(RewardResponse), ElementName = "Reward", IsNullable = true)]
        public List<RewardResponse> RewardList { get; set; }

        [XmlArray("ChequeList"), XmlArrayItem(typeof(ChequeResponse), ElementName = "Cheque", IsNullable = true)]
        public List<ChequeResponse> ChequeList { get; set; }
    }


}
