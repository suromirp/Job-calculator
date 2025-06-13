using Eindopdracht___Programmeren_in_C____LOI.Database;
using Eindopdracht___Programmeren_in_C____LOI.Models;
using Eindopdracht___Programmeren_in_C____LOI.Service;
using Eindopdracht___Programmeren_in_C____LOI.UI;
using WinFormsInvoker = System.Windows.Forms.MethodInvoker;

namespace Eindopdracht___Programmeren_in_C____LOI
{
    /// <summary>
    /// Het hoofdvenster van de applicatie
    /// Bevat UI-logica voor het laden, toevoegen, resetten en verwijderen van personen plus de globale voortgangsbalk en logweergave.
    /// </summary>
    public partial class MainForm : Form
    {
        private TotalProgressBarController _totalProgressController = null!;

        #region Constructor

        /// <summary>
        /// Initialiseert componenten, logger, window props, tellers en total-progress
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeLogger();
            ConfigureWindow();
        }

        #endregion

        #region Load

        /// <summary>
        /// Wordt uitgevoerd nadat het Form geladen is:
        /// - Laadt alle panels (met data of leeg) uit de DB
        /// - Past de thema-styling toe op de totale voortgangsbalk
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSavedPersons();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Koppelt de logger aan de AddLogMessage-methode.
        /// </summary>
        private void InitializeLogger()
        {
            Logger.OnLog += (msg, lvl) => AddLogMessage(msg, lvl);
        }

        /// <summary>
        /// Stel titel, grootte en startpositie van het venster in  
        /// </summary>
        private void ConfigureWindow()
        {
            this.Text = "Eindopdracht - Job Calculator";
            this.MinimumSize = new Size(1000, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        #region Panel management

        /// <summary>
        /// Bouwt een PersonPanel, voegt het toe aan de layout en zet de progress op 0 of 100%.
        /// Verhoogt niet de totale teller (die gebeurt in InitializeCounters of AddPerson-knop).
        /// </summary>
        /// <param name="person">De data om te tonen, of null voor een leeg paneel.</param>
        /// <param name="skipEducationLoad">Of we de dropdown niet uit de DB laden.</param>
        private void CreatePersonPanel(PersonResult? person, bool skipEducationLoad = false)
        {
            // Eerst de Progress reporter aanmaken
            Panel panel = null!;
            IProgress<int> panelProgress = new Progress<int>(pct => panel.ReportPanelProgress(pct));

            // Dan het panel bouwen
            panel = PersonPanel.Build(
                person,
                mainLayoutPanel,
                panelProgress,
                _totalProgressController.CompletionReporter,
                skipEducationLoad: skipEducationLoad
            );

            int progress = person is null ? 0 : 100;
            panelProgress.Report(progress);
            if (progress == 100)
            {
                _totalProgressController.CompletionReporter.Report(100);
            }
        }

        /// <summary>
        /// Laadt personen uit de database en maakt voor ieder een panel aan.
        /// Als er geen personen zijn, worden er twee lege panels toegevoegd.
        /// De voortgangsbalk wordt ingesteld op het totaal aantal panels.
        /// </summary>

        private void LoadSavedPersons()
        {
            var persons = PersonRepository.GetAll();

            if (persons.Any())
            {
                _totalProgressController = new TotalProgressBarController(
                   totalProgressBar,
                   totalStatusLabel,
                   statusPercentage,
                   persons.Count
               );

                foreach (var p in persons)
                {
                    CreatePersonPanel(p);
                    Logger.Log($"{p.Name} geladen uit database", LogLevel.Info);
                }

                Logger.Log($"{persons.Count} opgeslagen personen geladen uit de database", LogLevel.Info);
            }
            else
            {
                _totalProgressController = new TotalProgressBarController(
                totalProgressBar,
                totalStatusLabel,
                statusPercentage,
                2
            );

                for (int i = 0; i < 2; i++)
                    AddNewPersonPanel(false);

                Logger.Log("Geen personen gevonden. Twee lege personen toegevoegd.", LogLevel.Info);
            }
        }

        /// <summary>
        /// Voegt een nieuw leeg persoonspanel toe:
        /// 1) Verhoogt de totale teller
        /// 2) Bouwt het paneel (met panel-en overall-progress reporters)
        /// 3) Resets de progressie naar 0%
        /// 4) Logt de actie
        /// </summary>
        private void AddNewPersonPanel(bool incrementTotal = true)
        {
            if (incrementTotal)
                _totalProgressController.IncrementTotal();

            CreatePersonPanel(person: null, skipEducationLoad: true);
            Logger.Log("Nieuw persoon toegevoegd", LogLevel.Info);
        }

        /// <summary>
        /// EventHandler voor de Add Person knop.
        /// Delegeert naar <see cref="AddNewPersonPanel"/>
        /// </summary>
        private void BtnAddPerson_Click(object sender, EventArgs e)
        {
            AddNewPersonPanel();
        }

        /// <summary>
        /// Verwijdert alle panels uit MainLayoutPanel en voegt er twee lege panels aan toe.
        /// </summary>
        private void ClearAndAddDefaultPanels()
        {
            mainLayoutPanel.Controls.Clear();

            _totalProgressController.Reset();

            // Voeg twee lege panels toe
            for (int i = 0; i < 2; i++)
                AddNewPersonPanel();
        }

        #endregion

        #region Cancel

        /// <summary>
        /// Annuleert alle lopende berekeningen in actieve panels
        /// </summary>
        private void CancelAllPersonCalculations()
        {
            foreach (Control ctrl in mainLayoutPanel.Controls)
            {
                if (ctrl is Panel panel && panel.Tag is PersonPanelComponents c)
                {
                    try
                    {
                        c.CalculationTokenSource?.Cancel();
                        c.CalculationTokenSource?.Dispose();
                        c.CalculationTokenSource = null;
                    }
                    catch
                    {
                        // negeren als annuleren niet lukt
                    }
                }
            }
        }

        #endregion

        #region Menu-handlers

        /// <summary>
        /// Handler voor Initialiseren in het menu: reset database én UI.
        /// </summary>
        private void InitialisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string msg = "Wil je de database opnieuw initialiseren?\nLet op: alle gegevens gaan verloren.";
            if (!ConfirmAction(msg, "Bevestiging"))
                return;

            Logger.Log("Initialisatie gestart", LogLevel.Warning);

            CancelAllPersonCalculations();
            _totalProgressController.Reset();
            DatabaseInitializer.ForceRecreateDatabase();
            ClearAndAddDefaultPanels();

            Logger.Log("Initialisatie succesvol afgerond", LogLevel.Info);
        }

        /// <summary>
        /// Handler voor “Reset” in het menu: verwijdert alle personen uit DB én UI.
        /// </summary>
        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string msg = "Weet je zeker dat je alle personen wilt verwijderen?";
            if (!ConfirmAction(msg, "Bevestiging"))
                return;

            Logger.Log("Alle personen worden verwijderd", LogLevel.Warning);

            CancelAllPersonCalculations();
            _totalProgressController.Reset();
            PersonRepository.DeleteAll();
            ClearAndAddDefaultPanels();
        }

