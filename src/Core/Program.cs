using Safemark.Forms;

namespace Safemark.Core;

internal static class Program
{
    /// <summary>
    /// GitHub repository URL.
    /// </summary>
    public const string GitHubRepositoryUrl = "https://github.com/nagilum/safemark";

    /// <summary>
    /// Program name and version.
    /// </summary>
    public const string ProgramNameAndVersion = "Safemark v0.1-beta";

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    [STAThread]
    private static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(GetFilePath(args)));
    }

    /// <summary>
    /// Figures out if there is a file path to open.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    /// <returns>Possible file path.</returns>
    private static string? GetFilePath(string[] args)
    {
        if (args.Length == 1 &&
            File.Exists(args[0]))
        {
            return args[0];
        }

        if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LastOpenedFile) &&
            File.Exists(Properties.Settings.Default.LastOpenedFile))
        {
            return Properties.Settings.Default.LastOpenedFile;
        }

        return null;
    }
}