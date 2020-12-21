using Microsoft.AspNetCore.Components;

namespace Auth.Admin.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        protected const string AppName = "Auth Admin";

        protected bool Opened { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        protected void ToggleDrawer() => Opened = !Opened;

        protected void NavigateHome() => NavigationManager.NavigateTo("");
    }
}