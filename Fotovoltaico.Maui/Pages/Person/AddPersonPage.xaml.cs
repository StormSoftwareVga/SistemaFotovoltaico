using Fotovoltaico.Domain.Entities.DataTransferObjects.Person;
using Fotovoltaico.Domain.Interfaces.Services;
using System;

namespace Fotovoltaico.Maui.Pages
{
    public partial class AddPersonPage : ContentPage
    {
        private IPersonService _personService;
        private string _name;
        private string _email;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public AddPersonPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public void Initialize(IPersonService personService)
        {
            _personService = personService;
        }

        private async void SavePerson(object sender, EventArgs e)
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
