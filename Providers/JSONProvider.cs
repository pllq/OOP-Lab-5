using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Providers
{
    public class JSONProvider<T> : IDataProvider<T>
    {
        public string FileType { get { return ".json"; } }
        public T Read(string connection)
        {
            T data;
            using (FileStream fs = new FileStream(connection, FileMode.Open))
            {
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
                try
                {
                    data = (T)formatter.ReadObject(fs);
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
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T), types);
                try
                {
                    data = (T)formatter.ReadObject(fs);
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
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
                try
                {
                    formatter.WriteObject(fs, data);
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
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T), types);
                try
                {
                    formatter.WriteObject(fs, data);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
    }
}
