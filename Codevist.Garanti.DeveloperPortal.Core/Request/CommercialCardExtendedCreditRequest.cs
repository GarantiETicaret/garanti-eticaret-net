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
    [XmlInclude(typeof(CommercialCardExtendedCreditTransactionRequest))]
    public class CommercialCardExtendedCreditRequest : VPOSRequest
    {
        public static string Execute(CommercialCardExtendedCreditRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class CommercialCardExtendedCreditTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "InstallmentCnt")]
        public int InstallmentCnt { get; set; }
        [XmlElement(ElementName = "CommercialCardExtendedCredit")]
        public CommercialCardExtendedCredit CommercialCardExtendedCredit { get; set; }
    }

    
    public class CommercialCardExtendedCredit
    {
        [XmlArray("PaymentList"), XmlArrayItem(typeof(PaymentRequest), ElementName = "Payment", IsNullable = true)]
        public List<PaymentRequest> PaymentList { get; set; }
    }
}
