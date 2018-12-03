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
    [XmlInclude(typeof(BatchInqTransactionRequest))]
    [XmlInclude(typeof(BatchInqOrderRequest))]
    public class BatchInqRequest : VPOSRequest
    {
        public static string Execute(BatchInqRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);  
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class BatchInqTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "BatchNum")]
        public string BatchNum { get; set; }
    }

    public class BatchInqOrderRequest : Order
    {
        [XmlElement(ElementName = "ListPageNum")]
        public int ListPageNum { get; set; }
    }
}
