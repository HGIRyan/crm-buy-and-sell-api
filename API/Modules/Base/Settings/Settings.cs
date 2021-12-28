namespace API.Modules.Base.Settings
{
    public class Settings : ISettings
    {
        public static Settings Current;

        public Settings()
        {
            Current = this;
        }
        
    }
}