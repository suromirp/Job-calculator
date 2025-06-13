using System.Runtime.InteropServices;

namespace Eindopdracht___Programmeren_in_C____LOI.UI
{
    /// <summary>
    /// Controller voor de totale voortgangsbalk (TotalProgressBar) inclusief teller-logic,
    /// styling en kleurbeheer.
    /// </summary>
    public class TotalProgressBarController
    {
        #region Velden
        private int _totalCount;
        private int _completedCount;

        private readonly ToolStripProgressBar _progressBar;
        private readonly ToolStripStatusLabel _fractionLabel;
        private readonly ToolStripStatusLabel _percentageLabel;
        #endregion

        #region PInvoke voor balkkleur
        private const uint PBM_SETBARCOLOR = 0x409;
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Properties

        /// <summary>
        /// Reporter om afgeronde panels aan te geven.
        /// </summary>
        public IProgress<int> CompletionReporter { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Maakt een nieuwe instance en configureert stijl, kleuren en beginwaarden
        /// </summary>
        /// <param name="progressBar">Het <see cref="TotalProgressBarController"/> control</param>
        /// <param name="fractionLabel">Label voor fractionele weergave (bijv. "Gereed: x/y")</param>
        /// <param name="percentageLabel">Label voor procentuele weergave (bijv. "50%")</param>
        /// <param name="initialTotal">Beginwaarde voor totaal aantal personen</param>
        public TotalProgressBarController(
            ToolStripProgressBar progressBar,
            ToolStripStatusLabel fractionLabel,
            ToolStripStatusLabel percentageLabel,
            int initialTotal)
        {
            _progressBar = progressBar;
            _fractionLabel = fractionLabel;
            _percentageLabel = percentageLabel;

            // Teller-initialisatie
            _totalCount = Math.Max(2, initialTotal);
            _completedCount = 0;

            // ProgressBar-instellingen
            _progressBar.Minimum = 0;
            _progressBar.Maximum = _totalCount;
            _progressBar.Value = 0;

            // Reporter instellen
            CompletionReporter = new Progress<int>(delta =>
            {
                _completedCount = Math.Min(_totalCount, _completedCount + delta);
                RefreshUI();
            });

            // Balk-stijl en kleur toepassen
            ApplyStyleAndColor();
        }

        #endregion

        #region UI & Styling

        /// <summary>
        /// Past de styling en blauwe kleur toe via P/Invoke.
        /// </summary>
        private void ApplyStyleAndColor()
        {
            // vloeiende weergave
            _progressBar.ProgressBar.Style = ProgressBarStyle.Continuous;

            // Windows-thema uitzetten zodat PBM_SETBARCOLOR pakt
            SetWindowTheme(_progressBar.ProgressBar.Handle, string.Empty, string.Empty);

            // blauwe kleur toepassen
            IntPtr colorRef = (IntPtr)ColorTranslator.ToWin32(Color.DodgerBlue);
            SendMessage(_progressBar.ProgressBar.Handle, PBM_SETBARCOLOR, IntPtr.Zero, colorRef);
        }

        /// <summary>
        /// Ververs de UI: balk, fractioneel label en percentage-label.
        /// </summary>
        private void RefreshUI()
        {
            int done = Math.Min(_completedCount, _totalCount);
            _progressBar.Maximum = _totalCount;
            _progressBar.Value = done;
            _fractionLabel.Text = $"Gereed: {done}/{_totalCount}";
            _percentageLabel.Text = FormatPercentage(done, _totalCount);
        }

        /// <summary>
        /// Formatteert afgeronde/total als percentage.
        /// </summary>
        private static string FormatPercentage(int completed, int total)
        {
            if (total <= 0) return "0%";
            int pct = (int)(completed * 100.0 / total);
            return $"{pct}%";
        }

        #endregion

        #region Public Methodes

        /// <summary>
        /// Verhoogt de totale teller met 1.
        /// </summary>
        public void IncrementTotal() => UpdateCounters(+1, 0);

        /// <summary>
        /// Verhoogt de voltooide teller met 1.
        /// </summary>
        public void IncrementCompleted() => UpdateCounters(0, +1);

        /// <summary>
        /// Verlaagt alleen de teller voor voltooide items met 1
        /// en ververst de UI.
        /// </summary>
        public void DecrementCompleted()
            => UpdateCounters(totalDelta: 0, completedDelta: -1);

        /// <summary>
        /// Verwijdert een paneel: verlaagt de total-teller met 1 en, als 'done', de complete-teller met 1.
        /// </summary>
        /// <param name="isCompleted">Geeft aan of het verwijderde paneel al voltooid was.</param>
        public void RemovePerson(bool isCompleted) => UpdateCounters(-1, isCompleted ? -1 : 0);

        /// <summary>
        /// Reset alle tellers naar 0.
        /// </summary>
        public void Reset()
            => UpdateCounters(-_totalCount, -_completedCount);

        #endregion

        #region Logic

        /// <summary>
        /// Past teller-delta's toe en ververst de UI.
        /// </summary>
        private void UpdateCounters(int totalDelta, int completedDelta)
        {
            _totalCount = Math.Max(0, _totalCount + totalDelta);
            _completedCount = Math.Max(0, _completedCount + completedDelta);
            RefreshUI();
        }

        #endregion
    }
}
