using LotteryTools.Common.Enums;
using Newtonsoft.Json;

namespace LotteryTools.Models
{
    public class LotteryData
    {
        public List<Lottery> SportsLotteries { get; set; } = [];

        public List<Lottery> WelfareLotteries { get; set; } = [];

        public IEnumerable<string> GetLotteryStringList(LotteryType lotteryType)
        {
            return lotteryType == LotteryType.SportsLottery
                ? SportsLotteries.Select(l => l.ToString())
                : WelfareLotteries.Select(l => l.ToString());
        }

        public IEnumerable<Lottery> SearchLotteries(LotteryType lotteryType, string code, List<int> rewards)
        {
            if (lotteryType == LotteryType.SportsLottery)
            {
                var sportsResult = SportsLotteries.Where(lottery => lottery.Code.Contains(code, StringComparison.CurrentCultureIgnoreCase));
                return rewards.Count > 0 ? sportsResult.Where(lottery => rewards.Contains(lottery.Reward)) : sportsResult;
            }

            var welfareResult = WelfareLotteries.Where(lottery => lottery.Code.Contains(code, StringComparison.CurrentCultureIgnoreCase));
            return rewards.Count > 0 ? welfareResult.Where(lottery => rewards.Contains(lottery.Reward)) : welfareResult;
        }
    }
}
