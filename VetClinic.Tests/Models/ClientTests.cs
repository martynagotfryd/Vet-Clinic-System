using VetClinic.Models;

namespace VetClinic.Tests.Models;

public class ClientTests
{
    [Test]
    public void Client_Constructor_Valid()
    {
        var name = "John";
        var surname = "Doe";
        var contact = "123456789";
        
        var client = new Client(name, surname, contact);

        Assert.AreEqual(name, client.Name);
        Assert.AreEqual(surname, client.Surname);
        Assert.AreEqual(contact, client.Contact);
        Assert.Contains(client, Client.GetClients());
    }
    
    [Test]
    public void Name_Get()
    {
        // Arrange
        string name = "John";
        var client = new Client(name, "Doe", "123456789");

        // Act
        var result = client.Name;

        // Assert
        Assert.AreEqual(name, result);
    }
    [Test]
    public void Surname_Get()
    {
        // Arrange
        string surname = "Doe";
        var client = new Client("John", surname, "123456789");

        // Act
        var result = client.Surname;

        // Assert
        Assert.AreEqual(surname, result);
    }
    [Test]
    public void Contact_Get()
    {
        // Arrange
        string contact = "123456789";
        var client = new Client("John", "Doe", contact);

        // Act
        var result = client.Contact;

        // Assert
        Assert.AreEqual(contact, result);
    }
    
    [Test]
    public void Name_Set_Valid()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act
        client.Name = "Jane";

        // Assert
        Assert.AreEqual("Jane", client.Name);
    }
    [Test]
    public void Surname_Set_Valid()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act
        client.Surname = "Smith";

        // Assert
        Assert.AreEqual("Smith", client.Surname);
    }
    [Test]
    public void Contact_Set_Valid()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act
        client.Contact = "987654321";

        // Assert
        Assert.AreEqual("987654321", client.Contact);
    }
    [Test]
    public void Name_Set_Null()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => client.Name = null);
        Assert.AreEqual("Name cannot be null or empty.", ex.Message);
    }
    [Test]
    public void Name_Set_Empty()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => client.Name = "");
        Assert.AreEqual("Name cannot be null or empty.", ex.Message);
    }
    [Test]
    public void Surname_Set_Null()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => client.Surname = null);
        Assert.AreEqual("Surname cannot be null or empty.", ex.Message);
    }
    [Test]
    public void Surname_Set_Empty()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => client.Surname = "");
        Assert.AreEqual("Surname cannot be null or empty.", ex.Message);
    }
    [Test]
    public void Contact_Set_Null()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => client.Contact = null);
        Assert.AreEqual("Contact cannot be null or empty.", ex.Message);
    }
    [Test]
    public void Contact_Set_Empty()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => client.Contact = "");
        Assert.AreEqual("Contact cannot be null or empty.", ex.Message);
    }
    [Test]
    public void Contact_Set_Invalid()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => client.Contact = "abcdefghi");
        Assert.AreEqual("Phone number is in an invalid format.", ex.Message);
    }
    
    [Test]
    public void AddClientToExtent()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");

        // Act
        var clients = Client.GetClients();

        // Assert
        Assert.Contains(client, clients);
    }
    [Test]
    public void EditExtend()
    {
        // Arrange
        var client = new Client("John", "Doe", "123456789");
        var clients = Client.GetClients();

        // Act
        client.Name = "Jane";  // Modify the instance directly

        // Assert
        Assert.AreEqual("Jane", client.Name);             // Change in the instance
        Assert.AreEqual("John", clients[0].Name);         // Original value in the extent
    }
}