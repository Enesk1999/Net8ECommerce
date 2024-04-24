using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ETicaret.Net8.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Kategori Adı Boş Bırakılamaz")]
        [DisplayName("Kategori Adı")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Görüntülenme Sayısı")]
        public int DisplayOrder { get; set; }
    }
}
