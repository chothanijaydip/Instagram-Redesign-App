namespace InstagramRedesignApp
{
    public interface IStatusBar
    {
        int GetHeight();
        void SetLightStatusBar(bool light);
        void SetFullscreen(bool fullscreen);
    }
}
