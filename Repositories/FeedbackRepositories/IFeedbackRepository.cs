using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Feedback;
using projectchicandlighting.ModelViews.Home;

namespace projectchicandlighting.Repositories.FeedbackRepository.FeedbackRepository
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Task<List<HomeFeedbackModel>> GetHomeFeedbackModels();
        Task<List<AdminFeedbackModel>> GetAdminFeedbackModels();
    }
}
