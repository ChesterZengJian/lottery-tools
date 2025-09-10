namespace LotteryTools.ViewModels
{
    public class AboutViewModel
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string Message => "贝贝大王要中大奖！！！";
    }
}
