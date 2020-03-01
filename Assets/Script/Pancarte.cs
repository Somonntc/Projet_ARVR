using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pancarte : MonoBehaviour
{
    [SerializeField] private Texte text = default;
    [SerializeField] private TextMeshProUGUI textMeshProStart = default;
    private bool isTogle = false;
    private bool end = true;
    private int a = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTogle && end)
        {
            StartCoroutine(Apparition());
        }
    }

    public void go()
    {
        isTogle = !isTogle; 
    }

    public IEnumerator Apparition()
    {
        end = false;
        textMeshProStart.text = text.StartText[a];
        for (int i = 0; i < 100; i++)
        {
           textMeshProStart.alpha = (float) i / 100;    
           yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        if (isTogle)
        {
            if (a < text.StartText.Capacity-1)
            {
                a++;
                StartCoroutine(Apparition());
            }
            else
            {
                end = true;
                isTogle = false;
                a = 0;
            }   
        }
        end = true;
    }


}
