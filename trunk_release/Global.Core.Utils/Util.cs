using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Notifications.Global.Core.Utils
{
    /// <summary>
    /// Helper functions for message serialization and deserialization.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Serializes an object to a binary representation, returned as a byte array.
        /// </summary>
        /// <param name="Object">The object to serialize.</param>
        public static byte[] Serialize(object Object)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, Object);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deserializes an object from a binary representation.
        /// </summary>
        /// <param name="binaryObject">The byte array to deserialize.</param>
        public static object Deserialize(byte[] binaryObject)
        {
            using (MemoryStream stream = new MemoryStream(binaryObject))
            {
                return new BinaryFormatter().Deserialize(stream);

            }
        }
    }
}
