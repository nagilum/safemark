namespace Safemark.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainMenuStrip = new MenuStrip();
            FileTopMenu = new ToolStripMenuItem();
            FileMenuNewMenuItem = new ToolStripMenuItem();
            FileMenuOpenMenuItem = new ToolStripMenuItem();
            FileMenuSaveAsMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            FileMenuExitMenuItem = new ToolStripMenuItem();
            BookmarksTopMenu = new ToolStripMenuItem();
            BookmarksMenuNewFolderMenuItem = new ToolStripMenuItem();
            BookmarksMenuNewUrlMenuItem = new ToolStripMenuItem();
            BookmarksMenuEditMenuItem = new ToolStripMenuItem();
            BookmarksMenuDeleteMenuItem = new ToolStripMenuItem();
            HelpTopMenu = new ToolStripMenuItem();
            HelpMenuGoToRepositoryMenuItem = new ToolStripMenuItem();
            HelpMenuAboutMenuItem = new ToolStripMenuItem();
            BookmarkEntriesListView = new ListView();
            TitleColumnHeader = new ColumnHeader();
            TagsColumnHeader = new ColumnHeader();
            UrlColumnHeader = new ColumnHeader();
            BookmarksListViewContextMenu = new ContextMenuStrip(this.components);
            BookmarksContextNewFolderMenuItem = new ToolStripMenuItem();
            BookmarksContextNewUrlMenuItem = new ToolStripMenuItem();
            BookmarksContextEditMenuItem = new ToolStripMenuItem();
            BookmarksContextDeleteMenuItem = new ToolStripMenuItem();
            EntryTypeIcons = new ImageList(this.components);
            MainMenuStrip.SuspendLayout();
            BookmarksListViewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.Items.AddRange(new ToolStripItem[] { FileTopMenu, BookmarksTopMenu, HelpTopMenu });
            MainMenuStrip.Location = new Point(0, 0);
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Size = new Size(1085, 24);
            MainMenuStrip.TabIndex = 0;
            MainMenuStrip.Text = "menuStrip1";
            // 
            // FileTopMenu
            // 
            FileTopMenu.DropDownItems.AddRange(new ToolStripItem[] { FileMenuNewMenuItem, FileMenuOpenMenuItem, FileMenuSaveAsMenuItem, toolStripMenuItem1, FileMenuExitMenuItem });
            FileTopMenu.Name = "FileTopMenu";
            FileTopMenu.Size = new Size(37, 20);
            FileTopMenu.Text = "&File";
            // 
            // FileMenuNewMenuItem
            // 
            FileMenuNewMenuItem.Name = "FileMenuNewMenuItem";
            FileMenuNewMenuItem.Size = new Size(114, 22);
            FileMenuNewMenuItem.Text = "&New";
            // 
            // FileMenuOpenMenuItem
            // 
            FileMenuOpenMenuItem.Name = "FileMenuOpenMenuItem";
            FileMenuOpenMenuItem.Size = new Size(114, 22);
            FileMenuOpenMenuItem.Text = "&Open";
            // 
            // FileMenuSaveAsMenuItem
            // 
            FileMenuSaveAsMenuItem.Name = "FileMenuSaveAsMenuItem";
            FileMenuSaveAsMenuItem.Size = new Size(114, 22);
            FileMenuSaveAsMenuItem.Text = "Save &As";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(111, 6);
            // 
            // FileMenuExitMenuItem
            // 
            FileMenuExitMenuItem.Name = "FileMenuExitMenuItem";
            FileMenuExitMenuItem.Size = new Size(114, 22);
            FileMenuExitMenuItem.Text = "E&xit";
            // 
            // BookmarksTopMenu
            // 
            BookmarksTopMenu.DropDownItems.AddRange(new ToolStripItem[] { BookmarksMenuNewFolderMenuItem, BookmarksMenuNewUrlMenuItem, BookmarksMenuEditMenuItem, BookmarksMenuDeleteMenuItem });
            BookmarksTopMenu.Name = "BookmarksTopMenu";
            BookmarksTopMenu.Size = new Size(78, 20);
            BookmarksTopMenu.Text = "&Bookmarks";
            // 
            // BookmarksMenuNewFolderMenuItem
            // 
            BookmarksMenuNewFolderMenuItem.Name = "BookmarksMenuNewFolderMenuItem";
            BookmarksMenuNewFolderMenuItem.Size = new Size(134, 22);
            BookmarksMenuNewFolderMenuItem.Text = "New &Folder";
            // 
            // BookmarksMenuNewUrlMenuItem
            // 
            BookmarksMenuNewUrlMenuItem.Name = "BookmarksMenuNewUrlMenuItem";
            BookmarksMenuNewUrlMenuItem.Size = new Size(134, 22);
            BookmarksMenuNewUrlMenuItem.Text = "New &URL";
            // 
            // BookmarksMenuEditMenuItem
            // 
            BookmarksMenuEditMenuItem.Name = "BookmarksMenuEditMenuItem";
            BookmarksMenuEditMenuItem.Size = new Size(134, 22);
            BookmarksMenuEditMenuItem.Text = "&Edit";
            // 
            // BookmarksMenuDeleteMenuItem
            // 
            BookmarksMenuDeleteMenuItem.Name = "BookmarksMenuDeleteMenuItem";
            BookmarksMenuDeleteMenuItem.Size = new Size(134, 22);
            BookmarksMenuDeleteMenuItem.Text = "&Delete";
            // 
            // HelpTopMenu
            // 
            HelpTopMenu.DropDownItems.AddRange(new ToolStripItem[] { HelpMenuGoToRepositoryMenuItem, HelpMenuAboutMenuItem });
            HelpTopMenu.Name = "HelpTopMenu";
            HelpTopMenu.Size = new Size(44, 20);
            HelpTopMenu.Text = "&Help";
            // 
            // HelpMenuGoToRepositoryMenuItem
            // 
            HelpMenuGoToRepositoryMenuItem.Name = "HelpMenuGoToRepositoryMenuItem";
            HelpMenuGoToRepositoryMenuItem.Size = new Size(204, 22);
            HelpMenuGoToRepositoryMenuItem.Text = "&Go To GitHub Repository";
            // 
            // HelpMenuAboutMenuItem
            // 
            HelpMenuAboutMenuItem.Name = "HelpMenuAboutMenuItem";
            HelpMenuAboutMenuItem.Size = new Size(204, 22);
            HelpMenuAboutMenuItem.Text = "&About";
            // 
            // BookmarkEntriesListView
            // 
            BookmarkEntriesListView.Columns.AddRange(new ColumnHeader[] { TitleColumnHeader, TagsColumnHeader, UrlColumnHeader });
            BookmarkEntriesListView.ContextMenuStrip = BookmarksListViewContextMenu;
            BookmarkEntriesListView.Dock = DockStyle.Fill;
            BookmarkEntriesListView.FullRowSelect = true;
            BookmarkEntriesListView.Location = new Point(0, 24);
            BookmarkEntriesListView.MultiSelect = false;
            BookmarkEntriesListView.Name = "BookmarkEntriesListView";
            BookmarkEntriesListView.Size = new Size(1085, 604);
            BookmarkEntriesListView.SmallImageList = EntryTypeIcons;
            BookmarkEntriesListView.TabIndex = 1;
            BookmarkEntriesListView.UseCompatibleStateImageBehavior = false;
            BookmarkEntriesListView.View = View.Details;
            // 
            // TitleColumnHeader
            // 
            TitleColumnHeader.Text = "Title";
            // 
            // TagsColumnHeader
            // 
            TagsColumnHeader.Text = "Tags";
            // 
            // UrlColumnHeader
            // 
            UrlColumnHeader.Text = "URL";
            // 
            // BookmarksListViewContextMenu
            // 
            BookmarksListViewContextMenu.Items.AddRange(new ToolStripItem[] { BookmarksContextNewFolderMenuItem, BookmarksContextNewUrlMenuItem, BookmarksContextEditMenuItem, BookmarksContextDeleteMenuItem });
            BookmarksListViewContextMenu.Name = "BookmarksListViewContextMenu";
            BookmarksListViewContextMenu.Size = new Size(135, 92);
            // 
            // BookmarksContextNewFolderMenuItem
            // 
            BookmarksContextNewFolderMenuItem.Name = "BookmarksContextNewFolderMenuItem";
            BookmarksContextNewFolderMenuItem.Size = new Size(134, 22);
            BookmarksContextNewFolderMenuItem.Text = "New &Folder";
            // 
            // BookmarksContextNewUrlMenuItem
            // 
            BookmarksContextNewUrlMenuItem.Name = "BookmarksContextNewUrlMenuItem";
            BookmarksContextNewUrlMenuItem.Size = new Size(134, 22);
            BookmarksContextNewUrlMenuItem.Text = "New &URL";
            // 
            // BookmarksContextEditMenuItem
            // 
            BookmarksContextEditMenuItem.Name = "BookmarksContextEditMenuItem";
            BookmarksContextEditMenuItem.Size = new Size(134, 22);
            BookmarksContextEditMenuItem.Text = "&Edit";
            // 
            // BookmarksContextDeleteMenuItem
            // 
            BookmarksContextDeleteMenuItem.Name = "BookmarksContextDeleteMenuItem";
            BookmarksContextDeleteMenuItem.Size = new Size(134, 22);
            BookmarksContextDeleteMenuItem.Text = "&Delete";
            // 
            // EntryTypeIcons
            // 
            EntryTypeIcons.ColorDepth = ColorDepth.Depth8Bit;
            EntryTypeIcons.ImageStream = (ImageListStreamer)resources.GetObject("EntryTypeIcons.ImageStream");
            EntryTypeIcons.TransparentColor = Color.Transparent;
            EntryTypeIcons.Images.SetKeyName(0, "folder.png");
            EntryTypeIcons.Images.SetKeyName(1, "bookmark.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1085, 628);
            this.Controls.Add(BookmarkEntriesListView);
            this.Controls.Add(MainMenuStrip);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "MainForm";
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            BookmarksListViewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip MainMenuStrip;
        private ListView BookmarkEntriesListView;
        private ColumnHeader TitleColumnHeader;
        private ColumnHeader TagsColumnHeader;
        private ColumnHeader UrlColumnHeader;
        private ToolStripMenuItem FileTopMenu;
        private ToolStripMenuItem FileMenuNewMenuItem;
        private ToolStripMenuItem FileMenuOpenMenuItem;
        private ToolStripMenuItem FileMenuSaveAsMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem FileMenuExitMenuItem;
        private ToolStripMenuItem BookmarksTopMenu;
        private ToolStripMenuItem BookmarksMenuNewMenuItem;
        private ToolStripMenuItem BookmarksMenuNewFolderMenuItem;
        private ToolStripMenuItem BookmarksMenuNewUrlMenuItem;
        private ToolStripMenuItem BookmarksMenuEditMenuItem;
        private ToolStripMenuItem BookmarksMenuDeleteMenuItem;
        private ToolStripMenuItem HelpTopMenu;
        private ToolStripMenuItem HelpMenuGoToRepositoryMenuItem;
        private ToolStripMenuItem HelpMenuAboutMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ImageList EntryTypeIcons;
        private ContextMenuStrip BookmarksListViewContextMenu;
        private ToolStripMenuItem BookmarksContextNewFolderMenuItem;
        private ToolStripMenuItem BookmarksContextNewUrlMenuItem;
        private ToolStripMenuItem BookmarksContextEditMenuItem;
        private ToolStripMenuItem BookmarksContextDeleteMenuItem;
    }
}