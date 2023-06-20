using inzOprogramowania.DataContext;
using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;
using Microsoft.EntityFrameworkCore;

namespace inzOprogramowania.Repos
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CommentsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<CommentsDto>> GetAll()
        {
            var comments = await _databaseContext.Comments.ToListAsync();
            var commentsDto = new List<CommentsDto>();
            var commentDto = new CommentsDto();
            foreach (var comment in comments)
            {
                commentsDto.Add(commentDto.MapCommentsDto(comment));
            }
            return commentsDto;
        }
        public async Task CreateComment(CommentsDto commentDto)
        {
            var comment = new Comments()
            {
                CommentId = commentDto.CommentId,
                Content = commentDto.Content,
                Ads = commentDto.Ads,
                AdsId = commentDto.AdsId,
                CreationTime = commentDto.CreationTime,
                UserId = commentDto.UserId,
                User = commentDto.User
            };
            await _databaseContext.Comments.AddAsync(comment);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task EditComment(CommentsDto commentDto)
        {
            var comment = new Comments()
            {
                CommentId = commentDto.CommentId,
                Content = commentDto.Content,
                Ads = commentDto.Ads,
                AdsId = commentDto.AdsId,
                CreationTime = commentDto.CreationTime,
                UserId = commentDto.UserId,
                User = commentDto.User
            };
            _databaseContext.Comments.Update(comment);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
