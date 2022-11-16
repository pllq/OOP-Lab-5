using System;
using Providers;

namespace DAL
{
    public class EntityContext<T> : IEntityContext<T>
    {
        private T storedData;
        private string connection;
        public string Connection { get { return this.connection; } set { this.connection = value + this.DataProvider.FileType; } }
        public IDataProvider<T> DataProvider { get; set; }
        public bool AreTypesNeeded { get; set; }
        public Type[] Types { get; set; }
        public EntityContext(string connection, IDataProvider<T> provider)
        {
            if (connection != null)
            {
                this.DataProvider = provider;
                this.Connection = connection;
                this.AreTypesNeeded = false;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public EntityContext(string connection, IDataProvider<T> provider, Type[] types)
        {
            if (types != null)
            {
                if (connection != null)
                {
                    this.DataProvider = provider;
                    this.Connection = connection;
                    this.Types = types;
                    this.AreTypesNeeded = true;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public T GetData()
        {
            if (this.DataProvider != null)
            {
                if (this.storedData != null)
                {
                    return this.storedData;
                }
                else
                {
                    try
                    {
                        if (this.AreTypesNeeded)
                        {
                            if (this.Types != null)
                            {
                                this.storedData = this.DataProvider.Read(this.Connection, this.Types);
                            }
                            else
                            {
                                throw new NullReferenceException();
                            }
                        }
                        else
                        {
                            this.storedData = this.DataProvider.Read(this.Connection);
                        }
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                    return storedData;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public void SetData(T data)
        {
            if (data == null)
            {
                this.storedData = default(T);
            }
            else
            {
                if (this.DataProvider != null)
                {
                    if (this.AreTypesNeeded)
                    {
                        if (this.Types != null)
                        {
                            this.DataProvider.Write(data, this.Connection, this.Types);
                            this.storedData = data;
                        }
                        else
                        {
                            throw new NullReferenceException();
                        }
                    }
                    else
                    {
                        this.DataProvider.Write(data, this.Connection);
                        this.storedData = data;
                    }
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }
    }
}
