using System;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using ContactsAppBL;
using NUnit.Framework.Internal;
using Newtonsoft.Json;

namespace ContactsApp.UnitTests
{
    [TestFixture]
	public class ProjectManagerTests
	{
		/// <summary>
		/// File name for tests
		/// </summary>
		private static readonly string _fileName = "TestFile.txt";

		/// <summary>
		/// Folder for tests
		/// </summary>
		private static readonly string _folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\";

		/// <summary>
		/// All path for tests
		/// </summary>
		private static readonly string _path = _folder + _fileName;

		/// <summary>
		/// Reference path file for tests
		/// </summary>
		private static readonly string _referencePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\Reference.txt";
        
        /// <summary>
        /// Reference path broken file for tests
        /// </summary>
        private static readonly string _referenceBrokenPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\ReferenceBroken.txt";

		private static readonly string _nonexistentFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TestData\NonexistentFile.txt";

		[TearDown]
		public void DeleteFile()
		{
			if (File.Exists(_path))
			{
				File.Delete(_path);
			}
		}

		[Test(Description = "Read correct file")]
		public void TestReadProject_CorrectData()
		{
			ProjectManager.DefaultPath = _path;
			var expectedString = File.ReadAllText(_referencePath);
			var expected = JsonConvert.DeserializeObject<Project>(
				expectedString);
			if (File.Exists(_path))
			{
				File.Delete(_path);
			}
			File.Create(_path).Close();
			File.WriteAllText(_path, expectedString);
			if (File.Exists(_path))
			{
				var actual = ProjectManager.ReadProject();
				var actualString = File.ReadAllText(_path);
				Assert.AreEqual(expectedString, actualString,
					"Values are not the same");
			}
		}

		[Test(Description = "Read broken  file")]
		public void TestReadProject_BrokenData()
		{
			Assert.Throws<JsonReaderException>(() =>
				{
					ProjectManager.DefaultPath = _referenceBrokenPath;
					var project = ProjectManager.ReadProject();
				},
				"Can read the file");
		}

		[Test(Description = "Try to read nonexistent file")]
		public void TestReadProject_NonexistentFile()
		{
			var expected = JsonConvert.SerializeObject(new Project());

			ProjectManager.DefaultPath = _nonexistentFile;
			var actual = JsonConvert.SerializeObject(
				ProjectManager.ReadProject());

			Assert.AreEqual(expected, actual,
				"Actual project is existent");
		}

		[Test(Description = "Test to write in the file")]
		public void TestSaveProject_WithCreatedFile()
		{

			ProjectManager.DefaultPath = _path;
			if (File.Exists(_path))
			{
				File.Delete(_path);
			}
			File.Create(_path).Close();
			var expectedString = File.ReadAllText(_referencePath);
			var expected = JsonConvert.DeserializeObject<Project>(
				expectedString);
			ProjectManager.SaveProject(expected);
			if (File.Exists(_path))
			{
				var actualString = File.ReadAllText(_path);
				var actual = JsonConvert.DeserializeObject<Project>(
				actualString);
				Assert.AreEqual(expectedString, actualString,
					"Values are not the same");
			}
		}

		[Test(Description = "Test to write in the file without file")]
		public void TestSaveProject_WithoutCreatedFile()
		{

			ProjectManager.DefaultPath = _path;
			if (File.Exists(_path))
			{
				File.Delete(_path);
			}
			var expectedString = File.ReadAllText(_referencePath);
			var expected = JsonConvert.DeserializeObject<Project>(
				expectedString);
			ProjectManager.SaveProject(expected);
			if (File.Exists(ProjectManager.DefaultPath))
			{
				var actualString = File.ReadAllText(
					ProjectManager.DefaultPath);
				var actual = JsonConvert.DeserializeObject<Project>(
				actualString);
				Assert.AreEqual(expectedString, actualString,
					"Values are not the same");
			}
		}
	}
}