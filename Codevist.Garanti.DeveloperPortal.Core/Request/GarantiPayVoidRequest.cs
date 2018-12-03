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
    [XmlInclude(typeof(GarantiPayVoidTransactionRequest))]
    public class GarantiPayVoidRequest : VPOSRequest
    {
        public static string Execute(GarantiPayVoidRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class GarantiPayVoidTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "ReturnServerUrl")]
        public string ReturnServerUrl { get; set; }
        [XmlElement(ElementName = "CardholderPresentCode")]
        public int CardholderPresentCode { get; set; }

        [XmlElement(ElementName = "GarantiPaY")]
        public GarantiPayV GarantiPayV { get; set; }
    }

    public class GarantiPayV
    {
        [XmlElement(ElementName = "GPID")]
        public string GPID { get; set; }
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }

    }


}


