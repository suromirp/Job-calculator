using Eindopdracht___Programmeren_in_C____LOI.Database;
using Eindopdracht___Programmeren_in_C____LOI.Models;
using Eindopdracht___Programmeren_in_C____LOI.Service;
using System.Text.RegularExpressions;

namespace Eindopdracht___Programmeren_in_C____LOI.UI
{
    /// <summary>
    /// Factory om alle benodigde compenenten en panels voor een persoon aan te maken
    /// </summary>
    public static class PersonPanelFactory
    {
        #region Public Panel Creators

        /// <summary>
        /// Bouwt een leeg <see cref="PersonPanel"/> en voegt het toe aan het ParentPanel
        /// </summary>
        /// <param name="parentPanel">Het <see cref="FlowLayoutPanel"/> waarin het <see cref="Panel"/> wordt geplaatst</param>
        /// <param name="panelProgress">Rapporteert de voortgang van de berekening per persoon (waarden tussen 0–100)</param>
        /// <param name="completionReporter">Geeft aan dat een berekening succesvol is afgerond (increment met 1 voor totale voortgang)</param>
        /// <returns>Het aangemaakte <see cref="Panel"/></returns>
        public static Panel CreateEmptyPanel(
           FlowLayoutPanel parentPanel,
           IProgress<int> panelProgress,
           IProgress<int> completionReporter)
           => PersonPanel.Build(null, parentPanel, panelProgress, completionReporter);

        /// <summary>
        /// Bouwt een <see cref="PersonPanel"/> voor de persoon en voegt het toe aan het ParentPanel
        /// </summary>
        /// <param name="person">De persoon die getoond moet worden</param>
        /// <param name="parentPanel">Het <see cref="FlowLayoutPanel"/> waarin het <see cref="Panel"/> wordt geplaatst</param>
        /// <param name="panelProgress">Rapporteert de voortgang van de berekening per persoon (0–100)</param>
        /// <param name="completionReporter">Geeft aan dat de berekening voltooid is (increment van 1)</param>
        /// <returns>Het aangemaakte <see cref="Panel"/></returns>
        public static Panel CreateFromData(
            PersonResult person,
            FlowLayoutPanel parentPanel,
            IProgress<int> panelProgress,
            IProgress<int> completionReporter)
            => PersonPanel.Build(person, parentPanel, panelProgress, completionReporter);

        #endregion

        #region Component Creatie

