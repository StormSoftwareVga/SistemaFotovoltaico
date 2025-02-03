using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Interfaces.Services;
using Fotovoltaico.Maui.Pages;

namespace Fotovoltaico.Maui
{
    public class EditPersonViewModel : BaseViewModel
    {
        private readonly IPersonService _personService;
        private PersonDto _person;

        public PersonDto Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }

        public Command SaveCommand { get; }

        public EditPersonViewModel(IPersonService personService)
        {
            _personService = personService;
            SaveCommand = new Command(async () => await SavePerson());
        }

        private async Task SavePerson()
        {
            var success = await Task.Run(() => _personService.Put(Person));

            if (success)
            {
                await Shell.Current.GoToAsync(nameof(PersonPage));
            }
        }
    }
}
