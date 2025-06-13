namespace Eindopdracht___Programmeren_in_C____LOI
{
    partial class ManualForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualForm));
            mainLayoutPanel = new TableLayoutPanel();
            navigationPanel = new FlowLayoutPanel();
            backButton = new Button();
            tabLog = new TabPage();
            labelLogTitle = new Label();
            logLayoutPanel = new TableLayoutPanel();
            labelLogContent = new Label();
            tabCalculateJob = new TabPage();
            labelCalculateJobTitle = new Label();
            calculateJobLayoutPanel = new TableLayoutPanel();
            labelCalculateJobContent = new Label();
            tabEditPerson = new TabPage();
            labelEditPersonTitle = new Label();
            labelEditPersonContent = new Label();
            tabChooseStudy = new TabPage();
            labelChooseStudyTitle = new Label();
            chooseStudyLayoutPanel = new TableLayoutPanel();
            labelChooseStudyContent = new Label();
            tabAddPerson = new TabPage();
            labelAddPersonTitle = new Label();
            addPersonLayoutPanel = new TableLayoutPanel();
            labelAddPersonContent = new Label();
            tabIntro = new TabPage();
            labelIntroTitle = new Label();
            introLayoutPanel = new TableLayoutPanel();
            labelIntroContent = new Label();
            manualTabControl = new TabControl();
            tabManage = new TabPage();
            labelManageTitle = new Label();
            manageLayoutPanel = new TableLayoutPanel();
            labelManageContent = new Label();
            tabTotalProgress = new TabPage();
            totalProgressLayoutPanel = new TableLayoutPanel();
            labelTotalProgressContent = new Label();
            labelTotalProgressTitle = new Label();
            mainLayoutPanel.SuspendLayout();
            navigationPanel.SuspendLayout();
            tabLog.SuspendLayout();
            logLayoutPanel.SuspendLayout();
            tabCalculateJob.SuspendLayout();
            calculateJobLayoutPanel.SuspendLayout();
            tabEditPerson.SuspendLayout();
            tabChooseStudy.SuspendLayout();
            chooseStudyLayoutPanel.SuspendLayout();
            tabAddPerson.SuspendLayout();
            addPersonLayoutPanel.SuspendLayout();
            tabIntro.SuspendLayout();
            introLayoutPanel.SuspendLayout();
            manualTabControl.SuspendLayout();
            tabManage.SuspendLayout();
            manageLayoutPanel.SuspendLayout();
            tabTotalProgress.SuspendLayout();
            totalProgressLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            mainLayoutPanel.ColumnCount = 1;
            mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayoutPanel.Controls.Add(manualTabControl, 0, 0);
            mainLayoutPanel.Controls.Add(navigationPanel, 0, 1);
            mainLayoutPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.Location = new Point(0, 0);
            mainLayoutPanel.Name = "mainLayoutPanel";
            mainLayoutPanel.RowCount = 2;
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayoutPanel.Size = new Size(984, 711);
            mainLayoutPanel.TabIndex = 0;
            // 
            // navigationPanel
            // 
            navigationPanel.Controls.Add(backButton);
            navigationPanel.Dock = DockStyle.Fill;
            navigationPanel.FlowDirection = FlowDirection.RightToLeft;
            navigationPanel.Location = new Point(3, 654);
            navigationPanel.Name = "navigationPanel";
            navigationPanel.Size = new Size(978, 54);
            navigationPanel.TabIndex = 1;
            // 
            // backButton
            // 
            backButton.AutoSize = true;
            backButton.Location = new Point(789, 3);
            backButton.Name = "backButton";
            backButton.Size = new Size(186, 41);
            backButton.TabIndex = 0;
            backButton.Text = "Terug naar de applicatie";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += BackButton_Click;
            // 
            // tabLog
            // 
            tabLog.Controls.Add(logLayoutPanel);
            tabLog.Controls.Add(labelLogTitle);
            tabLog.Location = new Point(4, 29);
            tabLog.Name = "tabLog";
            tabLog.Size = new Size(970, 612);
            tabLog.TabIndex = 4;
            tabLog.Text = "Logvenster";
            tabLog.UseVisualStyleBackColor = true;
            // 
            // labelLogTitle
            // 
            labelLogTitle.Dock = DockStyle.Top;
            labelLogTitle.Font = new Font("Cambria", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogTitle.Location = new Point(0, 0);
            labelLogTitle.Name = "labelLogTitle";
            labelLogTitle.Padding = new Padding(0, 20, 0, 0);
            labelLogTitle.Size = new Size(970, 76);
            labelLogTitle.TabIndex = 1;
            labelLogTitle.Text = "Logvenster";
            labelLogTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // logLayoutPanel
            // 
            logLayoutPanel.ColumnCount = 1;
            logLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            logLayoutPanel.Controls.Add(labelLogContent, 0, 0);
            logLayoutPanel.Dock = DockStyle.Fill;
            logLayoutPanel.Location = new Point(0, 76);
            logLayoutPanel.Margin = new Padding(3, 10, 3, 3);
            logLayoutPanel.Name = "logLayoutPanel";
            logLayoutPanel.Padding = new Padding(0, 10, 0, 0);
            logLayoutPanel.RowCount = 1;
            logLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            logLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            logLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            logLayoutPanel.Size = new Size(970, 536);
            logLayoutPanel.TabIndex = 3;
            // 
            // labelLogContent
            // 
            labelLogContent.AutoSize = true;
            labelLogContent.Dock = DockStyle.Fill;
            labelLogContent.Font = new Font("Segoe UI", 12F);
            labelLogContent.ImageAlign = ContentAlignment.TopCenter;
            labelLogContent.Location = new Point(3, 10);
            labelLogContent.Name = "labelLogContent";
            labelLogContent.Padding = new Padding(0, 20, 0, 0);
            labelLogContent.Size = new Size(964, 526);
            labelLogContent.TabIndex = 0;
            labelLogContent.Text = resources.GetString("labelLogContent.Text");
            labelLogContent.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabCalculateJob
            // 
            tabCalculateJob.Controls.Add(calculateJobLayoutPanel);
            tabCalculateJob.Controls.Add(labelCalculateJobTitle);
            tabCalculateJob.Location = new Point(4, 29);
            tabCalculateJob.Name = "tabCalculateJob";
            tabCalculateJob.Size = new Size(970, 612);
            tabCalculateJob.TabIndex = 3;
            tabCalculateJob.Text = "Baan berekenen";
            tabCalculateJob.UseVisualStyleBackColor = true;
            // 
            // labelCalculateJobTitle
            // 
            labelCalculateJobTitle.Dock = DockStyle.Top;
            labelCalculateJobTitle.Font = new Font("Cambria", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCalculateJobTitle.Location = new Point(0, 0);
            labelCalculateJobTitle.Name = "labelCalculateJobTitle";
            labelCalculateJobTitle.Padding = new Padding(0, 20, 0, 0);
            labelCalculateJobTitle.Size = new Size(970, 76);
            labelCalculateJobTitle.TabIndex = 1;
            labelCalculateJobTitle.Text = "Baan berekenen";
            labelCalculateJobTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // calculateJobLayoutPanel
            // 
            calculateJobLayoutPanel.ColumnCount = 1;
            calculateJobLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            calculateJobLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            calculateJobLayoutPanel.Controls.Add(labelCalculateJobContent, 0, 0);
            calculateJobLayoutPanel.Dock = DockStyle.Fill;
            calculateJobLayoutPanel.Location = new Point(0, 76);
            calculateJobLayoutPanel.Margin = new Padding(3, 10, 3, 3);
            calculateJobLayoutPanel.Name = "calculateJobLayoutPanel";
            calculateJobLayoutPanel.Padding = new Padding(0, 10, 0, 0);
            calculateJobLayoutPanel.RowCount = 1;
            calculateJobLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            calculateJobLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            calculateJobLayoutPanel.Size = new Size(970, 536);
            calculateJobLayoutPanel.TabIndex = 4;
            // 
            // labelCalculateJobContent
            // 
            labelCalculateJobContent.AutoSize = true;
            labelCalculateJobContent.Dock = DockStyle.Fill;
            labelCalculateJobContent.Font = new Font("Segoe UI", 12F);
            labelCalculateJobContent.Location = new Point(3, 10);
            labelCalculateJobContent.Name = "labelCalculateJobContent";
            labelCalculateJobContent.Padding = new Padding(0, 20, 0, 0);
            labelCalculateJobContent.Size = new Size(964, 526);
            labelCalculateJobContent.TabIndex = 2;
            labelCalculateJobContent.Text = resources.GetString("labelCalculateJobContent.Text");
            labelCalculateJobContent.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabEditPerson
            // 
            tabEditPerson.Controls.Add(labelEditPersonContent);
            tabEditPerson.Controls.Add(labelEditPersonTitle);
            tabEditPerson.Location = new Point(4, 29);
            tabEditPerson.Name = "tabEditPerson";
            tabEditPerson.Padding = new Padding(3);
            tabEditPerson.Size = new Size(970, 612);
            tabEditPerson.TabIndex = 5;
            tabEditPerson.Text = "Persoon bewerken";
            tabEditPerson.UseVisualStyleBackColor = true;
            // 
            // labelEditPersonTitle
            // 
            labelEditPersonTitle.Font = new Font("Cambria", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEditPersonTitle.Location = new Point(3, 3);
            labelEditPersonTitle.Name = "labelEditPersonTitle";
            labelEditPersonTitle.Padding = new Padding(0, 20, 0, 0);
            labelEditPersonTitle.Size = new Size(964, 76);
            labelEditPersonTitle.TabIndex = 3;
            labelEditPersonTitle.Text = "Persoon bewerken";
            labelEditPersonTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelEditPersonContent
            // 
            labelEditPersonContent.Font = new Font("Segoe UI", 12F);
            labelEditPersonContent.Location = new Point(3, 79);
            labelEditPersonContent.Name = "labelEditPersonContent";
            labelEditPersonContent.Padding = new Padding(0, 20, 0, 0);
            labelEditPersonContent.Size = new Size(964, 530);
            labelEditPersonContent.TabIndex = 2;
            labelEditPersonContent.Text = resources.GetString("labelEditPersonContent.Text");
            labelEditPersonContent.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabChooseStudy
            // 
            tabChooseStudy.Controls.Add(chooseStudyLayoutPanel);
            tabChooseStudy.Controls.Add(labelChooseStudyTitle);
            tabChooseStudy.Location = new Point(4, 29);
            tabChooseStudy.Name = "tabChooseStudy";
            tabChooseStudy.Size = new Size(970, 612);
            tabChooseStudy.TabIndex = 2;
            tabChooseStudy.Text = "Opleiding kiezen";
            tabChooseStudy.UseVisualStyleBackColor = true;
            // 
            // labelChooseStudyTitle
            // 
            labelChooseStudyTitle.Dock = DockStyle.Top;
            labelChooseStudyTitle.Font = new Font("Cambria", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelChooseStudyTitle.Location = new Point(0, 0);
            labelChooseStudyTitle.Name = "labelChooseStudyTitle";
            labelChooseStudyTitle.Padding = new Padding(0, 20, 0, 0);
            labelChooseStudyTitle.Size = new Size(970, 76);
            labelChooseStudyTitle.TabIndex = 1;
            labelChooseStudyTitle.Text = "Opleiding kiezen";
            labelChooseStudyTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // chooseStudyLayoutPanel
            // 
            chooseStudyLayoutPanel.ColumnCount = 1;
            chooseStudyLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            chooseStudyLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            chooseStudyLayoutPanel.Controls.Add(labelChooseStudyContent, 0, 0);
            chooseStudyLayoutPanel.Dock = DockStyle.Fill;
            chooseStudyLayoutPanel.Location = new Point(0, 76);
            chooseStudyLayoutPanel.Margin = new Padding(3, 10, 3, 3);
            chooseStudyLayoutPanel.Name = "chooseStudyLayoutPanel";
            chooseStudyLayoutPanel.Padding = new Padding(0, 10, 0, 0);
            chooseStudyLayoutPanel.RowCount = 1;
            chooseStudyLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            chooseStudyLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            chooseStudyLayoutPanel.Size = new Size(970, 536);
            chooseStudyLayoutPanel.TabIndex = 4;
            // 
            // labelChooseStudyContent
            // 
            labelChooseStudyContent.AutoSize = true;
            labelChooseStudyContent.Dock = DockStyle.Fill;
            labelChooseStudyContent.Font = new Font("Segoe UI", 12F);
            labelChooseStudyContent.Location = new Point(3, 10);
            labelChooseStudyContent.Name = "labelChooseStudyContent";
            labelChooseStudyContent.Padding = new Padding(0, 20, 0, 0);
            labelChooseStudyContent.Size = new Size(964, 526);
            labelChooseStudyContent.TabIndex = 1;
            labelChooseStudyContent.Text = resources.GetString("labelChooseStudyContent.Text");
            labelChooseStudyContent.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabAddPerson
            // 
            tabAddPerson.Controls.Add(addPersonLayoutPanel);
            tabAddPerson.Controls.Add(labelAddPersonTitle);
            tabAddPerson.Location = new Point(4, 29);
            tabAddPerson.Name = "tabAddPerson";
            tabAddPerson.Padding = new Padding(3);
            tabAddPerson.Size = new Size(970, 612);
            tabAddPerson.TabIndex = 1;
            tabAddPerson.Text = "Personen toevoegen";
            tabAddPerson.UseVisualStyleBackColor = true;
            // 
            // labelAddPersonTitle
            // 
            labelAddPersonTitle.Dock = DockStyle.Top;
            labelAddPersonTitle.Font = new Font("Cambria", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAddPersonTitle.Location = new Point(3, 3);
            labelAddPersonTitle.Name = "labelAddPersonTitle";
            labelAddPersonTitle.Padding = new Padding(0, 20, 0, 0);
            labelAddPersonTitle.Size = new Size(964, 76);
            labelAddPersonTitle.TabIndex = 1;
            labelAddPersonTitle.Text = "Personen toevoegen";
            labelAddPersonTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // addPersonLayoutPanel
            // 
            addPersonLayoutPanel.ColumnCount = 1;
            addPersonLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            addPersonLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            addPersonLayoutPanel.Controls.Add(labelAddPersonContent, 0, 0);
            addPersonLayoutPanel.Dock = DockStyle.Fill;
            addPersonLayoutPanel.Location = new Point(3, 79);
            addPersonLayoutPanel.Margin = new Padding(3, 10, 3, 3);
            addPersonLayoutPanel.Name = "addPersonLayoutPanel";
            addPersonLayoutPanel.Padding = new Padding(0, 10, 0, 0);
            addPersonLayoutPanel.RowCount = 1;
            addPersonLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            addPersonLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            addPersonLayoutPanel.Size = new Size(964, 530);
            addPersonLayoutPanel.TabIndex = 4;
            // 
            // labelAddPersonContent
            // 
            labelAddPersonContent.AutoSize = true;
            labelAddPersonContent.Dock = DockStyle.Fill;
            labelAddPersonContent.Font = new Font("Segoe UI", 12F);
            labelAddPersonContent.Location = new Point(3, 10);
            labelAddPersonContent.Name = "labelAddPersonContent";
            labelAddPersonContent.Padding = new Padding(0, 20, 0, 0);
            labelAddPersonContent.Size = new Size(958, 520);
            labelAddPersonContent.TabIndex = 0;
            labelAddPersonContent.Text = resources.GetString("labelAddPersonContent.Text");
            labelAddPersonContent.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabIntro
            // 
            tabIntro.Controls.Add(introLayoutPanel);
            tabIntro.Controls.Add(labelIntroTitle);
            tabIntro.Location = new Point(4, 29);
            tabIntro.Name = "tabIntro";
            tabIntro.Padding = new Padding(3);
            tabIntro.Size = new Size(970, 612);
            tabIntro.TabIndex = 0;
            tabIntro.Text = "Introductie";
            tabIntro.UseVisualStyleBackColor = true;
            // 
            // labelIntroTitle
            // 
            labelIntroTitle.Dock = DockStyle.Top;
            labelIntroTitle.Font = new Font("Cambria", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIntroTitle.Location = new Point(3, 3);
            labelIntroTitle.Name = "labelIntroTitle";
            labelIntroTitle.Padding = new Padding(0, 20, 0, 0);
            labelIntroTitle.Size = new Size(964, 76);
            labelIntroTitle.TabIndex = 0;
            labelIntroTitle.Text = "Introductie";
            labelIntroTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // introLayoutPanel
            // 
            introLayoutPanel.ColumnCount = 1;
            introLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            introLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            introLayoutPanel.Controls.Add(labelIntroContent, 0, 0);
            introLayoutPanel.Dock = DockStyle.Fill;
            introLayoutPanel.Location = new Point(3, 79);
            introLayoutPanel.Name = "introLayoutPanel";
            introLayoutPanel.RowCount = 1;
            introLayoutPanel.RowStyles.Add(new RowStyle());
            introLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            introLayoutPanel.Size = new Size(964, 530);
            introLayoutPanel.TabIndex = 1;
            // 
            // labelIntroContent
            // 
            labelIntroContent.AutoSize = true;
            labelIntroContent.Dock = DockStyle.Fill;
            labelIntroContent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelIntroContent.Location = new Point(3, 10);
            labelIntroContent.Margin = new Padding(3, 10, 3, 0);
            labelIntroContent.Name = "labelIntroContent";
            labelIntroContent.Padding = new Padding(0, 20, 0, 0);
            labelIntroContent.Size = new Size(958, 520);
            labelIntroContent.TabIndex = 0;
            labelIntroContent.Text = resources.GetString("labelIntroContent.Text");
            labelIntroContent.TextAlign = ContentAlignment.TopCenter;
            // 
            // manualTabControl
            // 
            manualTabControl.Controls.Add(tabIntro);
            manualTabControl.Controls.Add(tabAddPerson);
            manualTabControl.Controls.Add(tabChooseStudy);
            manualTabControl.Controls.Add(tabEditPerson);
            manualTabControl.Controls.Add(tabCalculateJob);
            manualTabControl.Controls.Add(tabLog);
            manualTabControl.Controls.Add(tabManage);
            manualTabControl.Controls.Add(tabTotalProgress);
            manualTabControl.Dock = DockStyle.Fill;
            manualTabControl.Location = new Point(3, 3);
            manualTabControl.Name = "manualTabControl";
            manualTabControl.SelectedIndex = 0;
            manualTabControl.Size = new Size(978, 645);
            manualTabControl.TabIndex = 0;
            // 
            // tabManage
            // 
            tabManage.Controls.Add(manageLayoutPanel);
            tabManage.Controls.Add(labelManageTitle);
            tabManage.Location = new Point(4, 29);
            tabManage.Name = "tabManage";
            tabManage.Padding = new Padding(3);
            tabManage.Size = new Size(970, 612);
            tabManage.TabIndex = 6;
            tabManage.Text = "Applicatie beheren";
            tabManage.UseVisualStyleBackColor = true;
            // 
            // labelManageTitle
            // 
            labelManageTitle.Dock = DockStyle.Top;
            labelManageTitle.Font = new Font("Cambria", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelManageTitle.Location = new Point(3, 3);
            labelManageTitle.Name = "labelManageTitle";
            labelManageTitle.Padding = new Padding(0, 20, 0, 0);
            labelManageTitle.Size = new Size(964, 76);
            labelManageTitle.TabIndex = 2;
            labelManageTitle.Text = "Applicatie beheren";
            labelManageTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // manageLayoutPanel
            // 
            manageLayoutPanel.ColumnCount = 1;
            manageLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            manageLayoutPanel.Controls.Add(labelManageContent, 0, 0);
            manageLayoutPanel.Dock = DockStyle.Fill;
            manageLayoutPanel.Location = new Point(3, 79);
            manageLayoutPanel.Margin = new Padding(3, 10, 3, 3);
            manageLayoutPanel.Name = "manageLayoutPanel";
            manageLayoutPanel.Padding = new Padding(0, 10, 0, 0);
            manageLayoutPanel.RowCount = 1;
            manageLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            manageLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            manageLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            manageLayoutPanel.Size = new Size(964, 530);
            manageLayoutPanel.TabIndex = 4;
            // 
            // labelManageContent
            // 
            labelManageContent.AutoSize = true;
            labelManageContent.Dock = DockStyle.Fill;
            labelManageContent.Font = new Font("Segoe UI", 12F);
            labelManageContent.ImageAlign = ContentAlignment.TopCenter;
            labelManageContent.Location = new Point(3, 10);
            labelManageContent.Name = "labelManageContent";
            labelManageContent.Padding = new Padding(0, 20, 0, 0);
            labelManageContent.Size = new Size(958, 520);
            labelManageContent.TabIndex = 0;
            labelManageContent.Text = resources.GetString("labelManageContent.Text");
            labelManageContent.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabTotalProgress
            // 
            tabTotalProgress.Controls.Add(totalProgressLayoutPanel);
            tabTotalProgress.Controls.Add(labelTotalProgressTitle);
            tabTotalProgress.Location = new Point(4, 29);
            tabTotalProgress.Name = "tabTotalProgress";
            tabTotalProgress.Padding = new Padding(3);
            tabTotalProgress.Size = new Size(970, 612);
            tabTotalProgress.TabIndex = 7;
            tabTotalProgress.Text = "Totale voortgang";
            tabTotalProgress.UseVisualStyleBackColor = true;
            // 
            // totalProgressLayoutPanel
            // 
            totalProgressLayoutPanel.ColumnCount = 1;
            totalProgressLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            totalProgressLayoutPanel.Controls.Add(labelTotalProgressContent, 0, 0);
            totalProgressLayoutPanel.Dock = DockStyle.Fill;
            totalProgressLayoutPanel.Location = new Point(3, 79);
            totalProgressLayoutPanel.Margin = new Padding(3, 10, 3, 3);
            totalProgressLayoutPanel.Name = "totalProgressLayoutPanel";
            totalProgressLayoutPanel.Padding = new Padding(0, 10, 0, 0);
            totalProgressLayoutPanel.RowCount = 1;
            totalProgressLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            totalProgressLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            totalProgressLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            totalProgressLayoutPanel.Size = new Size(964, 530);
            totalProgressLayoutPanel.TabIndex = 4;
            // 
            // labelTotalProgressContent
            // 
            labelTotalProgressContent.AutoSize = true;
            labelTotalProgressContent.Dock = DockStyle.Fill;
            labelTotalProgressContent.Font = new Font("Segoe UI", 12F);
            labelTotalProgressContent.ImageAlign = ContentAlignment.TopCenter;
            labelTotalProgressContent.Location = new Point(3, 10);
            labelTotalProgressContent.Name = "labelTotalProgressContent";
            labelTotalProgressContent.Padding = new Padding(0, 20, 0, 0);
            labelTotalProgressContent.Size = new Size(958, 520);
            labelTotalProgressContent.TabIndex = 0;
            labelTotalProgressContent.Text = resources.GetString("labelTotalProgressContent.Text");
            labelTotalProgressContent.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelTotalProgressTitle
            // 
            labelTotalProgressTitle.Dock = DockStyle.Top;
            labelTotalProgressTitle.Font = new Font("Cambria", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalProgressTitle.Location = new Point(3, 3);
            labelTotalProgressTitle.Name = "labelTotalProgressTitle";
            labelTotalProgressTitle.Padding = new Padding(0, 20, 0, 0);
            labelTotalProgressTitle.Size = new Size(964, 76);
            labelTotalProgressTitle.TabIndex = 2;
            labelTotalProgressTitle.Text = "Totale voortgang";
            labelTotalProgressTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // ManualForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 711);
            Controls.Add(mainLayoutPanel);
            MinimumSize = new Size(1000, 750);
            Name = "ManualForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Handleiding - Job Calculator";
            mainLayoutPanel.ResumeLayout(false);
            navigationPanel.ResumeLayout(false);
            navigationPanel.PerformLayout();
            tabLog.ResumeLayout(false);
            logLayoutPanel.ResumeLayout(false);
            logLayoutPanel.PerformLayout();
            tabCalculateJob.ResumeLayout(false);
            calculateJobLayoutPanel.ResumeLayout(false);
            calculateJobLayoutPanel.PerformLayout();
            tabEditPerson.ResumeLayout(false);
            tabChooseStudy.ResumeLayout(false);
            chooseStudyLayoutPanel.ResumeLayout(false);
            chooseStudyLayoutPanel.PerformLayout();
            tabAddPerson.ResumeLayout(false);
            addPersonLayoutPanel.ResumeLayout(false);
            addPersonLayoutPanel.PerformLayout();
            tabIntro.ResumeLayout(false);
            introLayoutPanel.ResumeLayout(false);
            introLayoutPanel.PerformLayout();
            manualTabControl.ResumeLayout(false);
            tabManage.ResumeLayout(false);
            manageLayoutPanel.ResumeLayout(false);
            manageLayoutPanel.PerformLayout();
            tabTotalProgress.ResumeLayout(false);
            totalProgressLayoutPanel.ResumeLayout(false);
            totalProgressLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Hoofdindeling
        private TableLayoutPanel mainLayoutPanel;

        // Navigatie
        private FlowLayoutPanel navigationPanel;
        private Button backButton;
        private TableLayoutPanel totalProgressLayoutPanel;
        private TabControl manualTabControl;
        private TabPage tabIntro;
        private TableLayoutPanel introLayoutPanel;
        private Label labelIntroContent;
        private Label labelIntroTitle;
        private TabPage tabAddPerson;
        private TableLayoutPanel addPersonLayoutPanel;
        private Label labelAddPersonContent;
        private Label labelAddPersonTitle;
        private TabPage tabChooseStudy;
        private TableLayoutPanel chooseStudyLayoutPanel;
        private Label labelChooseStudyContent;
        private Label labelChooseStudyTitle;
        private TabPage tabEditPerson;
        private Label labelEditPersonContent;
        private Label labelEditPersonTitle;
        private TabPage tabCalculateJob;
        private TableLayoutPanel calculateJobLayoutPanel;
        private Label labelCalculateJobContent;
        private Label labelCalculateJobTitle;
        private TabPage tabLog;
        private TableLayoutPanel logLayoutPanel;
        private Label labelLogContent;
        private Label labelLogTitle;
        private TabPage tabManage;
        private TableLayoutPanel manageLayoutPanel;
        private Label labelManageContent;
        private Label labelManageTitle;
        private TabPage tabTotalProgress;
        private Label labelTotalProgressContent;
        private Label labelTotalProgressTitle;
    }
}