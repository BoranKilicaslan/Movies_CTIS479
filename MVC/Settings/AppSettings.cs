namespace MVC.Settings
{
    public class AppSettings
    {
        // static is used for directly reaching the value of the properties using the class name, 
        // for example AppSettings.AppTitle or AppSettings.AppVersion without initialization.
        // We can easily reach these properties in views and controller actions.
        // static can be thought as a shared resource throughout the application, however
        // only shared resources such as application configuration which will effect all the users
        // of the application should be declared static, otherwise one change that a user performs
        // may effect other users when they are using the application.

        public static string AppTitle { get; set; }
        public static double AppVersion { get; set; }

        // for managing cookie expiration duration in appsettings.json
        public static int CookieExpirationInMinutes { get; set; }
    }
}
