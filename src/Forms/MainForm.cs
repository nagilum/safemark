using Safemark.Core;
using Safemark.Dialogs;
using Safemark.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Safemark.Forms;

public partial class MainForm : Form
{
    #region Properties

    /// <summary>
    /// Bookmark entries.
    /// </summary>
    private List<BookmarkEntry>? BookmarkEntries { get; set; }

    /// <summary>
    /// Path to Safemark file.
    /// </summary>
    private string? FilePath { get; set; }

    /// <summary>
    /// Which root entry to draw from.
    /// </summary>
    private Guid? RootEntryId { get; set; }

    #endregion

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="path">Path to Safemark bookmarks file to load.</param>
    public MainForm(string? path)
    {
        this.InitializeComponent();
        this.LoadSettings();
        this.AddEvents();

        this.Text = Program.ProgramNameAndVersion;

        if (path is not null)
        {
            this.LoadFile(path);
        }
        else
        {
            this.UpdateMenuItemStates();
        }
    }

    #region Form events

    /// <summary>
    /// Form existed resizing mode.
    /// </summary>
    private void MainForm_ResizeEnd(object? sender, EventArgs e)
    {
        this.SaveSettings();
    }

    #endregion

    #region Control events

    /// <summary>
    /// Occurs when the list-view is double-clicked on.
    /// </summary>
    private void BookmarkEntriesListView_DoubleClick(object? sender, EventArgs e)
    {
        if (this.BookmarkEntriesListView.SelectedItems.Count == 0)
        {
            return;
        }

        if (this.BookmarkEntriesListView.SelectedItems[0].Tag is string str &&
            str == "--ROOT--")
        {
            this.RootEntryId = null;
            this.PopulateBookmarkEntries();
        }
        else if (this.BookmarkEntriesListView.SelectedItems[0].Tag is Guid id)
        {
            var entry = this.BookmarkEntries!
                .Find(n => n.Id == id);

            if (entry is null)
            {
                return;
            }

            if (entry.EntryType is BookmarkEntryType.Folder)
            {
                this.RootEntryId = entry.Id;
                this.PopulateBookmarkEntries();
            }
            else if (entry.EntryType is BookmarkEntryType.URL &&
                     entry.Uri is not null)
            {
                Clipboard.SetText(entry.Uri.ToString());

                MessageBox.Show(
                    $"URL {entry.Uri} copied to clipboard.",
                    "Copied to Clipboard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }

    /// <summary>
    /// Occurs when the list-view select-index collection changes.
    /// </summary>
    private void BookmarkEntriesListView_SelectedIndexChanged(object? _, EventArgs _2)
    {
        this.UpdateMenuItemStates();
    }

    #endregion

    #region Main menu events

    /// <summary>
    /// Create a blank new document.
    /// </summary>
    private void FileMenuNewMenuItem_Click(object? sender, EventArgs e)
    {
        var dialog = new SaveFileDialog
        {
            DefaultExt = "safemark",
            FileName = "New file",
            Filter = "Safemark files (.safemark)|*.safemark|All Files|*.*",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            OverwritePrompt = true,
            ShowPinnedPlaces = true,
            Title = "Enter filename for new Safemark file"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        this.RootEntryId = null;
        this.BookmarkEntries = new();
        this.BookmarkEntriesListView.Items.Clear();

        this.FilePath = dialog.FileName;
        this.Text = $"{this.FilePath} - {Program.ProgramNameAndVersion}";

        this.UpdateMenuItemStates();
    }

    /// <summary>
    /// Ask for file to load.
    /// </summary>
    private void FileMenuOpenMenuItem_Click(object? sender, EventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            Filter = "Safemark files (.safemark)|*.safemark|All Files|*.*",
            Multiselect = false,
            OkRequiresInteraction = true,
            ShowPinnedPlaces = true,
            Title = "Select file to open"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        this.LoadFile(dialog.FileName);
    }

    /// <summary>
    /// ASk for a new path and save file.
    /// </summary>
    private void FileMenuSaveAsMenuItem_Click(object? sender, EventArgs e)
    {
        var dialog = new SaveFileDialog
        {
            DefaultExt = "safemark",
            FileName = this.FilePath is not null
                ? this.FilePath
                : "New file",
            Filter = "Safemark files (.safemark)|*.safemark|All Files|*.*",
            InitialDirectory = this.FilePath is not null
                ? Path.GetDirectoryName(this.FilePath)
                : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            OverwritePrompt = true,
            ShowPinnedPlaces = true,
            Title = "Enter filename for new Safemark file"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        this.SaveFile(dialog.FileName);
    }

    /// <summary>
    /// Exit application.
    /// </summary>
    private void FileMenuExitMenuItem_Click(object? sender, EventArgs e)
    {
        this.Close();
    }

    /// <summary>
    /// Create a new folder.
    /// </summary>
    private void BookmarksMenuNewFolderMenuItem_Click(object? sender, EventArgs e)
    {
        var dialog = new FolderEntryDialog();

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var entry = new BookmarkEntry
        {
            EntryType = BookmarkEntryType.Folder,
            ParentId = this.RootEntryId,
            Title = dialog.Title
        };

        this.BookmarkEntries!.Add(entry);

        this.SaveFile();
        this.PopulateBookmarkEntries();
    }

    /// <summary>
    /// Create a new bookmark.
    /// </summary>
    private void BookmarksMenuNewUrlMenuItem_Click(object? sender, EventArgs e)
    {
        var dialog = new UrlEntryDialog();

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        var entry = new BookmarkEntry
        {
            EntryType = BookmarkEntryType.URL,
            ParentId = this.RootEntryId,
            Title = dialog.Title,
            Tags = dialog.Tags,
            Uri = dialog.Url
        };

        this.BookmarkEntries!.Add(entry);

        this.SaveFile();
        this.PopulateBookmarkEntries();
    }

    /// <summary>
    /// Edit currently selected entry.
    /// </summary>
    private void BookmarksMenuEditMenuItem_Click(object? sender, EventArgs e)
    {
        if (this.BookmarkEntriesListView.SelectedItems.Count == 0 ||
            this.BookmarkEntriesListView.SelectedItems[0].Tag is not Guid id)
        {
            return;
        }

        var entry = this.BookmarkEntries!
            .Find(n => n.Id == id);

        if (entry is null)
        {
            return;
        }

        if (entry.EntryType is BookmarkEntryType.Folder)
        {
            var dialog = new FolderEntryDialog(entry);

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
        }
        else if (entry.EntryType is BookmarkEntryType.URL)
        {
            var dialog = new UrlEntryDialog(entry);

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
        }

        this.SaveFile();
        this.PopulateBookmarkEntries();
    }

    /// <summary>
    /// Delete currently selected entry.
    /// </summary>
    private void BookmarksMenuDeleteMenuItem_Click(object? sender, EventArgs e)
    {
        if (this.BookmarkEntriesListView.SelectedItems.Count == 0 ||
            this.BookmarkEntriesListView.SelectedItems[0].Tag is not Guid id)
        {
            return;
        }

        var entry = this.BookmarkEntries!
            .Find(n => n.Id == id);

        if (entry is null)
        {
            return;
        }

        var res = MessageBox.Show(
            "Are you sure?",
            "Delete?",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (res is not DialogResult.Yes)
        {
            return;
        }

        this.BookmarkEntries.Remove(entry);

        this.SaveFile();
        this.PopulateBookmarkEntries();
    }

    /// <summary>
    /// Open URL to GitHub repo in default browser.
    /// </summary>
    private void HelpMenuGoToRepositoryMenuItem_Click(object? sender, EventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo(Program.GitHubRepositoryUrl)
            {
                UseShellExecute = true
            });
        }
        catch
        {
            Clipboard.SetText(Program.GitHubRepositoryUrl);

            MessageBox.Show(
                "Unable to open your default browser to the GitHub repository, " +
                "so the URL is copied to the clipboard. " +
                "The URL is " + Program.GitHubRepositoryUrl,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Show program info and version.
    /// </summary>
    private void HelpMenuAboutMenuItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show(
            Program.ProgramNameAndVersion + Environment.NewLine +
            "Written by Stian Hanger <pdnagilum@gmail.com>" + Environment.NewLine +
            Program.GitHubRepositoryUrl + Environment.NewLine +
            Environment.NewLine +
            "Icons created by Freepik at Flaticon" + Environment.NewLine +
            "https://www.flaticon.com/free-icons/bookmark",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    #endregion

    #region Helper functions

    /// <summary>
    /// Add events to the form and its controls.
    /// </summary>
    private void AddEvents()
    {
        // Form events.
        this.ResizeEnd += this.MainForm_ResizeEnd;

        // File menu.
        this.FileMenuNewMenuItem.Click += this.FileMenuNewMenuItem_Click;
        this.FileMenuOpenMenuItem.Click += this.FileMenuOpenMenuItem_Click;
        this.FileMenuSaveAsMenuItem.Click += this.FileMenuSaveAsMenuItem_Click;
        this.FileMenuExitMenuItem.Click += this.FileMenuExitMenuItem_Click;

        // Bookmarks menu.
        this.BookmarksMenuNewFolderMenuItem.Click += this.BookmarksMenuNewFolderMenuItem_Click;
        this.BookmarksMenuNewUrlMenuItem.Click += this.BookmarksMenuNewUrlMenuItem_Click;
        this.BookmarksMenuEditMenuItem.Click += this.BookmarksMenuEditMenuItem_Click;
        this.BookmarksMenuDeleteMenuItem.Click += this.BookmarksMenuDeleteMenuItem_Click;

        // Help menu.
        this.HelpMenuGoToRepositoryMenuItem.Click += this.HelpMenuGoToRepositoryMenuItem_Click;
        this.HelpMenuAboutMenuItem.Click += this.HelpMenuAboutMenuItem_Click;

        // Context menu.
        this.BookmarksContextNewFolderMenuItem.Click += this.BookmarksMenuNewFolderMenuItem_Click;
        this.BookmarksContextNewUrlMenuItem.Click += this.BookmarksMenuNewUrlMenuItem_Click;
        this.BookmarksContextEditMenuItem.Click += this.BookmarksMenuEditMenuItem_Click;
        this.BookmarksContextDeleteMenuItem.Click += this.BookmarksMenuDeleteMenuItem_Click;

        // List view.
        this.BookmarkEntriesListView.DoubleClick += this.BookmarkEntriesListView_DoubleClick;
        this.BookmarkEntriesListView.SelectedIndexChanged += this.BookmarkEntriesListView_SelectedIndexChanged;
    }

    /// <summary>
    /// Load Safemark bookmarks file and populate list view.
    /// </summary>
    /// <param name="path">Path to file.</param>
    private void LoadFile(string path)
    {
        var dialog = new PasswordDialog();

        if (dialog.ShowDialog(this) is not DialogResult.OK ||
            dialog.Password is null)
        {
            return;
        }

        try
        {
            var encryptedData = File.ReadAllText(path, Encoding.UTF8)
                ?? throw new Exception("Unable to read JSON from " + path);

            var json = SimpleAES.AES256.Decrypt(encryptedData, dialog.Password)
                ?? throw new Exception("Unable to decrypt data.");

            var list = JsonSerializer.Deserialize<List<BookmarkEntry>>(json)
                ?? throw new Exception("Unable to deserialize JSON.");

            this.RootEntryId = null;
            this.BookmarkEntries = list;
            this.FilePath = path;
            this.Text = $"{path} - {Program.ProgramNameAndVersion}";

            this.PopulateBookmarkEntries();
        }
        catch (Exception ex)
        {
            this.RootEntryId = null;
            this.BookmarkEntries = null;
            this.BookmarkEntriesListView.Items.Clear();

            this.FilePath = null;
            this.Text = Program.ProgramNameAndVersion;

            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        this.UpdateMenuItemStates();
    }

    /// <summary>
    /// Load and apply settings.
    /// </summary>
    private void LoadSettings()
    {
        this.Location = new Point(
            Properties.Settings.Default.MainFormLeft,
            Properties.Settings.Default.MainFormTop);

        this.Size = new Size(
            Properties.Settings.Default.MainFormWidth,
            Properties.Settings.Default.MainFormHeight);

        this.WindowState = (FormWindowState)Properties.Settings.Default.MainFormWindowState;

        this.TitleColumnHeader.Width = Properties.Settings.Default.ColumnHeaderTitleWidth;
        this.TagsColumnHeader.Width = Properties.Settings.Default.ColumnHeaderTagsWidth;
        this.UrlColumnHeader.Width = Properties.Settings.Default.ColumnHeaderUrlWidth;
    }

    /// <summary>
    /// Populate the list-view with the current selected folder.
    /// </summary>
    private void PopulateBookmarkEntries()
    {
        this.BookmarkEntriesListView.Items.Clear();

        if (this.BookmarkEntries is null)
        {
            return;
        }

        if (this.RootEntryId is not null)
        {
            var parent = this.BookmarkEntries
                .Find(n => n.Id == this.RootEntryId);

            if (parent is not null)
            {
                var item = new ListViewItem(
                    new string[]
                    {
                        "Parent Folder",
                        string.Empty,
                        string.Empty
                    })
                {
                    ImageIndex = 0,
                    Tag = parent.ParentId?.ToString() ?? "--ROOT--"
                };

                this.BookmarkEntriesListView.Items.Add(item);
            }
        }

        var entries = this.BookmarkEntries
            .Where(n => n.ParentId == this.RootEntryId)
            .OrderBy(n => n.Title);

        foreach (var entry in entries.Where(n => n.EntryType == BookmarkEntryType.Folder))
        {
            var item = new ListViewItem(
                new string[]
                {
                    entry.Title ?? "<no title>",
                    string.Empty,
                    string.Empty
                })
            {
                ImageIndex = 0,
                Tag = entry.Id
            };

            this.BookmarkEntriesListView.Items.Add(item);
        }

        foreach (var entry in entries.Where(n => n.EntryType == BookmarkEntryType.URL))
        {
            var item = new ListViewItem(
                new string[]
                {
                    entry.Title ?? "<no title>",
                    entry.Tags?.Length > 0 ? string.Join(", ", entry.Tags) : string.Empty,
                    entry.Uri?.ToString() ?? string.Empty
                })
            {
                ImageIndex = 1,
                Tag = entry.Id
            };

            this.BookmarkEntriesListView.Items.Add(item);
        }
    }

    /// <summary>
    /// Save file to disk.
    /// </summary>
    /// <param name="path">Optional path to file.</param>
    private void SaveFile(string? path = null)
    {
        if (this.BookmarkEntries is null)
        {
            return;
        }

        path ??= this.FilePath;

        if (path is null)
        {
            return;
        }

        var dialog = new PasswordDialog();

        if (dialog.ShowDialog(this) is not DialogResult.OK ||
            dialog.Password is null)
        {
            return;
        }

        try
        {
            var json = JsonSerializer.Serialize(this.BookmarkEntries)
                ?? throw new Exception("Unable to serialize to JSON.");

            var encryptedData = SimpleAES.AES256.Encrypt(json, dialog.Password)
                ?? throw new Exception("Unable to encrypt data.");

            File.WriteAllText(
                path,
                encryptedData,
                Encoding.UTF8);

            this.UpdateMenuItemStates();

            Properties.Settings.Default.LastOpenedFile = path;
            Properties.Settings.Default.Save();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Save settings.
    /// </summary>
    private void SaveSettings()
    {
        Properties.Settings.Default.MainFormWindowState = (int)this.WindowState;

        if (this.WindowState is FormWindowState.Normal)
        {
            Properties.Settings.Default.MainFormLeft = this.Location.X;
            Properties.Settings.Default.MainFormTop = this.Location.Y;

            Properties.Settings.Default.MainFormWidth = this.Size.Width;
            Properties.Settings.Default.MainFormHeight = this.Size.Height;
        }

        Properties.Settings.Default.ColumnHeaderTitleWidth = this.TitleColumnHeader.Width;
        Properties.Settings.Default.ColumnHeaderTagsWidth = this.TagsColumnHeader.Width;
        Properties.Settings.Default.ColumnHeaderUrlWidth = this.UrlColumnHeader.Width;

        Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Update menu items disabled state.
    /// </summary>
    private void UpdateMenuItemStates()
    {
        var hasEntries = this.BookmarkEntries is not null;
        var isSelected = this.BookmarkEntriesListView.SelectedItems.Count > 0;

        // Main menu items.
        this.FileMenuSaveAsMenuItem.Enabled = hasEntries;
        this.BookmarksTopMenu.Enabled = hasEntries;
        this.BookmarksMenuEditMenuItem.Enabled = hasEntries && isSelected;
        this.BookmarksMenuDeleteMenuItem.Enabled = hasEntries && isSelected;

        // Context menu items.
        this.BookmarksContextNewFolderMenuItem.Enabled = hasEntries;
        this.BookmarksContextNewUrlMenuItem.Enabled = hasEntries;
        this.BookmarksContextEditMenuItem.Enabled = hasEntries && isSelected;
        this.BookmarksContextDeleteMenuItem.Enabled = hasEntries && isSelected;
    }

    #endregion
}