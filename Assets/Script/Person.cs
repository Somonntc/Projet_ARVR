using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person 
{

    private string pseudo;
    private string password;
    private string Nom;
    private string Prenom;
    private string Email;

    public Person(string pseudo,string password,string Nom, string Prenom, string Email)
    {
        this.pseudo = pseudo;
        this.password = password;
        this.Nom = Nom;
        this.Prenom = Prenom;
        this.Email = Email;
    }

    public string getPseudo()
    {
        return pseudo;
    }

    public string getPassword()
    {
        return password;
    }
}
