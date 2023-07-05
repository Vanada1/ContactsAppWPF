using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace ContactsApp;

/// <summary>
/// Class for working with files
/// </summary>
public static class ProjectManager
{
    /// <summary>
    /// File name
    /// </summary>
    private const string _fileName = "ContactsApp.notes";

    /// <summary>
    /// Folder for file
    /// </summary>
    private static readonly string _folder = Environment.GetFolderPath(
                                                 Environment.SpecialFolder.ApplicationData)
                                             + "\\ContactsApp\\";

    /// <summary>
    /// The folder to the file
    /// </summary>
    private static readonly string _path = _folder + _fileName;

    /// <summary>
    /// Default path for save and read of the file
    /// </summary>
    public static string DefaultPath { get; set; } = _path;

    /// <summary>
    /// Read file along the folder
    /// </summary>
    /// <param name="path">
    /// Path to the file.
    /// If <paramref name="path"/> is Null then take default value
    /// </param>
    /// <returns>
    /// Returns all data from file
    /// </returns>
    public static Project ReadProject()
    {
        var project = new Project();
        if (!File.Exists(DefaultPath))
        {
            return project;
        }

        try
        {
            using (var file = new StreamReader(DefaultPath, Encoding.Default))
            {
                var projectText = file.ReadLine();
                if (!string.IsNullOrEmpty(projectText))
                {
                    project = JsonConvert.DeserializeObject<Project>(projectText);
                }
            }
        }
        catch (SerializationException)
        {
            return project;
        }

        return project;
    }

    /// <summary>
    /// Save file
    /// </summary>
    /// <param name="project">
    /// All data of app
    /// </param>
    /// <param name="path">
    /// Path to the file.
    /// If <paramref name="path"/> is Null then take defult value
    /// </param>
    public static void SaveProject(Project project)
    {
        if (!File.Exists(DefaultPath))
        {
            CreatePath(_folder, _fileName);
        }

        using (var file = new StreamWriter(DefaultPath, false, Encoding.UTF8))
        {
            file.Write(JsonConvert.SerializeObject(project));
        }
    }

    /// <summary>
    /// Creates file along folder
    /// </summary>
    /// <param name="folder"> File location </param>
    /// <param name="fileName"> File name </param>
    public static void CreatePath(string folder, string fileName)
    {
        if (string.IsNullOrEmpty(folder) || string.IsNullOrWhiteSpace(folder))
        {
            folder = _folder;
        }

        if (string.IsNullOrEmpty(fileName) || string.IsNullOrWhiteSpace(fileName))
        {
            fileName = _fileName;
        }

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        if (!File.Exists(folder + fileName))
        {
            File.Create(folder + fileName).Close();
        }

        DefaultPath = folder + fileName;
    }
}