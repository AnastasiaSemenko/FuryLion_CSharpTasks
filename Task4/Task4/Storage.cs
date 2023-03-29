using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    /// <summary>
    /// Хранилище данных.
    /// </summary>
    public static class Storage
    {
        /// <summary>
        /// Сохранение объекта в файл
        /// </summary>
        /// <param name="data">Словарь</param>
        /// <param name="filePath">Путь к файлу</param>
        /// <typeparam name="TKey">Ключ</typeparam>
        /// <typeparam name="TValue">Значение</typeparam>
        public static async void Save<TKey, TValue>(Dictionary<TKey, TValue> data, string filePath)
        {
            var bytes = data.GetBytes();
            await using var fstream = new FileStream(filePath, FileMode.Create);
            await fstream.WriteAsync(bytes);
        }

        /// <summary>
        /// Загрузка объекта из файла.
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <typeparam name="TKey">Ключ</typeparam>
        /// <typeparam name="TValue">Значение</typeparam>
        /// <returns>Словарь</returns>
        public static Dictionary<TKey, TValue> Load<TKey, TValue>(string filePath)
        {
            var bytes = File.ReadAllBytes(filePath);
            using var stream = new MemoryStream(bytes);
            var formatter = new BinaryFormatter();
            var result = (Dictionary<TKey, TValue>)formatter.Deserialize(stream);
            return result;
        }
    }

}