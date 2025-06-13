using Eindopdracht___Programmeren_in_C____LOI.Models;

namespace Eindopdracht___Programmeren_in_C____LOI.UI
{
    /// <summary>
    /// Zorgt voor de dynamische aanmaak van een paneel waarin gegevens van een persoon getoond en bewerkt kunnen worden
    /// </summary>
    public static class PersonPanel
    {
        /// <summary>
        /// Bouwt een nieuw <see cref="Panel"/> met UI-componenten voor een persoon en voegt dit toe aan het opgegeven <paramref name="parentPanel"/>
        /// </summary>
        /// <param name="person">
        /// De <see cref="PersonResult"/> met gegevens van een bestaande persoon, of <c>null</c> voor een leeg formulier
        /// </param>
        /// <param name="parentPanel">
        /// Het <see cref="FlowLayoutPanel"/> waarin het gegenereerde paneel wordt geplaatst
        /// </param>
        /// <param name="panelProgress">
        /// Een <see cref="IProgress{T}"/> voor het rapporteren van voortgang (0–100) per individueel paneel
        /// </param>
        /// <param name="completionReporter">
        /// Een <see cref="IProgress{T}"/> dat een increment rapporteert wanneer een berekening is voltooid
        /// </param>
        /// <param name="skipEducationLoad">
        /// Als <c>true</c>, wordt de lijst met opleidingen niet geladen (bijvoorbeeld bij initiële setup zonder data) Standaard is <c>false</c>
        /// </param>
        /// <returns>
        /// De nieuw gegenereerde <see cref="Panel"/> die is toegevoegd aan het <paramref name="parentPanel"/>
        /// </returns>
        public static Panel Build(
            PersonResult? person,
            FlowLayoutPanel parentPanel,
            IProgress<int> panelProgress,
            IProgress<int> completionReporter,
            bool skipEducationLoad = false)
        {
            // 1 Maakt componenten aan
            var c = PersonPanelFactory.CreateComponents();

            // 2 Stel de layout in
            PersonPanelFactory.SetupLayout(c);

            // 3 Koppel eventhandlers — én geef de progress-objecten door!
            PersonPanelFactory.AttachEvents(c, parentPanel, panelProgress, completionReporter);

            // 4 Vul met bestaande data als die beschikbaar is
            if (person != null)
                PersonPanelFactory.PopulateWithPersonData(c, person);

            // 5 Voeg toe aan het parent paneel en return
            parentPanel.Controls.Add(c.MainPanel);
            return c.MainPanel;
        }
    }
}