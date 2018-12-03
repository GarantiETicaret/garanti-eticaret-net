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
    [XmlInclude(typeof(PlayerChequeSalesTransactionRequest))]
    public class PlayerChequeSalesRequest : VPOSRequest
    {
        public static string Execute(PlayerChequeSalesRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }


    public class PlayerChequeSalesTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlArray("ChequeList"), XmlArrayItem(typeof(ChequeRequest), ElementName = "Cheque", IsNullable = true)]
        public List<ChequeRequest> ChequeList { get; set; }
    }
}
