namespace Safemark.Dialogs;

public partial class PasswordDialog : Form
{
    #region Properties

    /// <summary>
    /// Password.
    /// </summary>
    public string? Password
    {
        get
        {
            var password = this.PasswordTextBox.Text.Trim();

            return string.IsNullOrWhiteSpace(password)
                ? null
                : password;
        }
    }

    #endregion

    /// <summary>
    /// Constructor.
    /// </summary>
    public PasswordDialog()
    {
        this.InitializeComponent();
        this.AddEvents();
    }

    #region Control events

    /// <summary>
    /// Verify title.
    /// </summary>
    private void OkButton_Click(object? sender, EventArgs e)
    {
        var password = this.Password;

        if (password is null)
        {
            MessageBox.Show(
                "Password is required!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        this.DialogResult = DialogResult.OK;
    }

    #endregion

    #region Helper functions

    /// <summary>
    /// Add events to the form and its controls.
    /// </summary>
    private void AddEvents()
    {
        this.OkButton.Click += this.OkButton_Click;
    }

    #endregion
}