namespace Eindopdracht___Programmeren_in_C____LOI
{
    /// <summary>
    /// Handleiding van de applicatie. Legt uit wat de functies zijn en mogelijkheden
    /// </summary>
    public partial class ManualForm : Form
    {
        /// <summary>
        /// Initialiseert de UI
        /// </summary>
        public ManualForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
