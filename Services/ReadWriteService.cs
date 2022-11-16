using System;
using System.Collections.Generic;
using Adapter;
using DAL;
using Providers;

namespace Services
{
    public class ReadWriteService: IReadWriteService<List<BLL.Human>>
    {
        private IEntityContext<List<DAL.Human>> context;
        public string File { set { this.context.Connection = value; } get { return this.context.Connection; } }
        public ReadWriteService(string path, EProviders _provider) 
        {
            this.context = new EntityContext<List<DAL.Human>>(path, this.ConvertEProvider(_provider), new Type[] { typeof(DAL.Student), typeof(DAL.Painter), typeof(DAL.Farmer) });
        }
        public List<BLL.Human> ReadData()
        {
            ConvertService obj = new ConvertService();
            return (List<BLL.Human>)obj.Convert(this.context.GetData());
        }
        public void WriteData(List<BLL.Human> data)
        {
            ConvertService obj = new ConvertService();
            this.context.SetData((List<DAL.Human>)obj.Convert(data));
        }
        private IDataProvider<List<DAL.Human>> ConvertEProvider(EProviders value)
        {
            if (value == EProviders.Bin)
            {
                return new BinaryProvider<List<DAL.Human>>();
            }
            else if (value == EProviders.Xml)
            {
                return new XMLProvider<List<DAL.Human>>();
            }
            else if (value == EProviders.Custom)
            {
                return new CustomProvider<List<DAL.Human>>();
            }
            else
            {
                return new JSONProvider<List<DAL.Human>>();
            }
        }
    }
}
