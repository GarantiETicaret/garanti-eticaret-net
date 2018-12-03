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
    [XmlInclude(typeof(UtilityPaymentInqTransactionRequest))]
    public class UtilityPaymentInqRequest : VPOSRequest
    {
        public static string Execute(UtilityPaymentInqRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class UtilityPaymentInqTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "CardholderPresentCode")]
        public string CardholderPresentCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "UtilityPaymentInq")]
        public UtilityPaymentInq UtilityPaymentInq { get; set; }
    }

    public class UtilityPaymentInq
    {
        [XmlElement("InstitutionCode")]
        public string InstitutionCode { get; set; }
        [XmlElement("SubscriberCode")]
        public string SubscriberCode { get; set; }
    }
}
