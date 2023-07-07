using Safemark.Core;

namespace Safemark.Models;

public class BookmarkEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid? ParentId { get; set; }

    public BookmarkEntryType EntryType { get; set; }

    public string? Title { get; set; }

    public string[]? Tags { get; set; }

    public Uri? Uri { get; set; }
}