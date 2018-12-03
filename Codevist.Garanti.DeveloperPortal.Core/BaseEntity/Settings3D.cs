using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    /// <summary>
    /// Tüm çağrılarda kullanılacak ayarların tutulduğu sınıftır. 
    /// Bu sınıf üzerinde size özel parametreler fonksiyonlar arasında taşınabilir.
    /// </summary>
    public class Settings3D
    {
        public string mode { get; set; }
        public string apiversion { get; set; }
        public string BaseUrl { get; set; }
        public string Password { get; set; }
    }
}
