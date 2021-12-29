using System.Collections.Generic;
using API.MongoData.Model;

namespace API.Modules.App.Customer.Logos.Interfaces
{
    public interface ILogoConfig
    {
        LogoConfig Create(LogoConfig sampleCustomer);
        LogoConfig FindById(string mongoId);
        IList<LogoConfig> Read();
        void Update(LogoConfig sampleCustomer);
        void Delete(string mongoDb);
    }
}