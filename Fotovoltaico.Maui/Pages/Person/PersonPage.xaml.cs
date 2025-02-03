using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Interfaces.Services;
using Fotovoltaico.Domain.Services;
using System.Collections.ObjectModel;

namespace Fotovoltaico.Maui.Pages
{
    public partial class PersonPage : ContentPage
    {
        private readonly IPersonService _personService;
        public ObservableCollection<PersonDto> Persons { get; set; } = new();

        public PersonPage(IPersonService service)
        {
            _personService = service;
            InitializeComponent();
            LoadPerson();
        }

        private async void LoadPerson()
        {
            var people = await Task.Run(() => _personService.Get());
            Persons = new ObservableCollection<PersonDto>(people);
            BindingContext = this;
        }

        private async void AddPerson(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddPersonPage));
        }

        private async void EditPerson(object sender, EventArgs e)
        {
            if (sender is VisualElement element && element.BindingContext is PersonDto person)
            {
                await Shell.Current.GoToAsync($"{nameof(EditPersonPage)}?id={person.Id}");
            }
        }

        private async void DeletePerson(PersonDto person)
        {
            var success = await Task.Run(() => _personService.Delete(person.Id.ToString()));
            if (success)
            {
                LoadPerson();
            }
        }
    }
}
