namespace Fotovoltaico.Maui.Pages
{
    public partial class EditPersonPage : ContentPage
    {
        public EditPersonPage(EditPersonViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
