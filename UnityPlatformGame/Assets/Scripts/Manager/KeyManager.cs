using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
   
  //1.  [SerializeField] GameObject Player;
    [SerializeField] GameObject Door;
    public bool isPickedUp;
    private Vector2 vel;
    public float smoothTime;


    private GameObject player; // Updated to be private  1.

    void Start()
    {
       //2. Initialize if necessary
        player = GameObject.FindGameObjectWithTag("Player"); // Find player initially
    }

    // Update is called once per frame
    void Update()
    {
        //3.
        if (isPickedUp && player != null)
        {
            Vector3 offset = new Vector3(0, 1.7f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position + offset, ref vel, smoothTime);
        }

        /*
        if (isPickedUp)
        {
            Vector3 offset = new Vector3(0, 1.7f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, Player.transform.position + offset, ref vel, smoothTime);
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
         
        }
    }

    //4.
    // Method to update player reference
    public void UpdatePlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }
}
