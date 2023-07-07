namespace Safemark.Dialogs
{
    partial class UrlEntryDialog
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
            TitleTextBox = new TextBox();
            TitleLabel = new Label();
            TagsTextBox = new TextBox();
            TagsLabel = new Label();
            UrlTextBox = new TextBox();
            UrlLabel = new Label();
            CancelButton = new Button();
            OkButton = new Button();
            this.SuspendLayout();
            // 
            // TitleTextBox
            // 
            TitleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TitleTextBox.Location = new Point(12, 27);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(402, 23);
            TitleTextBox.TabIndex = 3;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(32, 15);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Title:";
            // 
            // TagsTextBox
            // 
            TagsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TagsTextBox.Location = new Point(12, 76);
            TagsTextBox.Name = "TagsTextBox";
            TagsTextBox.Size = new Size(402, 23);
            TagsTextBox.TabIndex = 5;
            // 
            // TagsLabel
            // 
            TagsLabel.AutoSize = true;
            TagsLabel.Location = new Point(12, 58);
            TagsLabel.Name = "TagsLabel";
            TagsLabel.Size = new Size(139, 15);
            TagsLabel.TabIndex = 4;
            TagsLabel.Text = "Tags: (comma separated)";
            // 
            // UrlTextBox
            // 
            UrlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UrlTextBox.Location = new Point(12, 125);
            UrlTextBox.Name = "UrlTextBox";
            UrlTextBox.Size = new Size(402, 23);
            UrlTextBox.TabIndex = 7;
            // 
            // UrlLabel
            // 
            UrlLabel.AutoSize = true;
            UrlLabel.Location = new Point(12, 107);
            UrlLabel.Name = "UrlLabel";
            UrlLabel.Size = new Size(31, 15);
            UrlLabel.TabIndex = 6;
            UrlLabel.Text = "URL:";
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(325, 218);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(89, 36);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "&Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            OkButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OkButton.Location = new Point(230, 218);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(89, 36);
            OkButton.TabIndex = 8;
            OkButton.Text = "&Ok";
            OkButton.UseVisualStyleBackColor = true;
            // 
            // UrlEntryDialog
            // 
            this.AcceptButton = OkButton;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelButton;
            this.ClientSize = new Size(426, 266);
            this.Controls.Add(CancelButton);
            this.Controls.Add(OkButton);
            this.Controls.Add(UrlTextBox);
            this.Controls.Add(UrlLabel);
            this.Controls.Add(TagsTextBox);
            this.Controls.Add(TagsLabel);
            this.Controls.Add(TitleTextBox);
            this.Controls.Add(TitleLabel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrlEntryDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Edit URL entry";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox TitleTextBox;
        private Label TitleLabel;
        private TextBox TagsTextBox;
        private Label TagsLabel;
        private TextBox UrlTextBox;
        private Label UrlLabel;
        private Button CancelButton;
        private Button OkButton;
    }
}