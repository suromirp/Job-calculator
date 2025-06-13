namespace Eindopdracht___Programmeren_in_C____LOI.Models
{
    /// <summary>
    /// Resultaat van het ophalen van een avatar afbeelding,
    /// </summary>
    public class AvatarResult
    {
        /// <summary>
        /// De geladen <see cref="Image"/> voor de avatar
        /// </summary>
        public Image Image { get; set; } = null!;

        /// <summary>
        /// De URL voor de avatar API
        /// </summary>
        public string Url { get; set; } = null!;
    }
}
