using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;

namespace inzOprogramowania.Services.AdsService
{
    public interface IAdsService
    {
        Task<List<AdsDto>> GetAll();
        Task CreateAds(AdsDto ads);
        Task<List<AdsDto>> GetAllByUserId(long userId);
        Task<AdsDto> GetAddById(long adsId);
        Task EditAds(AdsDto ads);
        Task DeleteAds(long adsId);
    }
}
