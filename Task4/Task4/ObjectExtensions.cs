// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    /// <summary>
    /// Расширение для object.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Получение байтового представления объекта.
        /// </summary>
        /// <returns>Байтовое представление объекта</returns>
        public static byte[] GetBytes(this object data)
        {
            var bf = new BinaryFormatter();
            using var ms = new MemoryStream();
            bf.Serialize(ms, data);
            return ms.ToArray();
        }
    }
}