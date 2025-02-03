using Fotovoltaico.Domain.Interfaces.Services;
using Fotovoltaico.Domain.Services;

namespace Fotovoltaico.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
