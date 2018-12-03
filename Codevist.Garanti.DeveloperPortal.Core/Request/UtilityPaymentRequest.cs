﻿using Codevist.Garanti.DeveloperPortal.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.Request
{
    
    [XmlRoot("GVPSRequest")]
    [XmlInclude(typeof(UtilityPaymentTransactionRequest))]
    public class UtilityPaymentRequest : VPOSRequest
    {
        public static string Execute(UtilityPaymentRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class UtilityPaymentTransactionRequest : Transaction
    {
        [XmlElement(ElementName = "CurrencyCode")]
        public int CurrencyCode { get; set; }
        [XmlElement(ElementName = "MotoInd")]
        public string MotoInd { get; set; }
        [XmlElement(ElementName = "UtilityPayment")]
        public UtilityPaymentListRequest UtilityPayment { get; set; }
    }
}
