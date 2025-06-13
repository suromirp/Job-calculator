using System.Data.SQLite;

namespace Eindopdracht___Programmeren_in_C____LOI.Database
{
    /// <summary>
    /// Biedt een helper om een SQLite-verbinding te openen tegen de
    /// database op de locatie <see cref="DatabaseInitializer.DatabaseFilePath"/>.
    /// </summary>
    public static class DatabaseConnectionHelper
    {
        /// <summary>
        /// Pad naar de databasefile zoals vastgesteld in <see cref="DatabaseInitializer"/>
        /// </summary>
        private static readonly string DbPath = DatabaseInitializer.DatabaseFilePath;

        /// <summary>
        /// Maakt een nieuwe <see cref="SQLiteConnection"/> voor de databasefile,
        /// opent deze en geeft de geopende verbinding terug
        /// </summary>
        /// <returns>
        /// Een geopende <see cref="SQLiteConnection"/> die klaar is voor gebruik
        /// </returns>
        public static SQLiteConnection CreateOpen()
        {
            var connection = new SQLiteConnection($"Data Source={DbPath};");
            connection.Open();
            return connection;
        }
    }
}
