using System.Collections.Generic;
using API.MongoData.Model;

namespace API.SampleCustomers.Interfaces
{
    public interface ISampleCustomers
    {
        #region SampleCustomers

        SampleCustomer Create(SampleCustomer sampleCustomer);
        SampleCustomer FindById(string mongoId);
        IList<SampleCustomer> Read();
        void Update(SampleCustomer sampleCustomer);
        void Delete(string mongoDb);

        #endregion
    }
}