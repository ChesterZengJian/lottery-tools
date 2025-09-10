using LotteryTools.Common.Enums;
using LotteryTools.Services;
using LotteryTools.ViewModels;

namespace LotteryTools
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LotteryCodeViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                // 获取 ViewModel 并执行加载命令
                if (BindingContext is LotteryCodeViewModel viewModel)
                {
                    await viewModel.LoadData(LotteryType.SportsLottery);
                }
            }
            catch (Exception ex)
            {
                // 处理加载过程中可能出现的异常
                await DisplayAlert("Error", "Failed to load data: " + ex.Message, "OK");
            }
        }
    }
}
