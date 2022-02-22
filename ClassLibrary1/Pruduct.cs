    using Company.DomainModels.CustomValidations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace Company.DomainModels
{
    [Table("Products", Schema = "dbo")]
    public class Products
    {
        [Key]
        [Display(Name = "Product ID")]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is can't be blank")]
        [RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage = "Alphabets only")]
        [MaxLength(20, ErrorMessage = "Product name can be maximum 20 character long")]
        [MinLength(2, ErrorMessage = "Product name should contain at least 2 characters")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Product Price is can't be blank")]
        [Range(0, 1000000, ErrorMessage = "Price should be in between in 0 and 100000")]
        [DivisibleBy10(ErrorMessage = "Price should be in multiples of 10")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Date Of Purchase")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }


        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "Please select Availability status")]
        public string AvailabilityStatus { get; set; }




        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is can't be blank")]
        public long CategoryID { get; set; }



        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand is can't be blank")]
        public long BrandID { get; set; }


        public bool Active { get; set; }



        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public virtual Brands Brands { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
