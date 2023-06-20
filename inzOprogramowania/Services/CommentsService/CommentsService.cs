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
        public async Task CreateComment(Comments comment)
        {
            await _databaseContext.Comments.AddAsync(comment);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task EditComment(Comments comment)
        {
            _databaseContext.Comments.Update(comment);
            await _databaseContext.SaveChangesAsync();
        }

    }
}
