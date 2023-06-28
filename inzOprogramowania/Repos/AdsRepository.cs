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
                Comments = _databaseContext.Comments.Where(x => x.AdsId == adsDto.AdsId).ToList(),
                CreationTime = adsDto.CreationTime,
                Description = adsDto.Description,
                ExpiredTime = adsDto.ExpiredTime,
                ISBN = adsDto.ISBN,
                Title = adsDto.Title,
                UserId = adsDto.UserId,
                User = _databaseContext.Users.Where(x => x.UserId == adsDto.UserId).FirstOrDefault()
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
                Comments = _databaseContext.Comments.Where(x => x.AdsId == adsDto.AdsId).ToList(),
                CreationTime = adsDto.CreationTime,
                Description = adsDto.Description,
                ExpiredTime = adsDto.ExpiredTime,
                ISBN = adsDto.ISBN,
                Title = adsDto.Title,
                UserId = adsDto.UserId,
                User = _databaseContext.Users.Where(x => x.UserId == adsDto.UserId).FirstOrDefault()       
            };
            _databaseContext.Ads.Update(ads);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task DeleteAdd(long adsId)
        {
            var ads = await _databaseContext.Ads.Where(x => x.AdsId == adsId).FirstOrDefaultAsync();
            _databaseContext.Ads.Remove(ads);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
