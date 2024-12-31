using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Feedback;
using projectchicandlighting.ModelViews.Home;
using projectchicandlighting.Repositories.FeedbackRepository.FeedbackRepository;

namespace projectchicandlighting.Repositories.FeedbackRepositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DatabaseContext _context;

        public FeedbackRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Feedback t)
        {
            await _context.Feedbacks.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var feedback = await _context.Feedbacks
               .SingleOrDefaultAsync(f => f.Id == id && f.IsActive == true)
               ?? throw new Exception(StaticMessage.NotFound);

            feedback.IsActive = false;
            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AdminFeedbackModel>> GetAdminFeedbackModels()
        {
            return await (from f in _context.Feedbacks
                          where f.IsActive == true
                          select new AdminFeedbackModel
                          {
                              Id = f.Id,
                              Name = f.Name,
                              Comment= f.Comment,
                              Email= f.Email,
                              Rate = f.Rate
                          })
                          .ToListAsync();
        }

        public async Task<List<Feedback>> GetAll()
        {
            return await _context.Feedbacks
                .Where(f => f.IsActive == true)
                .ToListAsync();
        }

        public async Task<Feedback> GetById(string id)
        {
            return await _context.Feedbacks
                .SingleOrDefaultAsync(f => f.IsActive == true && f.Id == id)
                ?? throw new Exception(StaticMessage.NotFound); ;
        }

        public async Task<List<HomeFeedbackModel>> GetHomeFeedbackModels()
        {
            return await (from f in _context.Feedbacks
                          where f.IsActive == true && f.Rate == 3
                          select new HomeFeedbackModel
                          {
                              Name = f.Name,
                              Comment = f.Comment
                          })
                          .Take(3)
                          .ToListAsync();
        }

        public Task Update(string id, Feedback t)
        {
            throw new NotImplementedException();
        }
    }
}
