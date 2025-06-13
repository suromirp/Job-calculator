using Eindopdracht___Programmeren_in_C____LOI.Database;

namespace Eindopdracht___Programmeren_in_C____LOI
{
    /// <summary>
    ///  Entry point van de applicatie, initialiseert eerst de database en start daarna de GUI
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Main-methode: configureert de applicatie, initialiseert de database en toont <see cref="MainForm"/>
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Sta slechts één instantie van de applicatie toe
            bool createdNew;
            using var mutex = new Mutex(true, "Eindopdracht_JobCalculator_Mutex", out createdNew);

            if (!createdNew)
            {
                MessageBox.Show(
                    "De applicatie is al geopend.\nSluit de andere instantie voordat je deze opent.",
                    "Applicatie al actief",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Zorg dat de database wordt uitgepakt en optijd op orde is
            DatabaseInitializer.InitializeDatabase();

            // Start het GUI venster
            Application.Run(new MainForm());
        }
    }
}
