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

    [SerializeField] TextMeshProUGUI RegisterName;
    [SerializeField] TextMeshProUGUI RegisterPassword;
    [SerializeField] TextMeshProUGUI RegisterNom;
    [SerializeField] TextMeshProUGUI RegisterPrenom;
    [SerializeField] TextMeshProUGUI RegisterEmail;

    // Start is called before the first frame update
    void Start()
    {
        listofperson.Add(new Person("admin", "admin", "admin", "admin", "admin"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        foreach (Person p in listofperson){
            string pseudo = "admin";
            string password = "admin";

            Debug.Log(pseudo.Equals(p.getPseudo()));
            Debug.Log(password.Equals(p.getPassword()));

            if (pseudo.Equals(p.getPseudo()) & password.Equals(p.getPassword()))
            {
                personInGame = p;
                SceneManager.LoadScene(scene);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void Register()
    {

    }

}
