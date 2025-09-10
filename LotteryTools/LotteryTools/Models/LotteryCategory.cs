namespace LotteryTools.Models
{
    /// <summary>
    /// 彩票类型
    /// </summary>
    public class LotteryCategory
    {
        public required string Name { get; set; }

        public required List<int> Rewards { get; set; }
    }
}
