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
        public string ISBN { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public long UserId { get; set; }



        public AdsDto MapAdsDto(Ads ads)
        {
            var adsDto = new AdsDto()
            {
                AdsId = ads.AdsId,
                Title = ads.Title,
                ISBN = ads.ISBN,
                Description = ads.Description,
                CreationTime = ads.CreationTime,
                ExpiredTime = ads.ExpiredTime,          
                UserId = ads.UserId               
            };
            return adsDto;
        }
    }
}
