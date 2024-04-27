using ETicaret.Net8.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name ="List Price")]
        [Range(1,1000)]
        public double ListPrice { get; set; }

        [Required(ErrorMessage ="Fiyat Bandı 1-1000 arasında olmalıdır!")]
        [Display(Name = "List 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "List 50-100")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required(ErrorMessage = "Fiyat Bandı 1-1000 arasında olmalıdır!")]
        [Display(Name = "List 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int? CategoryId { get; set; }
        [ValidateNever]
        public virtual ICollection<Category?> Categories { get; set; }
        public string? ImageUrl { get; set; }
    }
}
