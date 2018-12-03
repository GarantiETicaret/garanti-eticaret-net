using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.Response
{
    [XmlRoot("GVPSResponse")]
    public class SalesResponse : VPOSResponse
    {
        //[XmlElement(ElementName = "Transaction")]
        //public SalesTransactionResponse Transaction { get; set; }
    }

    //public class SalesTransactionResponse : TransactionResponse
    //{
    //    [XmlElement(ElementName = "RewardInqResult")]
    //    public RewardInqResult RewardInqResult { get; set; }
    //}

    //public class RewardInqResult
    //{
    //    [XmlArray("RewardList")]
    //    public List<Reward> RewardList { get; set; }

    //    [XmlArray("ChequeList")]
    //    public List<Cheque> ChequeList { get; set; }
    //}
}
