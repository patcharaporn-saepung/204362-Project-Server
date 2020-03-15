namespace MheanMaa.Settings
{
    public class UserSettings : IUserSettings
    {
        public string Secret { get; set; }
    }

    public interface IUserSettings
    {
        public string Secret { get; set; }
    }
}
