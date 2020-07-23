using CitizenApp.Views;

using Xamarin.Forms;

namespace CitizenApp.Common
{
    public class LoginModalPage : CarouselPage
    {
        ContentPage login;

        public LoginModalPage(ILoginManager ilm)
        {
            login = new MainLoginPage(ilm);

            this.Children.Add(login);
            MessagingCenter.Subscribe<ContentPage>(this, "Login", (sender) =>
            {
                this.SelectedItem = login;
            });

        }
    }
}
