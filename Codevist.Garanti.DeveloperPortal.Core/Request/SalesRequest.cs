using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;
using Codevist.Garanti.DeveloperPortal.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.Request
{
    [XmlRoot("GVPSRequest")]
    [XmlInclude(typeof(SalesTransactionRequest))]
    public class SalesRequest : VPOSRequest
    {
        public static string Execute(SalesRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            var result = RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
            return (Helper.XmlValidation(result, settings));
        }
    }

    public class SalesTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
    }
}
