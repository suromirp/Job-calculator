using WinFormsTimer = System.Windows.Forms.Timer;

namespace Eindopdracht___Programmeren_in_C____LOI.UI
{
    /// <summary>
    /// Container voor alle UI componenten van een PersonPanel, zodat deze als één object kan worden doorgegeven en opgebouwd
    /// </summary>
    public class PersonPanelComponents
    {
        /// <summary>
        /// Het hoofd <see cref="Panel"/> waarin alle sub componenten worden geplaatst
        /// </summary>
        public Panel MainPanel = null!;

        /// <summary>
        /// <see cref="TableLayoutPanel"/> dat de content organiseert
        /// </summary>
        public TableLayoutPanel ContentPanel = null!;

        /// <summary>
        /// Knop om het paneel te sluiten en de persoon te verwijderen
        /// </summary>
        public Button CloseButton = null!;

        /// <summary>
        /// Knop om bewerken van invoervelden te activeren
        /// </summary>
        public Button EditButton = null!;

        /// <summary>
        /// Label om validatiefouten (ongeldige karakters) weer te geven
        /// </summary>
        public Label ErrorLabel = null!;

        /// <summary>
        /// <see cref="TextBox"/> voor het invoeren van de naam
        /// </summary>
        public TextBox NameTextBox = null!;

        /// <summary>
        /// <see cref="ComboBox"/> voor de selectie van een opleiding
        /// </summary>
        public ComboBox EducationComboBox = null!;

        /// <summary>
        /// Voor het weergeven van de avatar afbeelding
        /// </summary>
        public PictureBox AvatarBox = null!;

        /// <summary>
        /// <see cref="ProgressBar"/> om de voortgang van berekeningen te tonen
        /// </summary>
        public ProgressBar ProgressBar = null!;

        /// <summary>
        /// Knop om de berekeningen van een baankans te starten
        /// </summary>
        public Button CalculateButton = null!;

        /// <summary>
        /// Label waarin de baankans als percentage wordt aangetoond
        /// </summary>
        public Label ResultLabel = null!;

        /// <summary>
        /// Label met vaste tekst "Hoogste baankans op"
        /// </summary>
        public Label HighestJobTextLabel = null!;

        /// <summary>
        /// Label waarin de naam van de baan met de hoogste kans wordt getoond
        /// </summary>
        public Label HighestJobLabel = null!;

        /// <summary>
        /// Timer om na een korte typ pauze de avatar afbeelding te laden
        /// </summary>
        public WinFormsTimer AvatarLoadTimer = null!;

        /// <summary>
        /// Geeft aan of het paneel momenteel in bewerkmodus staat
        /// </summary>
        public bool IsEditing { get; set; } = false;

        /// <summary>
        /// Geeft aan of het paneel momenteel een berekening uitvoert
        /// </summary>
        public bool IsCalculating { get; set; } = false;

        /// <summary>
        /// Geeft aan of de berekening succesvol is afgerond
        /// </summary>
        public bool Iscompleted { get; set; } = false;

        /// <summary>
        /// De laatst berekende opleiding, gebruikt om wijzigingen te detecteren
        /// </summary>
        public string LastCalculatedEducation { get; set; } = "";

        /// <summary>
        /// Token waarmee een lopende berekening kan worden geannuleerd
        /// </summary>
        public CancellationTokenSource? CalculationTokenSource { get; set; }
    }
}
