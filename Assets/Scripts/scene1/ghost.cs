using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ghost : MonoBehaviour
{
    private static LayerMask Player;

    private GameObject spawner = default;
    private Transform transformPlayer = default;
    private bool invisiblePlayer = true;
    public bool isToggled = false;

    private new Animation animation = default;
    private new Rigidbody rigidbody = default;
    private float time = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        Player = LayerMask.NameToLayer("Player");
        animation = GetComponent<Animation>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        animation["mixamo.com"].speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isToggled && invisiblePlayer)
        {
            animation["mixamo.com"].speed = 1f;
            Vector3 currentPosition = transform.position;
            rigidbody.MovePosition(Vector3.MoveTowards(transform.position, transformPlayer.position, Time.deltaTime));
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, transformPlayer.position - transform.position, Time.deltaTime, 0.0f);
            Quaternion rotationOnlyY = Quaternion.LookRotation(newDirection);
            rotationOnlyY.z = 0;
            rotationOnlyY.x = 0;
            rigidbody.MoveRotation(rotationOnlyY);
            time = 0;
        }
        else
        {
            animation["mixamo.com"].speed = 0;
            time += Time.deltaTime;
            Debug.Log(time);
            if(time > 180)
            {
                spawner.GetComponent<ControllerSpawn>().isToggled = true;
                Destroy(gameObject);
            }
        }
    }

    public void set(GameObject Player,GameObject spawner)
    {
        this.invisiblePlayer = Player.GetComponentInParent<ControllerPlayer>().invisible;
        this.transformPlayer = Player.transform;
        this.spawner = spawner;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Player && invisiblePlayer)
        {
            Debug.Log("mort");
            SceneManager.LoadScene("Menu");
            Cursor.lockState = CursorLockMode.None;
            spawner.GetComponent<ControllerSpawn>().isToggled = true;
            Destroy(gameObject);
        }
    }
}
