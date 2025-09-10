namespace LotteryTools.Models
{
    /// <summary>
    /// 彩票
    /// </summary>
    public class Lottery
    {
        /// <summary>
        /// 代码
        /// </summary>
        public required string Code { get; set; }

        /// <summary>
        /// 奖金
        /// </summary>
        public int Reward { get; set; }

        ///// <summary>
        ///// 彩票类型
        ///// </summary>
        //public LotteryType Type { get; set; }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Code} = {Reward}元";
        }
    }
}
