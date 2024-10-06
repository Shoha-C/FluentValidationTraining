using System.ComponentModel.DataAnnotations;

namespace FluentValidationTraining.Models;

public class CreateUserModel
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    public string Username { get; set; }

    public string Bio { get; set; }

    public Adress? Adress { get; set; } 

    public byte Age { get; set; }


    public List<Contact>? Contacts { get; set; }
}


public class Contact()
{
    public string Number { get; set; }
    public string Relation { get; set; }
    public string Name { get; set; }
}    


public class Adress
{
    public int ZipCode { get; set; }
    public string City { get; set; }
    public string Region { get; set; }

    public string Country { get; set; }
}