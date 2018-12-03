using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.Request
{

    [XmlRoot("GVPSRequest")]
    [XmlInclude(typeof(SettlementInqTransactionRequest))]
    public class SettlementInqRequest : VPOSRequest
    {
        public SettlementInq SettlementInq { get; set; }

        public static string Execute(SettlementInqRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class SettlementInqTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
    }
}
