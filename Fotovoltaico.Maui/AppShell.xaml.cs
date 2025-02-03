using Fotovoltaico.Maui.Pages;

namespace Fotovoltaico.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeRouting();
            InitializeComponent();
        }

        public static void InitializeRouting()
        {
            Routing.RegisterRoute("PersonPage", typeof(PersonPage));
        }
    }
}
