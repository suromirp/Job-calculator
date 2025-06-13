using System.Windows.Forms;

namespace Eindopdracht___Programmeren_in_C____LOI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent()
        {
            Button BtnAddPerson;
            menuStripTop = new MenuStrip();
            manageMenuItem = new ToolStripMenuItem();
            initialiseMenuItem = new ToolStripMenuItem();
            resetMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            manualMenuItem = new ToolStripMenuItem();
            mainLayoutPanel = new FlowLayoutPanel();
            logBox = new RichTextBox();
            mainLayout = new TableLayoutPanel();
            totalStatusStrip = new StatusStrip();
            totalStatusLabel = new ToolStripStatusLabel();
            totalProgressBar = new ToolStripProgressBar();
            statusPercentage = new ToolStripStatusLabel();
            BtnAddPerson = new Button();
            menuStripTop.SuspendLayout();
            mainLayout.SuspendLayout();
            totalStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // BtnAddPerson
            // 
            BtnAddPerson.AutoSize = true;
            BtnAddPerson.Dock = DockStyle.Left;
            BtnAddPerson.Font = new Font("Segoe UI", 11F);
            BtnAddPerson.Location = new Point(10, 515);
            BtnAddPerson.Margin = new Padding(10, 11, 10, 5);
            BtnAddPerson.Name = "BtnAddPerson";
            BtnAddPerson.Padding = new Padding(10, 11, 10, 11);
            BtnAddPerson.Size = new Size(216, 68);
            BtnAddPerson.TabIndex = 2;
            BtnAddPerson.Text = "Voeg persoon toe";
            BtnAddPerson.UseVisualStyleBackColor = true;
            BtnAddPerson.Click += BtnAddPerson_Click;
            // 
            // MenuStripTop
            // 
            menuStripTop.ImageScalingSize = new Size(20, 20);
            menuStripTop.Items.AddRange(new ToolStripItem[] { manageMenuItem, manualMenuItem });
            menuStripTop.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStripTop.Location = new Point(0, 0);
            menuStripTop.Name = "MenuStripTop";
            menuStripTop.Padding = new Padding(7, 3, 0, 3);
            menuStripTop.RenderMode = ToolStripRenderMode.System;
            menuStripTop.Size = new Size(1182, 30);
            menuStripTop.Stretch = false;
            menuStripTop.TabIndex = 0;
            menuStripTop.Text = "MenuStripTop";
            // 
            // ManageToolStripMenuItem
            // 
            manageMenuItem.DropDownItems.AddRange(new ToolStripItem[] { initialiseMenuItem, resetMenuItem, exitMenuItem });
            manageMenuItem.Name = "ManageToolStripMenuItem";
            manageMenuItem.Size = new Size(69, 24);
            manageMenuItem.Text = "Beheer";
            // 
            // InitialisationToolStripMenuItem
            // 
            initialiseMenuItem.Name = "InitialisationToolStripMenuItem";
            initialiseMenuItem.Size = new Size(164, 26);
            initialiseMenuItem.Text = "Initialisatie";
            initialiseMenuItem.Click += InitialisationToolStripMenuItem_Click;
            // 
            // ResetToolStripMenuItem
            // 
            resetMenuItem.Name = "ResetToolStripMenuItem";
            resetMenuItem.Size = new Size(164, 26);
            resetMenuItem.Text = "Reset";
            resetMenuItem.Click += ResetToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            exitMenuItem.Name = "ExitToolStripMenuItem";
            exitMenuItem.Size = new Size(164, 26);
            exitMenuItem.Text = "Afsluiten";
            exitMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // ManualToolStripMenuItem
            // 
            manualMenuItem.BackColor = SystemColors.ButtonFace;
            manualMenuItem.Name = "ManualToolStripMenuItem";
            manualMenuItem.Size = new Size(105, 24);
            manualMenuItem.Text = "Handleiding";
            manualMenuItem.Click += ManualToolStripMenuItem_Click;
            // 
            // MainLayoutPanel
            // 
            mainLayoutPanel.AutoScroll = true;
            mainLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainLayoutPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.Location = new Point(10, 41);
            mainLayoutPanel.Margin = new Padding(10, 11, 10, 11);
            mainLayoutPanel.Name = "MainLayoutPanel";
            mainLayoutPanel.Size = new Size(1162, 452);
            mainLayoutPanel.TabIndex = 1;
            // 
            // LogBox
            // 
            logBox.Dock = DockStyle.Bottom;
            logBox.Location = new Point(3, 591);
            logBox.Name = "LogBox";
            logBox.ReadOnly = true;
            logBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            logBox.Size = new Size(1176, 127);
            logBox.TabIndex = 3;
            logBox.Text = "";
            // 
            // MainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(menuStripTop, 0, 0);
            mainLayout.Controls.Add(mainLayoutPanel, 0, 1);
            mainLayout.Controls.Add(BtnAddPerson, 0, 2);
            mainLayout.Controls.Add(logBox, 0, 3);
            mainLayout.Controls.Add(totalStatusStrip, 0, 4);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "MainLayout";
            mainLayout.RowCount = 5;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 133F));
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            mainLayout.Size = new Size(1182, 753);
            mainLayout.TabIndex = 0;
            // 
            // TotalStatusStrip
            // 
            totalStatusStrip.Dock = DockStyle.Fill;
            totalStatusStrip.ImageScalingSize = new Size(20, 20);
            totalStatusStrip.Items.AddRange(new ToolStripItem[] { totalStatusLabel, totalProgressBar, statusPercentage });
            totalStatusStrip.Location = new Point(0, 721);
            totalStatusStrip.Name = "TotalStatusStrip";
            totalStatusStrip.Size = new Size(1182, 32);
            totalStatusStrip.SizingGrip = false;
            totalStatusStrip.TabIndex = 1;
            // 
            // TotalStatusLabel
            // 
            totalStatusLabel.Name = "TotalStatusLabel";
            totalStatusLabel.Overflow = ToolStripItemOverflow.Never;
            totalStatusLabel.Size = new Size(197, 26);
            totalStatusLabel.Spring = true;
            totalStatusLabel.Text = "Gereed: 0/2";
            // 
            // TotalProgressBar
            // 
            totalProgressBar.AutoToolTip = true;
            totalProgressBar.BackColor = Color.White;
            totalProgressBar.Name = "TotalProgressBar";
            totalProgressBar.Overflow = ToolStripItemOverflow.Never;
            totalProgressBar.Size = new Size(900, 24);
            totalProgressBar.Style = ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabelPercentage
            // 
            statusPercentage.Name = "toolStripStatusLabelPercentage";
            statusPercentage.Size = new Size(29, 26);
            statusPercentage.Text = "0%";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1182, 753);
            Controls.Add(mainLayout);
            MainMenuStrip = menuStripTop;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Load += MainForm_Load;
            menuStripTop.ResumeLayout(false);
            menuStripTop.PerformLayout();
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            totalStatusStrip.ResumeLayout(false);
            totalStatusStrip.PerformLayout();
            ResumeLayout(false);        }

        #endregion
        // Menu
        private MenuStrip menuStripTop;
        private ToolStripMenuItem manualMenuItem;
        private ToolStripMenuItem manageMenuItem;
        private ToolStripMenuItem initialiseMenuItem;
        private ToolStripMenuItem resetMenuItem;
        private ToolStripMenuItem exitMenuItem;

        // Layout
        private TableLayoutPanel mainLayout;
        private FlowLayoutPanel mainLayoutPanel;

        // Log
        private RichTextBox logBox;

        // Statusbalk
        private StatusStrip totalStatusStrip;
        private ToolStripStatusLabel totalStatusLabel;
        private ToolStripProgressBar totalProgressBar;
        private ToolStripStatusLabel statusPercentage;
    }
}
