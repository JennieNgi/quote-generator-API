using System.ComponentModel.DataAnnotations;

namespace quoteGeneratorAPI.Models {

    public class Quote {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name="Author:")]
        [MaxLength(100)]
        public string author { get; set; }
        [Required]
        [Display(Name="Quote:")]
        public string quote { get; set; }
        [Display(Name="Link:")]
        [MaxLength(100)]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$" , ErrorMessage="Incorrect format for URL")]
        public string permalink { get; set; }
        public string image { get; set; }
    } 

}