using inzOprogramowania.DataContext;

namespace inzOprogramowania.Services.CommentsService
{
    public class CommentsService : ICommentsService
    {
        private readonly DatabaseContext _databaseContext;
        public CommentsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
