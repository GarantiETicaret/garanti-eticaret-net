namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    /// <summary>
    /// Tüm çağrılarda kullanılacak ayarların tutulduğu sınıftır. 
    /// Bu sınıf üzerinde size özel parametreler fonksiyonlar arasında taşınabilir.
    /// </summary>
    public class Settings
    {      
        public string Mode { get; set; }
        public string Version { get; set; }
        public string BaseUrl { get; set; }
        public string Password { get; set; }
    }
}
