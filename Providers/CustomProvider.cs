using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Providers
{
    public class CustomProvider<T> : IDataProvider<T>
    {
        public string FileType { get { return ".custom"; } }
        public T Read(string connection)
        {
            T data;
            using (FileStream fs = new FileStream(connection, FileMode.Open))
            {
                IFormatter formatter = new BinaryFormatter();
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
            return this.Read(connection);
        }
        public void Write(T data, string connection)
        {
            using (FileStream fs = new FileStream(connection, FileMode.OpenOrCreate))
            {
                IFormatter formatter = new BinaryFormatter();
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
            this.Write(data, connection);
        }
    }
}
