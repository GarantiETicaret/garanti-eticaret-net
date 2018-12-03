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
    [XmlInclude(typeof(DCCSalesTransactionRequest))]
    public class DCCSalesRequest : VPOSRequest
    {
        public static string Execute(DCCSalesRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class DCCSalesTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "SubType")]
        public string SubType { get; set; }
        [XmlElement(ElementName = "OriginalRetrefNum")]
        public string OriginalRetrefNum { get; set; }
        [XmlElement(ElementName = "DCC")]
        public DCC DCC { get; set; }
    }
}
