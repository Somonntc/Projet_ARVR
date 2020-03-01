using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ControllerMenu : MonoBehaviour
{

    private List<Person> listofperson = new List<Person>();
    private static Person personInGame;
    [SerializeField] String scene;

    [SerializeField] TextMeshProUGUI loginName;
    [SerializeField] TextMeshProUGUI loginPassword;
    [SerializeField] TextMeshProUGUI loginmsg;

    [SerializeField] TextMeshProUGUI RegisterName;
    [SerializeField] TextMeshProUGUI RegisterPassword;
    [SerializeField] TextMeshProUGUI RegisterNom;
    [SerializeField] TextMeshProUGUI RegisterPrenom;
    [SerializeField] TextMeshProUGUI RegisterEmail;
    [SerializeField] TextMeshProUGUI Registermsg;

    // Start is called before the first frame update
    void Start()
    {
        remove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        foreach (Person p in listofperson){
            string pseudo = loginName.GetParsedText().Trim();
            string password = loginPassword.GetParsedText().Trim();

            if (pseudo.Equals(p.getPseudo()) & password.Equals(p.getPassword()))
            {
                personInGame = p;
                SceneManager.LoadScene(scene);
                Cursor.lockState = CursorLockMode.None;
                loginmsg.SetText("Login Success");
                loginmsg.color = Color.green;
            }
            else
            {
                loginmsg.color = Color.red;
                loginmsg.SetText("Login fail");
            }
        }
    }

    public void Register()
    {
        string pseudo = RegisterPrenom.text;
        string password = RegisterPassword.text;
        string Nom = RegisterNom.text;
        string Prenom = RegisterPrenom.text;
        string Email = RegisterEmail.text;

        if(pseudo != String.Empty & password != String.Empty & Nom != String.Empty & Prenom != String.Empty & Email != String.Empty)
        {
            listofperson.Add(new Person(pseudo, password, Nom, Prenom, Email));
            remove();
            Registermsg.SetText("Register Success");
            Registermsg.color = Color.green;
        }
        else
        {
            Registermsg.color = Color.red;
            Registermsg.SetText("Register fail");
        }
    }

    private void remove()
    {
        RegisterPrenom.text = String.Empty;
        RegisterPassword.text = String.Empty;
        RegisterNom.text = String.Empty;
        RegisterPrenom.text = String.Empty;
        RegisterEmail.text = String.Empty;
    }

}
