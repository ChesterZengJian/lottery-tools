using LotteryTools.Common.Enums;
using LotteryTools.ViewModels;

namespace LotteryTools.Views;

public partial class WelfareLotteryCodePage : ContentPage
{
    public WelfareLotteryCodePage()
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
                await viewModel.LoadData(LotteryType.WelfareLottery);
            }
        }
        catch (Exception ex)
        {
            // 处理加载过程中可能出现的异常
            await DisplayAlert("Error", "Failed to load data: " + ex.Message, "OK");
        }
    }
}