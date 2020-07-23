using CitizenApp.Common.Validators;
using CitizenApp.Common.Validators.Rules;
using CitizenApp.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class RegisterThirdViewModel : INotifyPropertyChanged
    {
        private Usuario usuario;
        public ValidatablePair<string> Email { get; set; } = new ValidatablePair<string>();
        public ValidatablePair<string> Password { get; set; } = new ValidatablePair<string>();

        public RegisterThirdViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            AddValidationRules();
        }


        public ICommand ContinuarCommand => new Command(async () =>
        {
            if (AreFieldsValid())
            {
                usuario.Email = Email.Item1.Value.ToString();
                await App.Current.MainPage.DisplayAlert("Exito", "Su cuenta fue creada correctamente.", "Ok");
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        });

        public void AddValidationRules()
        {
            //Email Validation Rules
            Email.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            Email.Item1.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });
            Email.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Confirm Email Required" });
            Email.Validations.Add(new MatchPairValidationRule<string> { ValidationMessage = "Email and confirm email don't match" });

            //Password Validation Rules
            Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            Password.Item1.Validations.Add(new IsValidPasswordRule<string> { ValidationMessage = "Password between 8-20 characters; must contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character" });
            Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Confirm password required" });
            Password.Validations.Add(new MatchPairValidationRule<string> { ValidationMessage = "Password and confirm password don't match" });
            
        }
        bool AreFieldsValid()
        {
           
            bool isEmailValid = Email.Validate();
            bool isPasswordValid = Password.Validate();
            

            return isEmailValid && isPasswordValid;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
