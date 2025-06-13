using Eindopdracht___Programmeren_in_C____LOI.Service;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Eindopdracht___Programmeren_in_C____LOI.Models
{

    /// <summary>
    /// Biedt functionaliteit om een avatar URL te genereren en de afbeelding te laden, met embedded fallback
    /// </summary>
    public static class PersonaPicture
    {

        #region Velden & Configuratie

        private static readonly string[] Styles =
        {
            "avataaars",
            "adventurer",
            "personas",
            "big-smile",
            "big-ears",
            "open-peeps"
        };

        private static readonly Random rnd = new Random();

        #endregion

        #region URL Generatie

        /// <summary>
        /// Genereert een URL voor een avatar bij Dicebear, gebaseerd op de naam als seed
        /// </summary>
        /// <param name="name">
        /// De naam die gebruikt wordt als seed voor de avatar, bij leeg of whitespace wordt "default" gebruikt
        /// </param>
        /// <returns>
        /// Een volledige URL naar een PNG avatar met achtergrond en kleur</returns>
        public static string GenerateAvatarUrl(string name)
        {
            string seed = string.IsNullOrWhiteSpace(name) ? "default" : name.Trim();

            byte[] hashBytes;
            using (var sha = SHA256.Create())
            {
                hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(seed));
            }

            int styleIndex = hashBytes[0] % Styles.Length;
            string styleName = Styles[styleIndex];

            string hexColor =
                $"{hashBytes[1]:X2}{hashBytes[2]:X2}{hashBytes[3]:X2}";

            string safeSeed = Convert.ToBase64String(Encoding.UTF8.GetBytes(seed))
                                  .Replace("=", "")
                                  .Replace("/", "")
                                  .Replace("+", "");

            return $"https://api.dicebear.com/7.x/{styleName}/png?seed={safeSeed}&backgroundColor={hexColor}";
        }

        #endregion

        #region Avatar Laden

        /// <summary>
        /// Laadt asynchroon de avatar afbeelding van de gegenereerde URL, of gebruik een fallback afbeelding als het netwerk faalt
        /// </summary>
        /// <param name="name">
        /// De naam die gebruikt wordt om de avatar URL te genereren
        /// </param>
        /// <returns>
        /// Een <see cref="AvatarResult"/> met de geladen <see cref="Image"/> en de URL (of lege string als fallback)
        /// </returns>
        public static async Task<AvatarResult> LoadAvatarOrFallbackAsync(string name)
        {
            try
            {
                var url = GenerateAvatarUrl(name);
                using var httpClient = new HttpClient { Timeout = TimeSpan.FromMilliseconds(2000) };
                using var stream = await httpClient.GetStreamAsync(url);
                Logger.Log($"Avatar geladen van {url}", LogLevel.Info);

                return new AvatarResult
                {
                    Image = Image.FromStream(stream),
                    Url = url
                };
            }
            catch (Exception ex)
            {
                Logger.Log($"Avatar ophalen mislukt ({ex.Message}), gebruikt fallback", LogLevel.Warning);

                return new AvatarResult
                {
                    Image = LoadFallbackImageOrEmpty(),
                    Url = string.Empty
                };
            }
        }

        #endregion

        #region Fallback Load

        /// <summary>
        /// Laadt een willekeurige fallback afbeelding of een lege <see cref="Bitmap"/> als er geen resources gevonden worden
        /// </summary>
        /// <returns>
        /// De <see cref="Image"/> van een embedded PNG of een lege bitmap
        /// </returns>
        private static Image LoadFallbackImageOrEmpty()
        {
            const int fallbackWidth = 250;
            const int fallbackHeight = 120;

            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceNames = assembly.GetManifestResourceNames()
                                           .Where(n => n.Contains("Assets.Fallback") && n.EndsWith(".png"))
                                           .ToArray();

                if (resourceNames.Length == 0)
                {
                    Logger.Log("Geen fallback-afbeeldingen gevonden in embedded resources.", LogLevel.Error);
                    return new Bitmap(fallbackWidth, fallbackHeight);
                }

                string choice = resourceNames[rnd.Next(resourceNames.Length)];
                using var stream = assembly.GetManifestResourceStream(choice)
                                ?? throw new FileNotFoundException($"Resource '{choice}' niet gevonden.");

                return Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                Logger.Log($"Fallback laden mislukt ({ex.Message})", LogLevel.Error);
                return new Bitmap(fallbackWidth, fallbackHeight);
            }
        }

        #endregion
    }
}