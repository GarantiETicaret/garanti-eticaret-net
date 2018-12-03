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
    [XmlInclude(typeof(RecurringUpdateTransactionRequest))]
    [XmlInclude(typeof(RecurringUpdateOrderRequest))]
    public class RecurringUpdateRequest : VPOSRequest
    {
        public static string Execute(RecurringUpdateRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class RecurringUpdateTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
    }

    public class RecurringUpdateOrderRequest : Order
    {
        [XmlElement(ElementName = "Recurring")]
        public RecurringUpdate Recurring { get; set; }
    }

    public class RecurringUpdate
    {
        [XmlArray("PaymentList"), XmlArrayItem(typeof(RUpdatePaymentRequest), ElementName = "Payment", IsNullable = true)]
        public List<RUpdatePaymentRequest> PaymentList { get; set; }
    }

    public class RUpdatePaymentRequest
    {
        [XmlElement(ElementName = "PaymentNum")]
        public int PaymentNum { get; set; }
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }
    }

}
