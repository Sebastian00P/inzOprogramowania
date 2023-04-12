using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inzOprogramowania.Modeles
{
    [Table("Ads")]
    public class Ads
    {
        [Key]
        public long AdId { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        [Column("AuthorId")]
        public long UserId { get; set; }
    }
}
