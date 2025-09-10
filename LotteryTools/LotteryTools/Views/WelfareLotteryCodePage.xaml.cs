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
            // ��ȡ ViewModel ��ִ�м�������
            if (BindingContext is LotteryCodeViewModel viewModel)
            {
                await viewModel.LoadData(LotteryType.WelfareLottery);
            }
        }
        catch (Exception ex)
        {
            // ������ع����п��ܳ��ֵ��쳣
            await DisplayAlert("Error", "Failed to load data: " + ex.Message, "OK");
        }
    }
}