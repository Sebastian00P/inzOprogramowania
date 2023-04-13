using inzOprogramowania.DataContext;

namespace inzOprogramowania.Services.AdsService
{
    public class AdsService : IAdsService
    {
        private readonly DatabaseContext _databaseContext;
        public AdsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
