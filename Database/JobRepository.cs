using Eindopdracht___Programmeren_in_C____LOI.Service;
using System.Data.SQLite;

namespace Eindopdracht___Programmeren_in_C____LOI.Database
{
    /// <summary>
    /// Repository voor het ophalen van job gegevens uit de database
    /// </summary>
    public static class JobRepository
    {
        /// <summary>
        /// Haalt het ID op van een baan met de gegeven naam
        /// </summary>
        /// <param name="jobName">De naam van de baan om op te zoeken</param>
        /// <returns>Het database ID van de baan</returns>
        /// <exception cref="InvalidOperationException">
        /// Als de baan niet voorkomt in de job tabel
        /// </exception>
        public static int GetJobIdByName(string jobName)
        {
            using var connection = DatabaseConnectionHelper.CreateOpen();
            using var command = new SQLiteCommand("SELECT Id FROM Jobs WHERE Name = @name", connection);
            command.Parameters.AddWithValue("@name", jobName);

            object result = command.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result);
            }

            Logger.Log($"Baan {jobName} niet gevonden in database", LogLevel.Error);
            throw new InvalidOperationException($"Baan {jobName} niet gevonden in database");
        }
    }
}
