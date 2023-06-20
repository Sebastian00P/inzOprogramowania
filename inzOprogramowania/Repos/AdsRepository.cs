using inzOprogramowania.DataContext;
using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;
using Microsoft.EntityFrameworkCore;

namespace inzOprogramowania.Repos
{
    public class AdsRepository :IAdsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AdsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<AdsDto>> GetAllByUserId(long userId)
        {
            var ads = await _databaseContext.Ads.Where(x => x.UserId == userId).ToListAsync();
            var adsDto = new List<AdsDto>();
            var adDto = new AdsDto();
            foreach (var ad in ads)
            {          
                adsDto.Add(adDto.MapAdsDto(ad));
            }
            return adsDto;
        }
        public async Task<List<AdsDto>> GetAll()
        {
            var ads = await _databaseContext.Ads.ToListAsync();
            var adsDto = new List<AdsDto>();
            var adDto = new AdsDto();
            foreach (var ad in ads)
            {              
                adsDto.Add(adDto.MapAdsDto(ad));
            }
            return adsDto;
        }
        public async Task CreateAds(AdsDto adsDto)
        {
            var ads = new Ads()
            {
                AdsId = adsDto.AdsId,
                Comments = adsDto.Comments,
                CreationTime = adsDto.CreationTime,
                Description = adsDto.Description,
                ExpiredTime = adsDto.ExpiredTime,
                Image = adsDto.Image,
                Title = adsDto.Title,
                UserId = adsDto.UserId,
                User = adsDto.User
            };
            
            _databaseContext.Ads.Add(ads);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<AdsDto> GetAddById(long adsId)
        {
            var ads = await _databaseContext.Ads.Where(x => x.AdsId == adsId).FirstOrDefaultAsync();
            var adDto = new AdsDto().MapAdsDto(ads);
            return adDto;
        }

        public async Task EditAds(AdsDto adsDto)
        {
            var ads = new Ads()
            {
                AdsId = adsDto.AdsId,
                Comments = adsDto.Comments,
                CreationTime = adsDto.CreationTime,
                Description = adsDto.Description,
                ExpiredTime = adsDto.ExpiredTime,
                Image = adsDto.Image,
                Title = adsDto.Title,
                UserId = adsDto.UserId,
                User = adsDto.User             
            };
            _databaseContext.Ads.Update(ads);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
