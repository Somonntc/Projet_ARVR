using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{

    private List<Person> listofperson = new List<Person>();
    private static Person personInGame;
    [SerializeField] string scene;

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
        personInGame = null;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
                loginmsg.SetText("Login Success");
                loginmsg.color = Color.green;
            }
        }
        if (personInGame == null)
        {
            loginmsg.color = Color.red;
            loginmsg.SetText("Login fail");
        }
    }

    public void Register()
    {
        string pseudo = RegisterPrenom.text;
        string password = RegisterPassword.text;
        string Nom = RegisterNom.text;
        string Prenom = RegisterPrenom.text;
        string Email = RegisterEmail.text;

        if(pseudo != string.Empty & password != string.Empty & Nom != string.Empty & Prenom != string.Empty & Email != string.Empty)
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
        RegisterPrenom.SetText(string.Empty);
        RegisterPassword.SetText(string.Empty);
        RegisterNom.SetText(string.Empty);
        RegisterPrenom.SetText(string.Empty);
        RegisterEmail.SetText(string.Empty);
    }

}
