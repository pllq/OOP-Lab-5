using System;
using System.IO;
using System.Xml.Serialization;

namespace Providers
{
    public class XMLProvider<T> : IDataProvider<T>
    {
        public string FileType { get { return ".xml"; } }
        public T Read(string connection)
        {
            T data;
            using (FileStream fs = new FileStream(connection, FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                try
                {
                    data = (T)formatter.Deserialize(fs);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return data;
        }
        public T Read(string connection, Type[] types)
        {
            T data;
            using (FileStream fs = new FileStream(connection, FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T), types);
                try
                {
                    data = (T)formatter.Deserialize(fs);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return data;
        }
        public void Write(T data, string connection)
        {
            using (FileStream fs = new FileStream(connection, FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(data.GetType());
                try
                {
                    formatter.Serialize(fs, data);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
        public void Write(T data, string connection, Type[] types)
        {
            using (FileStream fs = new FileStream(connection, FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T), types);
                try
                {
                    formatter.Serialize(fs, data);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
    }
}
