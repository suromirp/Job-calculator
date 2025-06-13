using Eindopdracht___Programmeren_in_C____LOI.Database;
using Eindopdracht___Programmeren_in_C____LOI.Models;
using System.Data.SQLite;

namespace Eindopdracht___Programmeren_in_C____LOI.Service
{
    /// <summary>
    /// Berekent asynchroon de kans op een baan voor een persoon met progress bar voor bijhouden van voortgang
    /// </summary>
    public static class ChanceCalculator
    {

        #region Velden & Events

        private static readonly Random rnd = new Random();
        private static PersonResult? highestChange = null;

        /// <summary>
        /// Wordt aangeroepen zodra er een nieuwe hoogste kans is berekend
        /// </summary>
        public static event Action<PersonResult>? OnHighestChangeCalculated;

        #endregion

        #region Kans Berekening

        /// <summary>
        /// Bereken de kans op een baan voor <paramref name="name"/> en rapporteer voortgang tijdens de berekening
        /// </summary>
        /// <param name="name">De naam van de persoon waarvoor de kans wordt berekend</param>
        /// <param name="panelProgress">Rapporteert de voortgang van deze specifieke berekening (0–100%)</param>
        /// <param name="overallProgress">Rapporteert de algemene voortgang (increment met 1 bij voltooide berekening)</param>
        /// <param name="cancellationToken">
        /// Een token dat gebruikt wordt om de berekening voortijdig te annuleren, bijvoorbeeld wanneer het paneel wordt verwijderd.
        /// </param>
        /// <returns>
        /// Een <see cref = "PersonResult" /> met de naam, een willekeurige baan en de berekende baankans
        /// </returns>
        /// <exception cref="OperationCanceledException">
        /// Wordt gegooid als de gebruiker de berekening annuleert via een <see cref="CancellationToken"/>
        /// </exception>
        public static async Task<PersonResult> CalculateChanceAsync(
            string name,
            IProgress<int> panelProgress,
            IProgress<int> overallProgress,
            CancellationToken cancellationToken)
        {
            int totalSteps = rnd.Next(10, 100);

            for (int i = 0; i <= totalSteps; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(rnd.Next(100, 1001), cancellationToken);
                int pct = (int)(i / (double)totalSteps * 100);
                panelProgress.Report(pct);
            }

            // ↪ paneel is klaar, update total:
            overallProgress.Report(1);

            double EducationChance = rnd.NextDouble();
            double jobChance = rnd.NextDouble();
            double totalChance = EducationChance * jobChance;
            string randomJob = GetRandomJob();

            var result = new PersonResult { Name = name, Job = randomJob, Chance = totalChance };

            if (highestChange == null || result.Chance > highestChange.Chance)
            {
                highestChange = result;
                OnHighestChangeCalculated?.Invoke(result);
            }

            return result;
        }

        #endregion

        #region Database Helper

        /// <summary>
        /// Haalt een willekeurige Job naam op uit de database
        /// </summary>
        /// <returns>
        /// De naam van een random record uit de <c>Jobs</c> tabel of een foutmelding bij een database fout
        /// </returns>
        private static string GetRandomJob()
        {
            try
            {
                using var connection = DatabaseConnectionHelper.CreateOpen();
                var command = new SQLiteCommand(
                    "SELECT Name FROM Jobs ORDER BY RANDOM() LIMIT 1",
                    connection);

                return command.ExecuteScalar()?.ToString() ?? "Unknown";
            }
            catch
            {
                Logger.Log("Fout bij het ophalen van een baan uit de database.", LogLevel.Error);
                return "Fout bij het laden van een baan";
            }
        }

        #endregion
    }
}
