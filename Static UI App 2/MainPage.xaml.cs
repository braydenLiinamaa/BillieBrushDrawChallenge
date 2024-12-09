namespace Static_UI_App_2
{
    public partial class MainPage : ContentPage
    {
        String[] characters = { "cat", "dog", "bird", "fish", "person"};
        String[] actions = { "running", "dancing", "doing a backflip", "playing an instrument", "just standing there, menacingly" };
        String[] locations = { "in the middle of a city", "in a small village", "in the forest", "in a park", "on the street" };

        public MainPage()
        {
            InitializeComponent();
        }

        private void GenerateTheme()
        {
            Random random = new Random();
            int x = random.Next(0, characters.Length);
            int y = random.Next(0, actions.Length);
            int z = random.Next(0, locations.Length);
            String currentTheme = $"Todays Theme: Draw a {characters[x]}" 
                + ((random.Next(3) == 1) ? $" {actions[y]} " : " ") + ((random.Next(3) == 1) ? $"{locations[z]}." : ".");
        }
    }

}
