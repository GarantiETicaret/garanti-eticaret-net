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
    [XmlInclude(typeof(BINInqTransactionRequest))]
    public class BINInqRequest : VPOSRequest
    {
        public static string Execute(BINInqRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class BINInqTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "BINInq")]
        public BINInqTransaction _BINInq { get; set; }
    }


    public class BINInqTransaction
    {
        [XmlElement(ElementName = "Group")]
        public string Group { get; set; }
        [XmlElement(ElementName = "CardType")]
        public string CardType { get; set; }
    }
}