        /// <summary>
        /// EventHandler voor “Exit” in het menu.
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        /// <summary>
        /// Handler voor het weergeven van de handleiding
        /// </summary>
        private void ManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowManual();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Weergeeft yes/no MessageBox en retourneert true bij “Yes”.
        /// </summary>
        private bool ConfirmAction(string message, string caption)
        {
            return MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ) == DialogResult.Yes;
        }

        /// <summary>
        /// Sluit de applicatie na bevestiging van de gebruiker.
        /// </summary>
        private void ExitApplication()
        {
            const string msg = "Applicatie afsluiten?";
            if (ConfirmAction(msg, "Bevestiging"))
                Close();
        }

        /// <summary>
        /// Opent het venster met de handleiding.
        /// </summary>
        private void ShowManual()
        {
            new ManualForm().Show();
        }

        #endregion

        #region Cleanup

        /// <summary>
        /// Loopt bij het sluiten nog een laatste cleanup-actie af:
        /// annuleert berekeningen en logt de afsluiting.
        /// </summary>
        private void CleanupBeforeExit()
        {
            CancelAllPersonCalculations();
            Logger.Log("Applicatie wordt afgesloten", LogLevel.Warning);
        }

        /// <summary>
        /// Override van FormClosing om resources netjes vrij te geven.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CleanupBeforeExit();
            base.OnFormClosing(e);
        }

        #endregion

        #region Logging

        /// <summary>
        /// Voegt een logregel toe aan de LogBox, met kleur en prefix afhankelijk van het loglevel.
        /// Thread-safe: werkt via Invoke indien nodig.
        /// </summary>
        /// <param name="message">De tekst van de logregel.</param>
        /// <param name="level">Het <see cref="LogLevel"/> (Info, Warning, Error).</param>
        public void AddLogMessage(string message, LogLevel level = LogLevel.Info)
        {
            if (!IsLogBoxAccessible()) return;

            var timestamped = $"{DateTime.Now:t} - {GetLogPrefix(level)}{message}{Environment.NewLine}";
            var color = GetLogColor(level);
            AppendToLogBox(timestamped, color);
        }

        /// <summary>
        /// Controleert of de LogBox bestaat, niet is disposed en een handle heeft.
        /// </summary>
        private bool IsLogBoxAccessible()
            => logBox is not null && !logBox.IsDisposed && logBox.IsHandleCreated;

        /// <summary>
        /// Bepaalt de prefix voor een loglevel.
        /// </summary>
        private static string GetLogPrefix(LogLevel level)
            => level switch
            {
                LogLevel.Warning => "[WAARSCHUWING] ",
                LogLevel.Error => "[FOUT] ",
                _ => "[INFO] "
            };

        /// <summary>
        /// Bepaalt de kleur voor een loglevel.
        /// </summary>
        private static Color GetLogColor(LogLevel level)
            => level switch
            {
                LogLevel.Warning => Color.DarkOrange,
                LogLevel.Error => Color.Red,
                _ => Color.Black
            };

        /// <summary>
        /// Voegt de <paramref name="text"/> toe aan de LogBox in de gegeven <paramref name="color"/>,
        /// via Invoke als we niet op de UI-thread zitten.
        /// </summary>
        private void AppendToLogBox(string text, Color color)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke((WinFormsInvoker)(() => AppendToLogBox(text, color)));
                return;
            }

            logBox.SelectionStart = logBox.TextLength;
            logBox.SelectionLength = 0;
            logBox.SelectionColor = color;
            logBox.AppendText(text);
            logBox.SelectionColor = logBox.ForeColor;
            logBox.ScrollToCaret();
        }

        #endregion

        #region Public

        /// <summary>
        /// Verwijdert één persoon uit de total-progress controller,
        /// en vermindert indien nodig ook het completed?aantal.
        /// </summary>
        /// <param name="wasDone">
        /// Geeft aan of het verwijderde paneel al voltooid was.
        /// </param>
        public void RemovePersonFromProgress(bool wasDone)
        {
            _totalProgressController.RemovePerson(wasDone);
        }

        /// <summary>
        /// Verlaagt de voltooide teller met 1 bij bewerken.
        /// </summary>
        public void DecrementCompletedPerson()
            => _totalProgressController.DecrementCompleted();

        #endregion
    }
}