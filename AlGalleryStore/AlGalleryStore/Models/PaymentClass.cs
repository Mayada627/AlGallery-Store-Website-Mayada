using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlGalleryStore.Models
{
    public class PaymentClass
    {
        [Key]
        public int Payment_Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Payment Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Payment Method is required")]
        [StringLength(50, ErrorMessage = "Payment Method must be less than 50 characters")]
        [Display(Name = "Payment Method")]
        public string? Method { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Payment Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        [ForeignKey("UserClass")]
        [Display(Name = "User Id")]
        public int? User_Id { get; set; }

        
        public virtual required UserClass User { get; set; }
    }
}
