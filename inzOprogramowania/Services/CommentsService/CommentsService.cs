using inzOprogramowania.DataContext;
using inzOprogramowania.Modeles;
using Microsoft.EntityFrameworkCore;

namespace inzOprogramowania.Services.CommentsService
{
    public class CommentsService : ICommentsService
    {
        private readonly DatabaseContext _databaseContext;
        public CommentsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Comments>> GetCommentsByAdId(long adsId)
        {
            return await _databaseContext.Comments.Where(x => x.AdsId == adsId).OrderBy(x => x.CreationTime).ToListAsync();
        }
        
    }
}
