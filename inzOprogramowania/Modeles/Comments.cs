using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inzOprogramowania.Modeles
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public long CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual Ads? Ads { get; set; }
        public long AdsId { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
