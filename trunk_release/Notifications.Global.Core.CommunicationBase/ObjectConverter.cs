using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Linq;
using System.Text;

namespace Notifications.Global.Core.Communication.Base
{
    /// <summary>
    /// Used to convert 'Classes' To and from JSON
    /// Make sure to correctly mark Serializable Properties.
    /// 
    /// JSON is used to transport requests/responses to and from the server.
    /// </summary>
    static public class ObjectConverter
    {
        /// <summary>
        /// Converts a Structure/Object into a JSON String Representing it.
        /// </summary>
        /// <typeparam name="t">The Class (not Object) that will be converted to JSON</typeparam>
        /// <param name="Structure">The Object that will be converted to JSON</param>
        /// <returns>A JSON String Representing the Structure</returns>
        public static string ToJSON<t>(t Structure)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(t));
            ser.WriteObject(ms, Structure);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            return sr.ReadToEnd() ;
        }

        /// <summary>
        /// Converts A JSON Object into a Structure
        /// </summary>
        /// <typeparam name="t">The Class That the JSON Object Represents</typeparam>
        /// <param name="JSON">The JSON String that represents the Object</param>
        /// <returns>Returns an Object of Type t.</returns>
        public static t ToObject<t>(String JSON)
        {
            MemoryStream ms = new MemoryStream();
            UTF8Encoding encoding = new UTF8Encoding();
            ms.Write(encoding.GetBytes(JSON), 0 , encoding.GetBytes(JSON).Count());
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(t));

            return (t)ser.ReadObject(sr.BaseStream);
        }
        /// <summary>
        /// Converts a Stream Object to a Structure
        /// </summary>
        /// <typeparam name="t">The Class That the Object in the Stream represents</typeparam>
        /// <param name="stream">The stream that contains the object</param>
        /// <returns>Returns an Object of Type t</returns>
        public static t ToObject<t>(Stream stream)
        {
            StreamReader sr = new StreamReader(stream);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(t));

            return (t)ser.ReadObject(sr.BaseStream);
        }

    }
}
