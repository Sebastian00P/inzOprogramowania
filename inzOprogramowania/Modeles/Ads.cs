using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inzOprogramowania.Modeles
{
    [Table("Ads")]
    public class Ads
    {
        [Key]
        public long AdsId { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public virtual User? User { get; set; }
        public long UserId { get; set; }
        public virtual ICollection<Comments>? Comments { get; set; }
    }
}
