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
    [XmlInclude(typeof(BonusPayVoidTransactionRequest))]
    public class BonusPayVoidRequest : VPOSRequest
    {
        public static string Execute(BonusPayVoidRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class BonusPayVoidTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "OriginalRetrefNum")]
        public string OriginalRetrefNum { get; set; }
    }
}
