using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevist.Garanti.DeveloperPortal.Core.Response
{
    public class Secure3DResponse
    {
        public string authenticationCode { get; set; }
        public string orderID { get; set; }
        public string securityLevel { get; set; }
        public string txnID { get; set; }
        public string mode { get; set; }
        public string MD { get; set; }
        public string apiversion { get; set; }
        public string terminalProvUserID { get; set; }
        public string installmentCount { get; set; }
        public string currencyCode { get; set; }
        public string amount { get; set; }
        public string terminalUserID { get; set; }
        public string terminalID { get; set; }
        public string customerIpAddres { get; set; }
        public string customerEmailAddress { get; set; }
        public string terminalMerchantID { get; set; }
        public string txnType { get; set; }
        public string authcode { get; set; }
        public string procreturnCode { get; set; }
        public string response { get; set; }
        public string mdstatus { get; set; }
        public string rnd { get; set; }
        public string xmlResponse { get; set; }
        
    }
}
