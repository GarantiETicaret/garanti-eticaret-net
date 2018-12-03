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
    [XmlInclude(typeof(VRecurringSalesTransactionRequest))]
    [XmlInclude(typeof(VRecurringSalesOrderRequest))]
    public class VRecurringSalesRequest : VPOSRequest
    {
        public static string Execute(VRecurringSalesRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class VRecurringSalesTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
    }

    public class VRecurringSalesOrderRequest : Order
    {
        [XmlElement(ElementName = "Recurring")]
        public Recurring Recurring { get; set; }
    }

    public class Recurring : RecurringRequest
    {
        [XmlArray("PaymentList"), XmlArrayItem(typeof(RecurringPaymentRequest), ElementName = "Payment", IsNullable = true)]
        public List<RecurringPaymentRequest> PaymentList { get; set; }
    }

    public class RecurringPaymentRequest
    {
        [XmlElement(ElementName = "PaymentNum")]
        public int PaymentNum { get; set; }
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }
    }
}
