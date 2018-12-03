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
    [XmlInclude(typeof(GarantiPayMOTransactionRequest))]
    public class GarantiPayMORequest : VPOSRequest
    {
        public static string Execute(GarantiPayMORequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class GarantiPayMOTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "ReturnServerUrl")]
        public string ReturnServerUrl { get; set; }
        [XmlElement(ElementName = "CardholderPresentCode")]
        public int CardholderPresentCode { get; set; }
        [XmlElement(ElementName = "SubType")]
        public string SubType { get; set; }

        [XmlElement(ElementName = "GarantiPaY")]
        public GarantiPaY GarantiPaY { get; set; }
    }

    public class GarantiPaY
    {
        
        [XmlElement(ElementName = "bnsuseflag")]
        public string bnsuseflag { get; set; }
        [XmlElement(ElementName = "fbbuseflag")]
        public string fbbuseflag { get; set; }
        [XmlElement(ElementName = "chequeuseflag")]
        public string chequeuseflag { get; set; }
        [XmlElement(ElementName = "mileuseflag")]
        public string mileuseflag { get; set; }
        [XmlElement(ElementName = "CompanyName")]
        public string CompanyName { get; set; }
        [XmlElement(ElementName = "OrderInfo")]
        public string OrderInfo { get; set; }
        [XmlElement(ElementName = "TxnTimeOutPeriod")]
        public string TxnTimeOutPeriod { get; set; }
        [XmlElement(ElementName = "NotifSendInd")]
        public string NotifSendInd { get; set; }
        [XmlElement(ElementName = "ReturnUrl")]
        public string ReturnUrl { get; set; }
        [XmlElement(ElementName = "TCKN")]
        public string TCKN { get; set; }
        [XmlElement(ElementName = "GSMNumber")]
        public string GSMNumber { get; set; }
        [XmlElement(ElementName = "InstallmentOnlyForCommercialCard")]
        public string InstallmentOnlyForCommercialCard { get; set; }
        [XmlElement(ElementName = "TotalInstallmentCount")]
        public string TotalInstallmentCount { get; set; }

        [XmlArray("GPInstallments"), XmlArrayItem(typeof(GPInstallments), ElementName = "Installment", IsNullable = true)]
        public List<GPInstallments> GPInstallments { get; set; }
    }

    public class GPInstallments
    {
        [XmlElement(ElementName = "Installmentnumber")]
        public int Installmentnumber { get; set; }
        [XmlElement(ElementName = "Installmentamount")]
        public string Installmentamount { get; set; }
    }
}
