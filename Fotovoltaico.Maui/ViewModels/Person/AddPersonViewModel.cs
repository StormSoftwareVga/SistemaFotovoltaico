using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Interfaces.Services;
using Fotovoltaico.Maui.Pages;

namespace Fotovoltaico.Maui
{
    public class AddPersonViewModel : BaseViewModel
    {
        private readonly IPersonService _personService;

        public string Name { get; set; }
        public string Email { get; set; }

        public Command SaveCommand { get; }

        public AddPersonViewModel(IPersonService personService)
        {
            _personService = personService;
            SaveCommand = new Command(async () => await SavePerson());
        }

        private async Task SavePerson()
        {
            var personDto = new PersonDto
            {
                Name = Name,
                Email = Email
            };

            var success = await Task.Run(() => _personService.Post(personDto));

            if (success)
            {
                await Shell.Current.GoToAsync(nameof(PersonPage));
            }
        }
    }
}
