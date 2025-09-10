using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LotteryTools.Common.Enums;
using LotteryTools.Models;
using LotteryTools.Services;
using System.Collections.ObjectModel;

namespace LotteryTools.ViewModels
{
    public partial class LotteryCodeViewModel : ObservableObject
    {
        // 原始数据
        private LotteryData? lotteryData;
        private LotteryCategoryData? categoryData;

        // 绑定到UI的、过滤后的结果集合（ObservableCollection才能在数据变化时通知UI更新）
        [ObservableProperty]
        private ObservableCollection<string>? searchResults;

        // 彩票分类列表
        [ObservableProperty]
        private ObservableCollection<LotteryCategory> categories;
        [ObservableProperty]
        private LotteryCategory selectedCategory;

        // 当前选择的彩种类型
        public LotteryType LotteryType { get; private set; }
        // 搜索的彩票代码
        public string SearchCode { get; set; } = string.Empty;

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="lotteryType">彩票类型</param>
        /// <returns></returns>
        public async Task LoadData(LotteryType lotteryType)
        {
            // 确保数据已加载
            if (lotteryData == null || categoryData == null)
            {
                await LotteryDataLoader.Instance.Initialize();
                lotteryData = LotteryDataLoader.Instance.Data;
                categoryData = LotteryDataLoader.Instance.CategoryData;
            }

            // 初始化时显示所有项目
            LotteryType = lotteryType;
            SearchResults = new ObservableCollection<string>(lotteryData.GetLotteryStringList(LotteryType));
            Categories = new ObservableCollection<LotteryCategory>(categoryData.GetLotteryCategories(LotteryType));
            SelectedCategory = categoryData.GetLotteryCategories(LotteryType).First(); // 默认选择“全部”类别
        }

        /// <summary>
        /// 搜索命令 - 使用RelayCommand，并接受一个string类型的参数（即搜索文本）
        /// </summary>
        /// <param name="code">查询字符</param>
        [RelayCommand]
        private void PerformSearch(string code)
        {
            SearchCode = code;

            if (lotteryData == null)
                return;

            if (string.IsNullOrWhiteSpace(code))
            {
                // 如果查询为空，显示所有项目
                SearchResults = new ObservableCollection<string>(lotteryData.SearchLotteries(LotteryType, code, SelectedCategory.Rewards).Select(l => l.ToString()));
                return;
            }

            // 执行过滤逻辑：查找包含查询字符串的项（不区分大小写）
            var filteredItems = lotteryData.SearchLotteries(LotteryType, code, SelectedCategory.Rewards).Select(l => l.ToString());
            SearchResults = new ObservableCollection<string>(filteredItems);
        }

        partial void OnSelectedCategoryChanged(LotteryCategory value)
        {
            // 执行过滤逻辑：查找包含查询字符串的项（不区分大小写）
            var filteredItems = lotteryData.SearchLotteries(LotteryType, SearchCode, SelectedCategory.Rewards).Select(l => l.ToString());
            SearchResults = new ObservableCollection<string>(filteredItems);
        }
    }
}
