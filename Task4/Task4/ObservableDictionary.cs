// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Collections;

namespace Task4
{
    /// <summary>
    /// Класс вызывающий события при добавлении и удалении объектов из коллекции.
    /// </summary>
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Путь к файлу для хранения данных
        /// </summary>
        private string _filePath;

        /// <summary>
        /// Делегат сохранения данных
        /// </summary>
        public delegate void DataSaver(Dictionary<TKey, TValue> data, string filePath);

        /// <summary>
        /// Событие сохранения данных
        /// </summary>
        public event DataSaver DataChanged;

        /// <summary>
        /// Количество данных в словаре
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Возможность только чтения
        /// </summary>
        public bool IsReadOnly { get; }

        /// <summary>
        /// Коллекция ключей словаря
        /// </summary>
        public ICollection<TKey> Keys { get; }
        
        /// <summary>
        /// Коллекция значений словаря
        /// </summary>
        public ICollection<TValue> Values { get; }
        
        /// <summary>
        /// Полчение занчения по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        public TValue this[TKey key]
        {
            get => _dictionary[key];
            set => this[key] = value;
        }
        
        /// <summary>
        /// словарь для хранения данных
        /// </summary>
        private Dictionary<TKey, TValue> _dictionary = new();

        /// <summary>
        /// Метод для инициализации словаря
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void InitDictionary(string filePath)
        {
            _filePath = filePath;
            
            if (File.ReadAllLines(filePath).Length != 0)
                _dictionary = Storage.Load<TKey, TValue>(filePath);
        }

        /// <summary>
        /// Добавляет указанные ключ и значение в словарь и обновляет его
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
            DataChanged(_dictionary, _filePath);
        }

        /// <summary>
        /// Определяет, содержится ли указанный ключ в словаре
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Наличие ключа</returns>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Удаляет значение с указанным ключом из словаря и обновляет словарь
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Факт удаления</returns>
        public bool Remove(TKey key)
        {
            var remove = _dictionary.Remove(key);
            DataChanged(_dictionary, _filePath);
            return remove;
        }

        /// <summary>
        /// Возвращает перечислитель, осуществляющий перебор элементов списка
        /// </summary>
        /// <returns>Перечислитель</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        /// <summary>
        /// Возвращает перечислитель, осуществляющий перебор элементов списка
        /// </summary>
        /// <returns>Перечислитель</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Добавляет указанные ключ и значение в словарь
        /// </summary>
        /// <param name="item">Связка ключ/значение</param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _dictionary.Add(item.Key, item.Value);
        }

        /// <summary>
        /// Удаляет все ключи и значения из словаря
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Определяет, содержит ли коллекция указанное значение
        /// </summary>
        /// <param name="item">Связка ключ/значение</param>
        /// <returns>Наличие значения</returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Contains(item);
        }

        /// <summary>
        /// Копирует значения из массива
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="arrayIndex">С какого индекса начинать копирование</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаляет значение из словаря
        /// </summary>
        /// <param name="item">Связка ключ/значение</param>
        /// <returns>Факт удаления</returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Remove(item.Key);
        }

        /// <summary>
        /// Получает значение, связанное с заданным ключом.
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        /// <returns>Факт получения значения</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }
    }
}