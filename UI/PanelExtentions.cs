namespace Eindopdracht___Programmeren_in_C____LOI.UI
{
    /// <summary>
    /// Bevat extensiemethoden voor <see cref="Panel"/>, zoals het bijwerken van een bijbehorende <see cref="ProgressBar"/>.
    /// </summary>
    public static class PanelExtensions
    {
        /// <summary>
        /// Zoekt binnen het opgegeven <paramref name="panel"/> naar de eerste <see cref="ProgressBar"/> en stelt de waarde daarvan in op het opgegeven percentage
        /// </summary>
        /// <param name="panel">
        /// Het <see cref="Panel"/> waarin gezocht wordt naar een <see cref="ProgressBar"/>
        /// De methode gaat ervan uit dat de <see cref="ProgressBar"/> zich bevindt binnen een <see cref="TableLayoutPanel"/>
        /// </param>
        /// <param name="percent">
        /// De voortgangswaarde (0–100) die moet worden ingesteld. Deze wordt automatisch beperkt tot de toegestane minimum en maximumwaarden van de <see cref="ProgressBar"/>
        /// </param>
        public static void ReportPanelProgress(this Panel panel, int percent)
        {
            var pb = panel
                .Controls
                .OfType<TableLayoutPanel>()
                .SelectMany(tlp => tlp.Controls.OfType<ProgressBar>())
                .FirstOrDefault();

            if (pb != null)
            {
                pb.Value = Math.Clamp(percent, pb.Minimum, pb.Maximum);
            }
        }
    }
}