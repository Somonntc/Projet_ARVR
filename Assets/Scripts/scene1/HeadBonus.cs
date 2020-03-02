using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeadBonus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI vie;

    private static LayerMask Player;
    private bool isTogle;
    private Vector3 p;
    private Collider c;
    public Vector3 origine;
    public Vector3 startMarker;
    public Vector3 endMarker;
    private float startTime;
    private float journeyLength;

    void Awake()
    {
        c = gameObject.GetComponent<Collider>();
        Player = LayerMask.NameToLayer("Player");

        isTogle = true;
        Deplacement();
        origine = transform.position;
    }

    void Update()
    {
        float distCovered = (Time.time - startTime);
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);

        if (distCovered > 1.0f)
            Deplacement();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Player)
        {
            vie.SetText("Add Heal + 10");
            Invoke("remove", 2.0f);
            c.isTrigger = false;
        }
    }

    void remove()
    {
        vie.SetText(string.Empty);
        Destroy(gameObject);
    }

    void Deplacement()
    {
        startTime = Time.time;
        startMarker = transform.position;
        if (c.isTrigger)
        {
            isTogle = !isTogle;
            if (isTogle)
                endMarker = origine + new Vector3(0, 0.5f, 0);
            else
                endMarker = origine + new Vector3(0, -0.5f, 0);
        }
        else
        {
            if (!isTogle)
            {
                isTogle = true;
                endMarker = origine + new Vector3(0, -0.5f, 0);
            }
        }
        journeyLength = Vector3.Distance(startMarker, endMarker);

    }


}
