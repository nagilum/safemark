using Safemark.Models;

namespace Safemark.Dialogs;

public partial class UrlEntryDialog : Form
{
    #region Properties

    /// <summary>
    /// Bookmark entry to edit.
    /// </summary>
    public BookmarkEntry? Entry { get; set; }

    /// <summary>
    /// Tags.
    /// </summary>
    public string[]? Tags
    {
        get
        {
            var tags = this.TagsTextBox.Text.Trim().Split(',');

            return tags.Length > 0
                ? tags
                : null;
        }
    }

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

    /// <summary>
    /// Url
    /// </summary>
    public Uri? Url
    {
        get
        {
            try
            {
                return new Uri(this.UrlTextBox.Text.Trim())
                    ?? throw new Exception("Unable to get URL from text.");
            }
            catch
            {
                return null;
            }
        }
    }

    #endregion

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="entry">Bookmark entry to edit.</param>
    public UrlEntryDialog(BookmarkEntry? entry = null)
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
        var tags = this.Tags;
        var url = this.Url;

        if (url is null)
        {
            MessageBox.Show(
                "URL is required!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        if (this.Entry is not null)
        {
            this.Entry.Title = title;
            this.Entry.Tags = tags;
            this.Entry.Uri = url;
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
        this.UrlTextBox.Text = this.Entry.Uri?.ToString();
        this.TagsTextBox.Text = this.Entry.Tags?.Length > 0
            ? string.Join(", ", this.Entry.Tags)
            : string.Empty;
    }

    #endregion
}