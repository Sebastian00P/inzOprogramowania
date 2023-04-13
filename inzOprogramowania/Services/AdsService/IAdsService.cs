using inzOprogramowania.Modeles;

namespace inzOprogramowania.Services.AdsService
{
    public interface IAdsService
    {
        Task<List<Ads>> GetAll();
        Task CreateAds(Ads ads);
        Task<List<Ads>> GetAllByUserId(long userId);
        Task<Ads> GetAddById(long adsId);
        Task EditAds(Ads ads);
    }
}
