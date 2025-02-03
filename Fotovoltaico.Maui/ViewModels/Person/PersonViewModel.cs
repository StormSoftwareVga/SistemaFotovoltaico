using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Interfaces.Services;
using Fotovoltaico.Maui.Pages;
using System.Collections.ObjectModel;

namespace Fotovoltaico.Maui.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        private readonly IPersonService _personService;
        private ObservableCollection<PersonDto> _persons;

        public ObservableCollection<PersonDto> Persons
        {
            get => _persons;
            set => SetProperty(ref _persons, value);
        }

        public Command LoadPersonsCommand { get; }
        public Command AddPersonCommand { get; }
        public Command<PersonDto> EditPersonCommand { get; }
        public Command<PersonDto> DeletePersonCommand { get; }

        public PersonViewModel(IPersonService personService)
        {
            _personService = personService;
            LoadPersonsCommand = new Command(async () => await LoadPersons());
            AddPersonCommand = new Command(async () => await AddPerson());
            EditPersonCommand = new Command<PersonDto>(async (person) => await EditPerson(person));
            DeletePersonCommand = new Command<PersonDto>(async (person) => await DeletePerson(person));
        }

        private async Task LoadPersons()
        {
            var people = await Task.Run(() => _personService.Get());
            Persons = new ObservableCollection<PersonDto>(people);
        }

        private async Task AddPerson()
        {
            await Shell.Current.GoToAsync(nameof(AddPersonPage));
        }

        private async Task EditPerson(PersonDto person)
        {
            await Shell.Current.GoToAsync($"{nameof(EditPersonPage)}?id={person.Id}");
        }

        private async Task OnPersonTapped(PersonDto person)
        {
            await Shell.Current.GoToAsync($"{nameof(EditPersonPage)}?id={person.Id}");
        }

        private async Task DeletePerson(PersonDto person)
        {
            var success = await Task.Run(() => _personService.Delete(person.Id.ToString()));
            if (success)
            {
                await LoadPersons();
            }
        }
    }
}
