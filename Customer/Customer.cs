using System;
using System.Collections.Generic;
using System.Text;

namespace Customer
{
    public class Customer : IComparable<Customer>, ICloneable
    {
        private const long idMin = 999999999;
        private const long idMax = 10000000000;

        private string firstName;
        private string lastName;
        private long id;

        public Customer(string firstName, string middleName, string lastName, long id,
            string address, string mobile, string email, List<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = id;
            this.PermanentAddress = address;
            this.Mobile = mobile;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }
        public Customer(string firstName, string lastName, long id, List<Payment> payments, CustomerType customerType)
            : this(firstName, null, lastName, id, null, null, null, payments, customerType)
        {
        }
        public Customer(string firstName, string lastName, long id, Payment payment, CustomerType customerType)
            : this(firstName, null, lastName, id, null, null, null, new List<Payment> { payment }, customerType)
        {
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("firstName", "First name cannot be empty");
                }
                this.firstName = value;
            }
        }
        public string MiddleName { get; set; }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("lastName", "Last name cannot be empty");
                }
                this.lastName = value;
            }
        }
        public long ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (value < idMin || value > idMax)
                {
                    throw new ArgumentOutOfRangeException(string.Format("ID should be in range of {0} to {1}", idMin, idMax));
                }
                this.id = value;
            }
        }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PermanentAddress { get; set; }
        public CustomerType CustomerType { get; set; }
        public List<Payment> Payments { get; set; }

        public void AddPayment(Payment newPayment)
        {
            this.Payments.Add(newPayment);
        }
        public override bool Equals(object obj)
        {
            Customer secondCustomer = (Customer)obj;
            if (this.ID == secondCustomer.ID)
            {
                return true;
            }
            return false;
        }
        public static bool operator ==(Customer thisCustomer, Customer otherCustomer)
        {
            return thisCustomer.Equals(otherCustomer);
        }
        public static bool operator !=(Customer thisCustomer, Customer otherCustomer)
        {
            return thisCustomer.Equals(otherCustomer);
        }
        public override int GetHashCode()
        {

            return this.FirstName.GetHashCode()^this.LastName.GetHashCode()^this.ID.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("Customer Name: {0} {1} {2}", this.firstName, this.MiddleName ?? "", this.lastName));
            output.AppendLine(string.Format("Customer ID: {0}", this.id));
            if (this.PermanentAddress != null)
            {
                output.AppendLine(string.Format("Permanent Address: {0}", this.PermanentAddress));
            }
            if (this.Email != null)
            {
                output.AppendLine(string.Format("E-mail: {0}", this.Email));
            }
            if (this.Mobile != null)
            {
                output.AppendLine(string.Format("Mobile Phone: {0}", this.Mobile));
            }
            foreach (Payment payment in this.Payments)
            {
                output.AppendLine(payment.ToString());
            }
            output.Append(string.Format("Customer Type: {0}", this.CustomerType.ToString()));
            return output.ToString();
        }

        public int CompareTo(Customer other)
        {
            string thisCustomerFullName = string.Format("{0} {1} {2}", this.FirstName, this.MiddleName ?? "", this.LastName);
            string otherCustomerFullName = string.Format("{0} {1} {2}", other.FirstName, other.MiddleName ?? "", other.LastName);
            if (thisCustomerFullName == otherCustomerFullName)
            {
                return this.ID.CompareTo(other.ID);
            }
            return thisCustomerFullName.CompareTo(otherCustomerFullName);
        }

        public object Clone()
        {
            List<Payment> clonePayments = new List<Payment>();
            foreach (Payment payment in this.Payments)
            {
                clonePayments.Add(payment);
            }
            Customer cloneCustomer = new Customer(
                this.firstName,
                this.MiddleName,
                this.LastName,
                this.ID,
                this.PermanentAddress,
                this.Mobile,
                this.Email,
                clonePayments,
                this.CustomerType);
            return cloneCustomer;
        }
    }
}
