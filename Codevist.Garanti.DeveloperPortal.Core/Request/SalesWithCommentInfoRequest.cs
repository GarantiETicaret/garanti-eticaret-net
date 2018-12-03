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
    [XmlInclude(typeof(SalesTransactionRequest))]
    [XmlInclude(typeof(SalesWithCommentInfoOrderRequest))]
    public class SalesWithCommentInfoRequest : VPOSRequest
    {
        public static string Execute(SalesWithCommentInfoRequest request, Settings settings)
        {
            request.Terminal.HashData = Helper.ComputeHash(request, settings);
            return RestHttpCaller.Create().PostXMLString(settings.BaseUrl, request);
        }
    }

    public class SalesWithCommentInfoOrderRequest : Order
    {
        [XmlArray("CommentList"), XmlArrayItem(typeof(Comment), ElementName = "Comment", IsNullable = true)]
        public List<Comment> CommentList { get; set; }
    }

    public class Comment
    {
        [XmlElement(ElementName = "Number")]
        public int Number { get; set; }
        [XmlElement(ElementName = "Text")]
        public string Text { get; set; }
    }
}
