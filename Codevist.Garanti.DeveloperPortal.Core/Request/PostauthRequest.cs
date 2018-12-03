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
    [XmlInclude(typeof(PostauthTransactionRequest))]
    public class PostauthRequest : VPOSRequest
    {
        public static string Execute(PostauthRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }

        //public static SalesResponse Execute(SalesRequest request, Settings settings)       
        //{
        //    request.Terminal.HashData = Helper.ComputeHash(request, settings);
        //    return RestHttpCaller.Create().PostXML<SalesResponse>(settings.BaseUrl, request);
        //}
    }

    public class PostauthTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
    }
}
