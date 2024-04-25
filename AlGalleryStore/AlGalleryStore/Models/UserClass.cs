using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlGalleryStore.Models
{
    public class UserClass
    {
        [Key]
        public int User_Id { get; set; }

        [Required(ErrorMessage = "Cart Id is required")]
        [Display(Name = "Cart Id")]
        [ForeignKey("CartClass")]
        public int Cart_Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        public string ?Password { get; set; }

        [Required(ErrorMessage = "User Type is required")]
        [EnumDataType(typeof(UserType), ErrorMessage = "Invalid User Type")]
        [Display(Name = "User Type")]
        public UserType? User_Type { get; set; }


    }

    public enum UserType
    {
        Regular,
        Admin
    }
}