        /// <summary>
        /// Maakt en stelt alle UI componenten samen voor een PersonPanel, zonder deze al in de UI te plaatsen
        /// </summary>
        /// <returns>Een <see cref="PersonPanelComponents"/> met alle elementen klaar voor de layout</returns>
        public static PersonPanelComponents CreateComponents()
        {

            // Outer Panel
            var c = new PersonPanelComponents();

            c.MainPanel = new Panel
            {
                Width = 230,
                Height = 440,
                AutoScroll = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            #endregion

            #region Content Panel

            // Contentpanel
            c.ContentPanel = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Bottom,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                AutoScroll = false,
                Width = c.MainPanel.Width,
                Padding = new Padding(2),
                GrowStyle = TableLayoutPanelGrowStyle.AddRows
            };

            #endregion

            #region Input velden

            // Foutmelding bij ongeldige naam
            c.ErrorLabel = new Label
            {
                Text = "alleen letters, - en _ toegestaan",
                ForeColor = Color.Red,
                Font = new Font("Segoe UI", 7),
                Visible = false,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Bottom,
            };

            // Naam invoerveld
            c.NameTextBox = new TextBox
            {
                PlaceholderText = "Voer naam in",
                Dock = DockStyle.Bottom,
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(10)
            };
            c.NameTextBox.MaxLength = 15;

            // Keuzeveld voor opleiding
            c.EducationComboBox = new ComboBox
            {
                Dock = DockStyle.Bottom,
                DropDownStyle = ComboBoxStyle.DropDown,
                Margin = new Padding(10, 0, 10, 10),
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.ListItems
            };

            // Voeg placeholder toe
            const string PlaceholderText = "Kies of typ een opleiding";
            c.EducationComboBox.Items.Add(PlaceholderText);

            try
            {
                var Educations = EducationRepository.GetAllNames();
                c.EducationComboBox.Items.AddRange(Educations.ToArray());
            }
            catch (Exception ex)
            {
                Logger.Log("Fout bij laden van opleidingen: " + ex.Message, LogLevel.Error);
                MessageBox.Show(
                    "Er ging iets mis bij het ophalen van de opleidingen uit de database. Klik op Reset of start de applicatie opnieuw op",
                    "Databasefout",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            c.EducationComboBox.SelectedIndex = 0;

            #endregion

            #region UI Visuals (Avatar, Labels, Buttons)

            // Afbeelding (avatar)
            c.AvatarBox = new PictureBox
            {
                Height = 120,
                Dock = DockStyle.Bottom,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Margin = new Padding(10, 0, 10, 10)
            };

            // Timer om avatar pas te laden na korte pauze typen
            c.AvatarLoadTimer = new System.Windows.Forms.Timer
            {
                Interval = 400
            };

            // Berekenknop
            c.CalculateButton = new Button
            {
                Text = "Baan berekenen",
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 30,
                Margin = new Padding(10, 0, 10, 10),
                Enabled = false
            };

            // Voortgangsbalk
            c.ProgressBar = new ProgressBar
            {
                Dock = DockStyle.Bottom,
                Height = 20,
                Margin = new Padding(10, 0, 10, 10)
            };

            // Resultaat label
            c.ResultLabel = new Label
            {
                Text = "Baankans: -",
                Dock = DockStyle.Bottom,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(60, 120, 200),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 0, 10, 10)
            };

            // Hoogste baankans label
            c.HighestJobTextLabel = new Label
            {
                Text = "Hoogste baankans op:",
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(10, 0, 10, 0)
            };

            // Hoogste baankans resultaat
            c.HighestJobLabel = new Label
            {
                Text = "Baan: -",
                Dock = DockStyle.Bottom,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 160, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10, 0, 10, 10)
            };

            // Edit Button
            c.EditButton = new Button
            {
                Text = "✏️",
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Size = new Size(26, 26),
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.Gray,
                ForeColor = Color.Orange,
                Enabled = false,
                Visible = false,
                Margin = new Padding(0)
            };

            // Close Button
            c.CloseButton = new Button
            {
                Text = "X",
                Size = new Size(26, 26),
                Location = new Point(c.MainPanel.Width - 25, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                //Dock = DockStyle.Right,
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            c.MainPanel.Tag = c;

            return c;
        }

        #endregion

        #region Layout Opbouw

        /// <summary>
        /// Voegt alle UI componenten uit <paramref name="c"/> in de juiste volgorde toe aan het MainPanel
        /// </summary>
        /// <param name="c">Container met alle vooraf aangemaakte UI componenten voor een persoon (zoals Label, Button, en Panel)</param>
        public static void SetupLayout(PersonPanelComponents c)
        {
            // Content opbouwen
            c.ContentPanel.Controls.Add(c.ErrorLabel);
            c.ContentPanel.Controls.Add(c.NameTextBox);
            c.ContentPanel.Controls.Add(c.EducationComboBox);
            c.ContentPanel.Controls.Add(c.AvatarBox);
            c.ContentPanel.Controls.Add(c.ProgressBar);
            c.ContentPanel.Controls.Add(c.ResultLabel);
            c.ContentPanel.Controls.Add(c.HighestJobTextLabel);
            c.ContentPanel.Controls.Add(c.HighestJobLabel);
            c.ContentPanel.Controls.Add(c.CalculateButton);

            // Panel opbouwen
            c.MainPanel.Controls.Add(c.ContentPanel);
            c.MainPanel.Controls.Add(c.EditButton);
            c.MainPanel.Controls.Add(c.CloseButton);

            c.CloseButton.BringToFront();
            c.EditButton.BringToFront();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Koppelt alle eventhandlers aan de UI componenten in <paramref name="c"/>
        /// </summary>
        /// <param name="c">De verzameling UI elementen (<see cref="PersonPanelComponents"/>) waaraan de handlers worden gekoppeld</param>
        /// <param name="parentPanel">Het <see cref="FlowLayoutPanel"/> waarin de Panels worden geplaatst</param>
        /// <param name="panelProgress">Rapporteert de voortgang van de berekening per persoon (0–100)</param>
        /// <param name="completionReporter">Geeft aan dat de berekening voltooid is (increment van 1)</param>
        /// <exception cref="InvalidOperationException">
        /// Wordt gegooid als een vereiste component (zoals een knop of tekstvak) niet correct is geïnitialiseerd
        /// </exception>
        public static void AttachEvents(
            PersonPanelComponents c,
            FlowLayoutPanel parentPanel,
            IProgress<int> panelProgress,
            IProgress<int> completionReporter)
        {
            bool isUpdatingText = false;
            MainForm? GetMainForm() => c.MainPanel.FindForm() as MainForm;

            // Naamvalidatie + timer starten
            c.NameTextBox.TextChanged += (s, e) =>
            {
                if (isUpdatingText) return;

                int caret = c.NameTextBox.SelectionStart;
                string input = c.NameTextBox.Text;
                string filtered = Regex.Replace(input, @"[^a-zA-Z\s\-_]", "");

                if (filtered != input)
                {
                    c.ErrorLabel.Visible = true;
                    isUpdatingText = true;
                    c.NameTextBox.Text = filtered;
                    c.NameTextBox.SelectionStart = Math.Max(0, caret - 1);
                    isUpdatingText = false;
                    Logger.Log("Karakter(s) niet toegestaan, alleen letters en _ - toegestaan", LogLevel.Warning);
                    return;
                }

                c.ErrorLabel.Visible = false;
                c.CalculateButton.Enabled = !string.IsNullOrWhiteSpace(filtered);

                if (string.IsNullOrWhiteSpace(filtered))
                {
                    c.AvatarBox.Image = null;
                    return;
                }

                c.AvatarLoadTimer.Stop();
                c.AvatarLoadTimer.Start();
            };

            int defaultIndex = 0;

            c.EducationComboBox.Validating += (s, e) =>
            {
                if (s is ComboBox combo && combo.Items != null)
                {
                    if (combo.SelectedIndex < 0)
                    {
                        string typed = combo.Text ?? "";

                        var match = combo.Items
                            .Cast<string>()
                            .FirstOrDefault(item => item
                                .StartsWith(typed, StringComparison.CurrentCultureIgnoreCase));

                        if (match != null)
                        {
                            combo.SelectedItem = match;
                        }
                        else
                        {
                            combo.SelectedIndex = defaultIndex;
                        }
                    }
                }
            };

            // Avatar ophalen na pauze
            c.AvatarLoadTimer.Tick += async (s, e) =>
            {
                c.AvatarLoadTimer.Stop();

                string input = c.NameTextBox.Text;
                if (string.IsNullOrWhiteSpace(input))
                {
                    c.AvatarBox.Image = null;
                    return;
                }

                try
                {
                    var avatar = await PersonaPicture.LoadAvatarOrFallbackAsync(input);
                    c.AvatarBox.Image = avatar.Image;
                    c.AvatarBox.Tag = avatar.Url;
                }
                catch (OperationCanceledException)
                {
                    Logger.Log("Avatar laden geannuleerd", LogLevel.Warning);
                }
            };

            // Calculate Button logic
            c.CalculateButton.Click += async (s, ev) =>
            {
                // Als panel nog in bewerkmodus staat, beëindig het
                if (c.IsEditing)
                {
                    c.IsEditing = false;

                    c.NameTextBox.ReadOnly = true;
                    c.NameTextBox.Enabled = false;
                    c.EducationComboBox.Enabled = false;

                    c.MainPanel.BackColor = Color.White;
                    c.MainPanel.BorderStyle = BorderStyle.FixedSingle;
                }

                string name = c.NameTextBox.Text.Trim();
                string selectedEducation = c.EducationComboBox.Text.Trim();

                bool wasDoneBefore = c.ProgressBar.Value == c.ProgressBar.Maximum;
                if (wasDoneBefore)
                {
                    var form = GetMainForm();
                    form?.DecrementCompletedPerson();
                }

                c.CalculateButton.Text = "Berekenen...";

                panelProgress.Report(0);

                const string PlaceholderText = "Kies of typ een opleiding";
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(selectedEducation) || selectedEducation == PlaceholderText)
                {
                    string msg = $"Kies een geldige selectie voor {name}";
                    Logger.Log(msg, LogLevel.Error);
                    MessageBox.Show(msg, "Ongeldige invoer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                c.NameTextBox.ReadOnly = true;
                c.EducationComboBox.Enabled = false;
                c.CalculateButton.Enabled = false;

                int EducationId = EducationRepository.GetOrInsert(selectedEducation);
                int? personId = (c.MainPanel.Tag as PanelTag)?.PersonId;

                c.CalculationTokenSource = new CancellationTokenSource();
                CancellationToken token = c.CalculationTokenSource.Token;

                try
                {
                    c.CalculationTokenSource?.Cancel();
                    c.CalculationTokenSource?.Dispose();
                    c.CalculationTokenSource = new CancellationTokenSource();

                    c.IsCalculating = true;

                    var result = await ChanceCalculator.CalculateChanceAsync(
                        name,
                        panelProgress,
                        completionReporter,
                        c.CalculationTokenSource.Token);

                    if (string.IsNullOrWhiteSpace(result.Job))
                    {
                        throw new InvalidOperationException("Geen geldige job ontvangen uit berekening.");
                    }

                    int jobId = JobRepository.GetJobIdByName(result.Job);

                    int percentage = (int)(result.Chance * 100);
                    c.ResultLabel.Text = $"Baankans: {percentage}%";
                    c.HighestJobLabel.Text = result.Job;
                    panelProgress.Report(100);

                    string avatarUrl =
                        c.AvatarBox.Tag as string
                        ?? c.AvatarBox.ImageLocation
                        ?? "";

                    if (personId.HasValue)
                    {
                        PersonRepository.SaveById(
                            id: personId.Value,
                            name: name,
                            EducationId: EducationId,
                            jobName: result.Job,
                            chance: result.Chance,
                            imageUrl: avatarUrl
                        );
                    }
                    else
                    {
                        int newId = PersonRepository.AddAndReturnId(
                            name,
                            EducationId,
                            imageUrl: avatarUrl
                            );

                        if (newId <= 0)
                            throw new InvalidOperationException("Ongeldig ID gegenereerd.");

                        PersonRepository.SaveById(
                            id: newId,
                            name: name,
                            EducationId: EducationId,
                            jobName: result.Job,
                            chance: result.Chance,
                            imageUrl: avatarUrl
                        );

                        c.MainPanel.Tag = new PanelTag(c, newId);
                    }

                    c.EditButton.Enabled = true;
                    c.EditButton.Visible = true;

                    Logger.Log($"{name} opgeslagen met {percentage}% kans op {result.Job}", LogLevel.Info);
                }
                catch (Exception ex)
                {
                    Logger.Log("Fout bij berekenen/opslaan: " + ex.Message, LogLevel.Error);

                    if (!c.NameTextBox.IsDisposed) c.NameTextBox.ReadOnly = false;
                    if (!c.EducationComboBox.IsDisposed) c.EducationComboBox.Enabled = true;
                    if (!c.CalculateButton.IsDisposed)
                    {
                        c.CalculateButton.Enabled = true;
                        c.CalculateButton.Text = "Baan berekenen";
                    }
                }
                finally
                {
                    if (!c.EditButton.IsDisposed)
                    {
                        c.EditButton.Enabled = true;
                        c.EditButton.Visible = true;
                    }

                    c.CalculateButton.Text = "✔ Berekend";

                    c.IsEditing = false;
                    c.IsCalculating = false;

                    // Onthoudt de laatst berekende opleiding
                    c.LastCalculatedEducation = selectedEducation;

                    c.MainPanel.BackColor = Color.White;
                    c.MainPanel.BorderStyle = BorderStyle.FixedSingle;
                }
            };

            c.EditButton.Click += (s, e) =>
            {
                if (c.IsCalculating)
                {
                    MessageBox.Show("Je kunt niet bewerken terwijl de berekening nog bezig is.", "Bewerken niet toegestaan", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information
                        );
                    return;
                }

                if (!c.IsEditing)
                {
                    c.MainPanel.BackColor = Color.LightGoldenrodYellow;
                    c.MainPanel.BorderStyle = BorderStyle.Fixed3D;

                    c.NameTextBox.ReadOnly = false;
                    c.NameTextBox.Enabled = true;
                    c.EducationComboBox.Enabled = true;
                    c.CalculateButton.Enabled = true;
                    c.CalculateButton.Text = "Baan berekenen";

                    c.IsEditing = true;

                    Logger.Log($"Bewerken geactiveerd voor {c.NameTextBox.Text}", LogLevel.Info);
                }

                else
                {
                    string selectedEducation = c.EducationComboBox.Text.Trim();

                    if (c.IsEditing && selectedEducation != c.LastCalculatedEducation)
                    {
                        MessageBox.Show(
                            "De opleiding is aangepast. Klik opnieuw op 'Baan berekenen' om de berekening opnieuw uit te voeren.",
                            "Wijziging gedetecteerd",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        return;
                    }

                    c.CalculateButton.Text = "✔ Berekend";

                    c.MainPanel.BackColor = Color.White;
                    c.MainPanel.BorderStyle = BorderStyle.FixedSingle;

                    c.NameTextBox.ReadOnly = true;
                    c.NameTextBox.Enabled = false;
                    c.EducationComboBox.Enabled = false;
                    c.CalculateButton.Enabled = false;
                    c.EditButton.Enabled = true;
                    c.EditButton.Visible = true;

                    c.IsEditing = false;

                    Logger.Log($"Bewerken gestopt voor {c.NameTextBox.Text}", LogLevel.Info);
                }
            };

            c.CloseButton.Click += (s, e) =>
            {
                string name = c.NameTextBox.Text;

                var result = MessageBox.Show(
                    $"Weet je zeker dat je {name} wilt verwijderen?",
                    "Bevestiging",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    if (c.CalculationTokenSource is not null)
                    {
                        try
                        {
                            c.CalculationTokenSource.Cancel();
                        }
                        catch { /* negeren als het al gecancelled is */ }

                        c.CalculationTokenSource.Dispose();
                        c.CalculationTokenSource = null;
                    }

                    if (c.MainPanel.Tag is PanelTag tag && tag.PersonId.HasValue && PersonRepository.ExistsById(tag.PersonId.Value))
                    {
                        PersonRepository.DeleteById(tag.PersonId.Value);
                        Logger.Log($"Persoon {name} verwijderd uit database", LogLevel.Warning);
                    }

                    var form = GetMainForm();
                    form?.RemovePersonFromProgress(c.Iscompleted);

                    parentPanel.Controls.Remove(c.MainPanel);
                    c.MainPanel.Dispose();
                }
            };
        }

        #endregion

        #region Data Populatie

        /// <summary>
        /// Vult de UI componenten in <paramref name="c"/> met de gegeven <paramref name="person"/> data
        /// </summary>
        /// <param name="c">
        /// De <see cref="PersonPanelComponents"/> met alle UI componenten die moeten worden gevuld
        /// </param>
        /// <param name="person">
        /// De <see cref="PersonResult"/> met de data (naam, opleiding, baan, etc) om in te vullen
        /// </param>
        public static void PopulateWithPersonData(PersonPanelComponents c, PersonResult person)
        {
            c.NameTextBox.Text = person.Name;

            if (person.Education is null)
            {
                Logger.Log("Education is null voor persoon: " + person.Name, LogLevel.Warning);
            }
            c.LastCalculatedEducation = person.Education ?? "";

            c.EducationComboBox.Text = person.Education;
            c.AvatarBox.ImageLocation = person.ImageUrl;
            c.AvatarBox.Tag = person.ImageUrl;

            int percentage = (int)(person.Chance * 100);
            c.ResultLabel.Text = $"Baankans: {percentage}%";
            c.HighestJobLabel.Text = person.Job;
            c.ProgressBar.Value = 100;

            c.NameTextBox.ReadOnly = true;
            c.EducationComboBox.Enabled = false;
            c.CalculateButton.Enabled = false;
            c.EditButton.Enabled = true;
            c.EditButton.Visible = true;

            c.MainPanel.Tag = new PanelTag(c, person.Id);

            c.CalculateButton.Text = "✔ Berekend";
        }

        #endregion
    }
}
