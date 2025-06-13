namespace Eindopdracht___Programmeren_in_C____LOI.Models
{
    /// <summary>
    /// Draagt de gegevens van een persoon over tussen de database en de UI
    /// </summary>
    public class PersonResult
    {
        /// <summary>
        /// Het unieke Id van de persoon in de database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// De naam van de persoon
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// De naam van de opleiding van de persoon
        /// </summary>
        public string? Education { get; set; }

        /// <summary>
        /// De naam van de baan van de persoon
        /// </summary>
        public string? Job { get; set; }

        /// <summary>
        /// De berekende kans (tussen 0.0 en 1.0) voor een baan
        /// </summary>
        public double Chance { get; set; }

        /// <summary>
        /// De URL naar de avatar afbeelding van de persoon
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Geeft aan of de kans voor deze persoon al berekend en opgeslagen is
        /// </summary>
        public bool IsCalculated { get; set; }
    }
}
