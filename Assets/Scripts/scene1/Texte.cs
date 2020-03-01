using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Texte")]

public class Texte : ScriptableObject
{
    [SerializeField] private List<string> start = default;

    public List<string> StartText => start;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
