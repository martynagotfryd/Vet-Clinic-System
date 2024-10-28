namespace VetClinic.Models;

using System;
using System.Collections.Generic;

[Serializable]
public class Payment
{
    private int _id;
    private string _method;

    private static List<Payment> _payments = new List<Payment>();

    public Payment(int id, string method)
    {
        Id = id;
        Method = method;
        AddPayment(this);
    }

    public int Id
    {
        get => _id;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("ID must be a positive integer.");
            }
            _id = value;
        }
    }

    public string Method
    {
        get => _method;
        set
        {
            string normalizedMethod = value.Trim().ToLower();
            
            if (normalizedMethod != "card" && normalizedMethod != "cash")
            {
                throw new ArgumentException("Method must be either 'card' or 'cash'.");
            }
            _method = value;
        }
    }

    private static void AddPayment(Payment payment)
    {
        if (payment == null)
        {
            throw new ArgumentException("Payment cannot be null.");
        }
        _payments.Add(payment);
    }

    public static List<Payment> GetPayments() => new List<Payment>(_payments);
}