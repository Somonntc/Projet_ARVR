using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ControllerMur : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameover;
    [SerializeField] private Image image;
    private static LayerMask Player;
    private Collider c;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    private bool isToogle;
    // Start is called before the first frame update
    public Vector3 origine;
    public Vector3 startMarker;
    public Vector3 endMarker;
    private float startTime;
    private float journeyLength;

    void Awake()
    {
        c = gameObject.GetComponent<Collider>();
        Player = LayerMask.NameToLayer("Player");
        origine = transform.position;
        isToogle = false;
        Deplacement();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime)*1.5f;
        if (distCovered < 4.5f)
        {
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
        }
        else if (distCovered > 18.0f)
            Deplacement();
    }

    void Deplacement()
    {
        startTime = Time.time;
        startMarker = transform.position;
        isToogle = !isToogle;
        if (isToogle)
            endMarker = origine + new Vector3(x, y, z);
        else
            endMarker = origine;
        journeyLength = Vector3.Distance(startMarker, endMarker);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Player)
        {
            other.GetComponent<FirstPersonController>().enabled = false;
            image.enabled = true;
            gameover.enabled = true;

            Invoke("remove", 2.0f);
        }
    }

    public void remove()
    {
        SceneManager.LoadScene("Menu");
    }



}
