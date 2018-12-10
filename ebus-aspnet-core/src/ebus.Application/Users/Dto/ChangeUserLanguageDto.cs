using System.ComponentModel.DataAnnotations;

namespace ebus.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}