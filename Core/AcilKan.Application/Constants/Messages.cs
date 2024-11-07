using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Constants
{
    public static class Messages
    {
        // About Validate Message
        public static string AboutTitleNotEmpty = "Başlık boş olamaz.";
        public static string AboutDescriptionNotEmpty = "Açıklama boş olamaz.";
        public static string AboutImageUrlNotEmpty = "Görsel URL boş olamaz.";
        public static string AboutTitleMaxLength = "Başlık 100 karakterden uzun olamaz.";
        public static string AboutDescriptionMaxLength = "Açıklama 500 karakterden uzun olamaz.";
        public static string AboutImageUrlInvalid = "Görsel URL geçerli değil.";
        public static string AboutIdGreaterThanZero = "Id 0'dan büyük olmalıdır.";
        public static string AboutIdNotFound = "Geçersiz Id değeri.";

    }
}
