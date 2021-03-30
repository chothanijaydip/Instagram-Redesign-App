namespace InstagramRedesignApp.Core
{
    public interface IPostDetailPageViewModel : IBaseViewModel
    {
        Post CurrentPost { get; set; }
    }
}