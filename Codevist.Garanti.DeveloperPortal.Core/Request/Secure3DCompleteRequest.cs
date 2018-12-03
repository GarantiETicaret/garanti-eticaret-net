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
    [XmlInclude(typeof(Secure3DCompleteTransactionRequest))]
    public class Secure3DCompleteRequest : VPOSRequest
    {
        public static string Execute(Secure3DCompleteRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class Secure3DCompleteTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "InstallmentCnt")]
        public string InstallmentCnt { get; set; }
        [XmlElement(ElementName = "CardholderPresentCode")]
        public int CardholderPresentCode { get; set; }
        [XmlElement(ElementName = "Secure3D")]
        public Secure3D Secure3D { get; set; }
    }

    public class Secure3D
    {
        [XmlElement(ElementName = "AuthenticationCode")]
        public string AuthenticationCode { get; set; }
        [XmlElement(ElementName = "SecurityLevel")]
        public string SecurityLevel { get; set; }
        [XmlElement(ElementName = "TxnID")]
        public string TxnID { get; set; }
        [XmlElement(ElementName = "Md")]
        public string Md { get; set; }
    }
}
