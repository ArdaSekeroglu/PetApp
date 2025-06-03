namespace PetApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            ApplicationConfiguration.Initialize();

            var settings = Properties.Settings.Default;
            string musicPath = Path.Combine(Application.StartupPath, "arkadasimPet.wav");
            if (settings.RememberMe && settings.SavedUserId > 0)
            {
                TempUser.KullaniciId = settings.SavedUserId;
                Application.Run(new SelectPetForm());
            }
            else
            {
                Application.Run(new GirisSayfasi());
            }
        }
    }
}
