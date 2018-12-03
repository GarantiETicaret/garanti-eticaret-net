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
    [XmlInclude(typeof(DownPaymentSalesTransactionRequest))]
    public class DownPaymentSalesRequest : VPOSRequest
    {
        public static string Execute(DownPaymentSalesRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class DownPaymentSalesTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "DownPaymentRate")]
        public int DownPaymentRate { get; set; }
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "InstallmentCnt")]
        public int InstallmentCnt { get; set; }
    }
}
