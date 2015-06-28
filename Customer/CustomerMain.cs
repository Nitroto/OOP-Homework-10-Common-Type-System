using System;

namespace Customer
{
    public class CustomerMain
    {
        static void Main()
        {
            Payment pay = new Payment("Beer", 0.5M);
            Customer customer = new Customer("Patar", "Ivanov", 1000000000, pay, CustomerType.OneTime);
            Console.WriteLine(customer);
            Console.WriteLine();
            Customer clone = (Customer)customer.Clone();
            clone.AddPayment(new Payment("Rakia", 8M));
            Console.WriteLine(clone);
            Console.WriteLine();
            Console.WriteLine(customer);
            Console.WriteLine();
            Console.WriteLine(customer.GetHashCode());
            Console.WriteLine(clone.GetHashCode());
        }
    }
}
