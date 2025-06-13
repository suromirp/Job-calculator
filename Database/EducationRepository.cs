using Eindopdracht___Programmeren_in_C____LOI.Service;
using System.Data.SQLite;

namespace Eindopdracht___Programmeren_in_C____LOI.Database
{
    /// <summary>
    /// Repository voor het ophalen en beheren van opleidingen
    /// Laadt de lijst éénmaal en cache deze
    /// </summary>
    public static class EducationRepository
    {
        /// <summary>
        /// Cache voor de namen van opleidingen, geladen in de static constructor
        /// </summary>
        private static readonly List<string> _cachedNames;

        /// <summary>
        /// Static constructor: laadt én cachet alle opeidingen uit de database bij de eerste keer dat deze class gebruikt wordt
        /// </summary>
        static EducationRepository()
        {
            try
            {
                using var connection = DatabaseConnectionHelper.CreateOpen();
                using var command = new SQLiteCommand("SELECT Name FROM Education", connection);
                using var reader = command.ExecuteReader();

                _cachedNames = new List<string>();
                while (reader.Read())
                    _cachedNames.Add(reader.GetString(0));

                Logger.Log($"EducationRepository: {_cachedNames.Count} opleidingen geladen uit DB", LogLevel.Info);
            }
            catch (SQLiteException ex)
            {
                Logger.Log("Fout bij ophalen opleidingen: " + ex.Message, LogLevel.Error);
                _cachedNames = new List<string>(); // lege fallback
            }
        }

        /// <summary>
        /// Retourneert de volledige lijst van opleidingen uit de cache
        /// </summary>
        /// <returns>
        /// Een nieuwe lijst van alle opleidingennamen, om de interne cache niet te wijzigen
        /// </returns>
        public static List<string> GetAllNames()
        {
            return new List<string>(_cachedNames);
        }

        /// <summary>
        /// Haalt het ID op voor een opleiding met de gegeven naam
        /// of voegt de opleiding toe als deze nog niet bestaat
        /// </summary>
        /// <param name="name">De naam van de opleiding</param>
        /// <returns>
        /// Het bestaande of nieuw aangemaakte ID van de opleiding
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Als het nieuw gegenereerde ID niet kan worden opgehaald
        /// </exception>
        public static int GetOrInsert(string name)
        {
            using var connection = DatabaseConnectionHelper.CreateOpen();

            // Check of de opleiding al bestaat
            using var checkCmd = new SQLiteCommand(
                "SELECT Id FROM Education WHERE Name = @name", connection);
            checkCmd.Parameters.AddWithValue("@name", name);
            var result = checkCmd.ExecuteScalar();
            if (result != null)
            {
                int existingId = Convert.ToInt32(result);
                return existingId;
            }

            // Insert nieuwe opleiding en vraag het ID op
            using var insertCmd = new SQLiteCommand(
                "INSERT INTO Education (Name) VALUES (@name); SELECT last_insert_rowid();",
                connection
            );
            insertCmd.Parameters.AddWithValue("@name", name);
            var newIdObj = insertCmd.ExecuteScalar()
                         ?? throw new InvalidOperationException(
                              "Nieuwe Education ID kon niet opgehaald worden"
                            );
            int newId = Convert.ToInt32(newIdObj);
            Logger.Log($"Nieuwe opleiding '{name}' toegevoegd met ID {newId}", LogLevel.Info);
            return newId;
        }
    }
}
