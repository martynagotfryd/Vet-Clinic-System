namespace VetClinic.Models;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

[Serializable]
public class Client
{
    private string _name;
    private string _surname;
    private string _contact;
    private static List<Client> _clients = new List<Client>();
    
    public Client(string name, string surname, string contact)
    {
        Name = name;
        Surname = surname;
        Contact = contact;
        AddClient(this);
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            _name = value;
        }
    }
    public string Surname
    {
        get => _surname;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Surname cannot be null or empty.");
            }
            _surname = value;
        }
    }
    public string Contact
    {
        get => _contact;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Contact cannot be null or empty.");
            }

            if (!Regex.IsMatch(value, @"^\d{9}$"))
            {
                throw new ArgumentException("Phone number is in an invalid format.");
            }
            
            _contact = value;
        }
    }
    private static void AddClient(Client client)
    {
        if (client == null)
        {
            throw new ArgumentException("Client cannot be null");
        }
        _clients.Add(client);
    }

    public static List<Client> GetClients() => new List<Client>(_clients);
}