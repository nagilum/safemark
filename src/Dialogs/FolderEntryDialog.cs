using Safemark.Models;

namespace Safemark.Dialogs;

public partial class FolderEntryDialog : Form
{
    #region Properties

    /// <summary>
    /// Bookmark entry to edit.
    /// </summary>
    public BookmarkEntry? Entry { get; set; }

    /// <summary>
    /// Title.
    /// </summary>
    public string? Title
    {
        get
        {
            var title = this.TitleTextBox.Text.Trim();

            return string.IsNullOrWhiteSpace(title)
                ? null
                : title;
        }
    }

    #endregion

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="entry">Bookmark entry to edit.</param>
    public FolderEntryDialog(BookmarkEntry? entry = null)
    {
        this.InitializeComponent();

        this.Entry = entry;

        this.AddEvents();
        this.BindEntry();
    }

    #region Control events

    /// <summary>
    /// Verify title.
    /// </summary>
    private void OkButton_Click(object? sender, EventArgs e)
    {
        var title = this.Title;

        if (title is null)
        {
            MessageBox.Show(
                "Title is required!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        if (this.Entry is not null)
        {
            this.Entry.Title = title;
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

    /// <summary>
    /// Bind data to controls.
    /// </summary>
    private void BindEntry()
    {
        if (this.Entry is null)
        {
            return;
        }

        this.TitleTextBox.Text = this.Entry.Title;
    }

    #endregion
}