using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataValidation.Lab5
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<PersonModel> Persons { get; set; } = new();
        public PersonModel CurrentPersonModel { get; set; } = new();
        public DelegateCommand AddNewUserCommand { get; set; }
        public MainViewModel()
        {
            AddNewUserCommand = new DelegateCommand(AddNewUser, CanAddUser);
            CurrentPersonModel.PersonChanged += UpdateCanAdd;
        }
        private void UpdateCanAdd(object sender, EventArgs e)
        {
            AddNewUserCommand.RaiseCanExecute();
        }
        private void AddNewUser(object obj)
        {
            var enteredUser = CurrentPersonModel.Clone();
            CurrentPersonModel.Reset();
            Persons.Add(enteredUser);
        }
        private bool CanAddUser(object obj) => CurrentPersonModel.IsValid;
    }
}
