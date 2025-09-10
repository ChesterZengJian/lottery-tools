using LotteryTools.Common.Enums;

namespace LotteryTools.Models
{
    public class LotteryCategoryData
    {
        public List<LotteryCategory> SportsCategories { get; set; } = [];

        public List<LotteryCategory> WelfareCategories { get; set; } = [];

        public IEnumerable<LotteryCategory> GetLotteryCategories(LotteryType lotteryType)
        {
            return lotteryType == LotteryType.SportsLottery ? SportsCategories : WelfareCategories;
        }
    }
}
