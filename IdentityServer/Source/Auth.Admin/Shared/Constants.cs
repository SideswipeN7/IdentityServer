using MatBlazor;

namespace Auth.Admin.Shared
{
    public static class Constants
    {
        public const string SecondaryClass = "mdc-theme--secondary-bg mdc-theme--on-secondary";

        public static readonly MatTheme LightTheme = new MatTheme()
        {
            Primary = MatThemeColors.Blue._800.Value,
            //OnPrimary = MatThemeColors.Grey._900.Value,
            Secondary = MatThemeColors.LightBlue._400.Value,
        };

        public static readonly MatTheme DarkTheme = new MatTheme()
        {
            Background = MatThemeColors.Grey._500.Value,
            Primary = MatThemeColors.Grey._900.Value,
            OnPrimary = "#FFFFFF",
            Secondary = "#607d8b",
            OnSecondary = MatThemeColors.Grey._900.Value,
        };
    }
}