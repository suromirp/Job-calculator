using Eindopdracht___Programmeren_in_C____LOI.Models;

namespace Eindopdracht___Programmeren_in_C____LOI.Database
{
    /// <summary>
    /// Repository voor CRUD-operaties op de <c>Persons</c>-tabel.
    /// </summary>
    public static class PersonRepository
    {

        #region Ophalen

        /// <summary>
        /// Haalt alle personen op, met bijbehorende opleiding en baan
        /// </summary>
        /// <returns>
        /// Een lijst van <see cref="PersonResult"/> met alle records uit de database</returns>
        public static List<PersonResult> GetAll()
        {
            var persons = new List<PersonResult>();
            using var connection = DatabaseConnectionHelper.CreateOpen();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
               SELECT p.Id, p.Name, p.EducationId, e.Name AS EducationName, 
                      j.Name AS JobName, p.Chance, p.ImageUrl, p.IsCalculated
               FROM Persons p
               LEFT JOIN Education e ON p.EducationId = e.Id
               LEFT JOIN Jobs j ON p.JobId = j.Id
           ";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                persons.Add(new PersonResult
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"]?.ToString() ?? string.Empty,
                    Education = reader["EducationName"]?.ToString() ?? string.Empty,
                    Job = reader["JobName"]?.ToString() ?? string.Empty,
                    Chance = reader["Chance"] != DBNull.Value
                                ? Convert.ToDouble(reader["Chance"])
                                : 0,
                    ImageUrl = reader["ImageUrl"]?.ToString() ?? string.Empty,
                    IsCalculated = reader["IsCalculated"] != DBNull.Value
                                && Convert.ToBoolean(reader["IsCalculated"])
                });
            }

            return persons;
        }

        #endregion

        #region Toevoegen

        /// <summary>
        /// Voegt een nieuw persoon toe en retourneert het nieuwe gegenereerde ID
        /// </summary>
        /// <param name="name">De naam van de persoon</param>
        /// <param name="EducationId">Het ID van de opleiding</param>
        /// <param name="imageUrl">URL naar de afbeelding</param>
        /// <returns>Het database ID van de nieuwe aangemaakte persoon</returns>
        public static int AddAndReturnId(string name, int EducationId, string imageUrl)
        {
            using var connection = DatabaseConnectionHelper.CreateOpen();
            using var cmd = connection.CreateCommand();

            cmd.CommandText =
                @"
                INSERT INTO Persons 
                    (Name, EducationId, JobId, Chance, ImageUrl, IsCalculated)
                VALUES 
                    (@name, @EducationId, NULL, NULL, @imageUrl, 0);
                SELECT 
                    last_insert_rowid();
                ";

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@EducationId", EducationId);
            cmd.Parameters.AddWithValue("@imageUrl", imageUrl);

            var result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        #endregion

        #region Bijwerken

        /// <summary>
        /// Slaat bestaande gegevens van een nieuw persoon op
        /// </summary>
        /// <param name="id">Het ID van de persoon</param>
        /// <param name="name">De naam van de persoon</param>
        /// <param name="EducationId">Het ID van de opleiding</param>
        /// <param name="jobName">De naam van de baan om het ID op te halen</param>
        /// <param name="chance">De berekende kans</param>
        /// <param name="imageUrl">URL naar de afbeelding</param>
        /// <exception cref="InvalidOperationException">
        /// Als <paramref name="jobName"/> niet bestaat in de Jobs-tabel.
        /// </exception>
        public static void SaveById(int id, string name, int EducationId, string jobName, double chance, string imageUrl)
        {
            using var connection = DatabaseConnectionHelper.CreateOpen();
            using var cmd = connection.CreateCommand();

            // Bepaal JobId via de repository
            int jobId = JobRepository.GetJobIdByName(jobName);

            cmd.CommandText = @"
                UPDATE Persons
                    SET Name = @name,
                        EducationId = @EducationId,
                        JobId = @jobId,
                        Chance = @chance,
                        ImageUrl = @imageUrl,
                        IsCalculated = 1
                WHERE Id = @id;
                ";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@EducationId", EducationId);
            cmd.Parameters.AddWithValue("@jobId", jobId);
            cmd.Parameters.AddWithValue("@chance", chance);
            cmd.Parameters.AddWithValue("@imageUrl", imageUrl);

            cmd.ExecuteNonQuery();
        }

        #endregion

        #region Verwijderen

        /// <summary>
        /// Verwijdert alle personen uit de database
        /// </summary>
        public static void DeleteAll()
        {
            using var connection = DatabaseConnectionHelper.CreateOpen();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Persons";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Verwijdert een specifiek persoon op basis van ID
        /// </summary>
        /// <param name="id">Het ID van het te verwijderen persoon</param>
        public static void DeleteById(int id)
        {
            using var connection = DatabaseConnectionHelper.CreateOpen();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Persons WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        #endregion

        #region Controle

        /// <summary>
        /// Doet een check of een persoon met het gegeven ID al bestaat
        /// </summary>
        /// <param name="id">Het ID om te controleren</param>
        /// <returns>
        /// <c>true</c> als er minstens één record met dit ID is gevonden, anders <c>false</c>
        /// </returns>
        public static bool ExistsById(int id)
        {
            using var connection = DatabaseConnectionHelper.CreateOpen();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM Persons WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        #endregion
    }
}
