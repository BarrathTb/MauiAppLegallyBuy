namespace MauiAppLegallyBuy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(AgeEntry.Text, out int age) && CountryPicker.SelectedIndex >= 0)
            {
                // Get the selected country as a string
                string selectedCountryString = (string)CountryPicker.SelectedItem;

                // Convert the string to the corresponding Country enum value
                if (Enum.TryParse(selectedCountryString, out Country selectedCountry))
                {
                    int legalDrinkingAge = (int)selectedCountry;
                    int yearsUntilLegalAge = legalDrinkingAge - age;

                    if (yearsUntilLegalAge > 0)
                    {
                        ResultLabel.Text = $"You will be able to drink legally in {yearsUntilLegalAge} years in {selectedCountry}.";
                    }
                    else if (yearsUntilLegalAge == 0)
                    {
                        ResultLabel.Text = $"Congratulations! You are of legal drinking age now in {selectedCountry}.";
                    }
                    else
                    {
                        ResultLabel.Text = $"You are already of legal drinking age in {selectedCountry}.";
                    }
                }
                else
                {
                    ResultLabel.Text = "Invalid country selection.";
                }
            }
            else
            {
                ResultLabel.Text = "Please enter a valid age and select a country.";
            }
        }



    }
}