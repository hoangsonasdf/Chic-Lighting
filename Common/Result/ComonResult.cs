using projectchicandlighting.Models;

namespace projectchicandlighting.Common.Result
{
    public class ComonResult
    {
        public bool Succeed { get; set; }
        public string Token { get; set; }
        public List<string> Errors { get; set; }
        public User User { get; set; }
    }
}
