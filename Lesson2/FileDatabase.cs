using System;
using System.IO;
using Newtonsoft.Json;

namespace Lesson2
{
	public class FileDatabase
	{
		public FileDatabase(string catalogPath)
		{
			if (string.IsNullOrEmpty(catalogPath))
			{
				throw new ArgumentException("Catalog path is null or empty");
			}

			_databaseDirectory = new DirectoryInfo(catalogPath);
			if (!_databaseDirectory.Exists)
			{
				_databaseDirectory.Create();
			}
		}

		public void SaveToDatabase<T>(T[] entities)
		{
			var path = GetRepositoryFilePath(typeof (T));
			var serializedData = SerializeEntity(entities);
			WriteSerializedDataToFile(path, serializedData);
		}

		public T[] GetFromDatabase<T>()
		{
			var path = GetRepositoryFilePath(typeof (T));
			var serializedData = ReadSerializedDataFromFile(path);
			return serializedData == null ? new T[0] : DeserializeEntity<T[]>(serializedData);
		}

		private string GetRepositoryFilePath(Type type) 
		{
			var fileName = type.Name + FileFormat;
			return Path.Combine(_databaseDirectory.FullName, fileName);
		}

		private static void WriteSerializedDataToFile(string path, string serializedData)
		{
			File.WriteAllText(path, serializedData);
		}

		private static string ReadSerializedDataFromFile(string path)
		{
			try
			{
				return File.ReadAllText(path);
			}
			catch (FileNotFoundException)
			{
				return null;
			}
		}

		private static string SerializeEntity<T>(T entity)
		{
			return JsonConvert.SerializeObject(entity, Formatting.Indented);
		}

		private static T DeserializeEntity<T>(string serializedEntity)
		{
			return JsonConvert.DeserializeObject<T>(serializedEntity);
		}

		private readonly DirectoryInfo _databaseDirectory;
		private const string FileFormat = ".fdb";
	}
}
