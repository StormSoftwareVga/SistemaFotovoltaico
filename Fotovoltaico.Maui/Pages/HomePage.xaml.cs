namespace Fotovoltaico.Maui.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private async void NavigateToPersonPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("PersonPage");
        }

    }
}
