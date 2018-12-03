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
    [XmlInclude(typeof(VoidTransactionRequest))]
    public class VoidRequest : VPOSRequest
    {
        public static string Execute(VoidRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class VoidTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "OriginalRetrefNum")]
        public string OriginalRetrefNum { get; set; }
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
    }
}
