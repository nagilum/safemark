namespace Safemark.Dialogs
{
    partial class PasswordDialog
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
            PasswordTextBox = new TextBox();
            PasswordLabel = new Label();
            CancelButton = new Button();
            OkButton = new Button();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PasswordTextBox.Location = new Point(12, 27);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(319, 23);
            PasswordTextBox.TabIndex = 3;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(12, 9);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(60, 15);
            PasswordLabel.TabIndex = 2;
            PasswordLabel.Text = "Password:";
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(242, 116);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(89, 36);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "&Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            OkButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Location = new Point(147, 116);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(89, 36);
            OkButton.TabIndex = 4;
            OkButton.Text = "&Ok";
            OkButton.UseVisualStyleBackColor = true;
            // 
            // PasswordDialog
            // 
            this.AcceptButton = OkButton;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelButton;
            this.ClientSize = new Size(343, 164);
            this.Controls.Add(CancelButton);
            this.Controls.Add(OkButton);
            this.Controls.Add(PasswordTextBox);
            this.Controls.Add(PasswordLabel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Enter your password";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox PasswordTextBox;
        private Label PasswordLabel;
        private Button CancelButton;
        private Button OkButton;
    }
}