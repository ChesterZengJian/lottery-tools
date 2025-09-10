using LotteryTools.Models;
using Newtonsoft.Json;

namespace LotteryTools.Services
{
    public sealed class LotteryDataLoader
    {
        private static readonly Lazy<LotteryDataLoader> _lazyInstance = new(() => new LotteryDataLoader());
        public static LotteryDataLoader Instance => _lazyInstance.Value;

        public LotteryData Data { get; private set; }

        public LotteryCategoryData CategoryData { get; private set; }

        private LotteryDataLoader()
        {
            Data = new LotteryData();
            CategoryData = new LotteryCategoryData();
        }

        public async Task Initialize()
        {
            await LoadData();
            await LoadCategories();
        }

        /// <summary>
        /// 从Json文件中加载数据
        /// </summary>
        private async Task LoadData()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("LotteryData.json");
                using var reader = new StreamReader(stream);

                var jsonContent = await reader.ReadToEndAsync();
                Data = JsonConvert.DeserializeObject<LotteryData>(jsonContent) ?? new LotteryData();


            }
            catch (Exception ex)
            {
                // 处理可能的异常（如文件未找到、JSON格式错误等）
                Console.WriteLine($"加载JSON数据失败: {ex.Message}");
                Data = new LotteryData();
            }
        }

        private async Task LoadCategories()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("LotteryCategories.json");
                using var reader = new StreamReader(stream);

                var jsonContent = await reader.ReadToEndAsync();
                CategoryData = JsonConvert.DeserializeObject<LotteryCategoryData>(jsonContent) ?? new LotteryCategoryData();
            }
            catch (Exception ex)
            {
                // 处理可能的异常（如文件未找到、JSON格式错误等）
                Console.WriteLine($"加载JSON数据失败: {ex.Message}");
                Data = new LotteryData();
            }
        }
    }
}
