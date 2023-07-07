namespace Safemark.Dialogs
{
    partial class FolderEntryDialog
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
            TitleLabel = new Label();
            TitleTextBox = new TextBox();
            OkButton = new Button();
            CancelButton = new Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(32, 15);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Title:";
            // 
            // TitleTextBox
            // 
            TitleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TitleTextBox.Location = new Point(12, 27);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(319, 23);
            TitleTextBox.TabIndex = 1;
            // 
            // OkButton
            // 
            OkButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OkButton.Location = new Point(147, 116);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(89, 36);
            OkButton.TabIndex = 2;
            OkButton.Text = "&Ok";
            OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(242, 116);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(89, 36);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "&Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // FolderEntryDialog
            // 
            this.AcceptButton = OkButton;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(343, 164);
            this.Controls.Add(CancelButton);
            this.Controls.Add(OkButton);
            this.Controls.Add(TitleTextBox);
            this.Controls.Add(TitleLabel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolderEntryDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Enter folder title";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private TextBox TitleTextBox;
        private Button OkButton;
        private Button CancelButton;
    }
}