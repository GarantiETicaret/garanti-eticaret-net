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
    [XmlRoot("GVPSRequest")]
    [XmlInclude(typeof(RewardingTransactionRequest))]
    public class RewardingRequest : VPOSRequest
    {
        public static RewardingResponse Execute(RewardingRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXML<RewardingResponse>(settings.BaseUrl, request);
        }
    }


        
    public class RewardingTransactionRequest : Transaction
    {
    
        [XmlElement(ElementName = "SubType")]
        public string SubType { get; set; }
        [XmlElement(ElementName = "InstallmentCnt")]
        public string InstallmentCnt { get; set; }
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "CardholderPresentCode")]
        public string CardholderPresentCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }


}
