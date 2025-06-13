namespace Eindopdracht___Programmeren_in_C____LOI.Service
{

    #region Loglevel Enum

    /// <summary>
    /// Geeft het niveau van een logbericht aan
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Informatieve berichten zonder waarschuwing of fouten
        /// </summary>
        Info,

        /// <summary>
        /// Waarschuwingsberichten die op mogelijke problemen wijzen
        /// </summary>
        Warning,

        /// <summary>
        /// Foutberichten bij uitzonderingen of kritieke fouten
        /// </summary>
        Error
    }

    #endregion

    #region Logger Class

    /// <summary>
    /// Logger die berichten doorstuurt via het <see cref="OnLog"/> event
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Wordt aangeroepen wanneer er een nieuwe logbericht is
        /// </summary>
        public static event Action<string, LogLevel>? OnLog;

        /// <summary>
        /// Logt een bericht met het opgegeven niveau door <see cref="OnLog"/> event aan te roepen
        /// </summary>
        /// <param name="message">De te loggen tekst</param>
        /// <param name="level">Het niveau waaronder het bericht gelogd moet worden. Standaard <see cref="LogLevel.Info"/></param>
        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            OnLog?.Invoke(message, level);
        }
    }

    #endregion
}
