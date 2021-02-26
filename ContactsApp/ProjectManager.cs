using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ContactsAppBL
{
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
				Environment.SpecialFolder.ApplicationData) +
			"\\ContactsApp\\";

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
		/// <param name="path">Path to the file.
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
	            using (StreamReader file = new StreamReader(
		            DefaultPath, System.Text.Encoding.Default))
	            {
		            var projectText = file.ReadLine();
		            if (string.IsNullOrEmpty(projectText))
		            {
			            projectText = null;
		            }

		            project = JsonConvert.DeserializeObject<Project>(projectText);
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
		/// <param name="path">Path to the file.
		/// If <paramref name="path"/> is Null then take defult value
		/// </param>
		public static void SaveProject(Project project)
        {
			if(!File.Exists(DefaultPath))
			{
				CreatePath(_folder, _fileName);
			}

			using (StreamWriter file = new StreamWriter(
				DefaultPath, false, System.Text.Encoding.UTF8))
			{
                file.Write(JsonConvert.SerializeObject(project));
			}
        }

        /// <summary>
        /// Creates file along folder
        /// </summary>
        /// <param name="folder">File location</param>
        /// <param name="fileName">File name</param>
        public static void CreatePath(string folder, string fileName)
		{
			if (folder == null)
			{
				folder = _folder;
			}
			if (fileName == null)
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
}
