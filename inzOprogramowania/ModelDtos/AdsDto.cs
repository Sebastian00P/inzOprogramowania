using inzOprogramowania.Modeles;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc;

namespace inzOprogramowania.ModelDtos
{
    public class AdsDto
    {
        public long AdsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ModelBinder(BinderType = typeof(ByteArrayModelBinder))]
        public byte[] Image { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public virtual User? User { get; set; }
        public long UserId { get; set; }
        public virtual ICollection<Comments>? Comments { get; set; }


        public AdsDto MapAdsDto(Ads ads)
        {
            var adsDto = new AdsDto()
            {
                AdsId = ads.AdsId,
                Title = ads.Title,
                Description = ads.Description,
                Image = ads.Image,
                CreationTime = ads.CreationTime,
                ExpiredTime = ads.ExpiredTime,
                User = ads.User,
                UserId = ads.UserId,
                Comments = ads.Comments
            };
            return adsDto;
        }
    }
}
