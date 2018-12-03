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
    [XmlInclude(typeof(GSMUnitInqTransactionRequest))]
    public class GsmUnitInqRequest : VPOSRequest
    {
        public static string Execute(GsmUnitInqRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class GSMUnitInqTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "CardholderPresentCode")]
        public string CardholderPresentCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "GSMUnitInq")]
        public GSMUnitInq GSMUnitInq { get; set; }
    }

    public class GSMUnitInq
    {
        [XmlElement("InstitutionCode")]
        public string InstitutionCode { get; set; }
        [XmlElement("SubscriberCode")]
        public string SubscriberCode { get; set; }
        [XmlElement("Quantity")]
        public string Quantity { get; set; }
    }
}
