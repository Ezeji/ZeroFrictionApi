using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFriction.Core.Common
{
    public static class OperationErrorDictionary
    {
        public static class Customer
        {
            public static OperationError CustomerIsNull() =>
               new OperationError("Supplied customer or id is null.");

            public static OperationError CustomerNotFound() =>
               new OperationError("The requested customer was not found. Verify that the supplied Id is correct.");
        }

        public static class Invoice
        {
            public static OperationError InvoiceIsNull() =>
               new OperationError("Supplied invoice or id is null.");

            public static OperationError InvoiceNotFound() =>
               new OperationError("The requested invoice was not found. Verify that the supplied Id is correct.");
        }
    }
}
