using inzOprogramowania.Modeles;
using inzOprogramowania.Services;
using inzOprogramowania.Services.AdsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inzOprogramowania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IAdsService _adsService;

        public AdsController(IAdsService adsService)
        {
            _adsService = adsService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<List<Ads>> GetAll()
        {
           return await _adsService.GetAll();
        }
        [Route("Create")]
        [HttpPost]
        public async Task Create(Ads ads)
        {
           await _adsService.CreateAds(ads);
        }
        [Route("GetAllByUserId")]
        [HttpGet]
        public async Task<List<Ads>> GetAllByUserId(long userId)
        {
            return await _adsService.GetAllByUserId(userId);
        }
        [Route("GetAdsById")]
        [HttpGet]
        public async Task<Ads> GetAdsById(long adsId)
        {
            return await _adsService.GetAddById(adsId);
        }
        [Route("EditAdd")]
        [HttpPost]
        public async Task EditAdd(Ads ads)
        {
            await _adsService.EditAds(ads);
        }
    }
}
