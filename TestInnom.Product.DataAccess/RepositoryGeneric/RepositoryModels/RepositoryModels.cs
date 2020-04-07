
using System;

namespace TestInnom.Product.DataAccess.DAL
{
    public interface IModifiedOn
    {
        DateTime ModifiedOn { get; set; }
    }
    public interface ICreatedOn
    {
        DateTime CreatedOn { get; set; }
    }

    public interface IIdentifier
    {
        int ID { get; set; }
    }
}
