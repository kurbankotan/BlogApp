using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete
{
    public class EfCommentRepository : ICommentRepository
    {
        private BlogContext _context;
        public EfCommentRepository(BlogContext context)
        {
            _context = context;
        }

        //.ToList denilice veritabanına gönderilecek
        public IQueryable<Comment> Comments => _context.Comments;


       //Tag Eklemek için
        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}