using Eindopdracht___Programmeren_in_C____LOI.Service;
using System.Data.SQLite;
using System.Reflection;

namespace Eindopdracht___Programmeren_in_C____LOI.Database
{

    /// <summary>
    /// Verantwoordelijk voor het uitpakken van de embedded SQLite-template
    /// en het (her)initialiseren van de database in AppData.
    /// </summary>
    public static class DatabaseInitializer
    {

        #region Constants & Paden

        /// <summary>
        /// Fysiek pad naar de SQLite-database in %AppData%\Eindopdracht___Programmeren_in_C
        /// </summary>
        public static readonly string DatabaseFilePath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Eindopdracht___Programmeren_in_C",
                "SQLite.db"
                );

        /// <summary>
        /// Naam van de embedded resource die de template-database bevat
        /// </summary>
        private const string DbResourceName = "Eindopdracht___Programmeren_in_C____LOI.Data.SQLite.db";

        #endregion

        #region Initialisatie

        /// <summary>
        /// Initialiseert de database: pakt de template uit en opent een verbinding
        /// Indien tabellen ontbreken, wordt de database force-gereset
        /// </summary>
        public static void InitializeDatabase()
        {

            try
            {
                EnsureDatabaseFile();

                using var connection = DatabaseConnectionHelper.CreateOpen();

                if (!TablesExist(connection))
                {
                    Logger.Log("Ontbrekende tabellen, opnieuw creëren", LogLevel.Warning);
                    ForceRecreateDatabase();
                }
                else
                {
                    Logger.Log("Database is correct, geen actie nodig", LogLevel.Info);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Kritieke fout bij initialisatie: " + ex.Message, LogLevel.Error);
                MessageBox.Show(
                    "Er is een fout opgetreden bij het initialiseren van de database.\n" +
                    "Zie de logs voor details",
                    "Database Fout",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Environment.Exit(1);
            }
        }

        #endregion

        #region Directory & Bestandsbeheer

        /// <summary>
        /// Maakt de directory aan voor de database als deze nog niet bestaat
        /// </summary>
        private static void EnsureDirectoryExists()
        {
            var dir = Path.GetDirectoryName(DatabaseFilePath)!;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        /// <summary>
        /// Pakt de embedded SQLite.db-template uit naar <see cref="DatabaseFilePath"/>
        /// bij de eerste run of na een force-reset
        /// </summary>
        /// <exception cref="FileNotFoundException">
        /// Als de embedded resource niet in de assembly wordt gevonden
        /// </exception>
        private static void EnsureDatabaseFile()
        {
            EnsureDirectoryExists();

            if (File.Exists(DatabaseFilePath))
                return;

            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(DbResourceName)
                               ?? throw new InvalidOperationException(
                                   $"Resource {DbResourceName} niet gevonden in assembly");

            using var file = File.Create(DatabaseFilePath);
            stream.CopyTo(file);

            Logger.Log($"Embedded database uitgepakt naar {DatabaseFilePath}", LogLevel.Info);
        }

        /// <summary>
        /// Verwijdert de bestaande databasefile en pakt de embedded template opnieuw uit
        /// </summary>
        /// <remarks>
        /// Gebruikt GC.Collect() om open filehandles te sluiten voordat delete
        /// </remarks>
        public static void ForceRecreateDatabase()
        {
            try
            {
                Logger.Log("ForceRecreateDatabase gestart", LogLevel.Warning);

                // Sluit open handles
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (File.Exists(DatabaseFilePath))
                {
                    File.Delete(DatabaseFilePath);
                    Logger.Log("Bestaande database verwijderd", LogLevel.Info);
                }

                // Unpack opnieuw
                EnsureDatabaseFile();
                Logger.Log("Database opnieuw uitgepakt", LogLevel.Info);
            }
            catch (Exception ex)
            {
                Logger.Log("Fout bij het creëren van database " + ex.Message, LogLevel.Error);
                throw;
            }
        }

        #endregion

        #region Tabelcontroller

        /// <summary>
        /// Controleert of alle vereiste tabellen aanwezig zijn in de database
        /// </summary>
        /// <param name="connection">Een geopende SQLite-verbinding.</param>
        /// <returns>
        /// <c>true</c> als de tabellen "Education", "Persons" en "Jobs" allemaal bestaan; anders <c>false</c>
        /// </returns>
        private static bool TablesExist(SQLiteConnection connection)
            => DoesTableExist(connection, "Education")
            && DoesTableExist(connection, "Persons")
            && DoesTableExist(connection, "Jobs");


        /// <summary>
        /// Controleert of een specifieke tabel bestaat in de database
        /// </summary>
        /// <param name="connection">Een geopende SQLite-verbinding.</param>
        /// <param name="tableName">De naam van de tabel om te controleren</param>
        /// <returns><c>true</c> als de tabel bestaat; anders <c>false</c></returns>
        public static bool DoesTableExist(SQLiteConnection connection, string tableName)
        {
            const string query = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName";
            using var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@tableName", tableName);
            return command.ExecuteScalar() != null;
        }

        #endregion
    }
}
