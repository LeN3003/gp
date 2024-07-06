using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool locked;
    private Animator animator;//

    private BoxCollider2D doorCollider;
    void Start()
    {
        locked = true;

        //
        animator = GetComponent<Animator>();

        // Reference the new door collider from the child GameObject
        doorCollider = transform.Find("DoorCollider").GetComponent<BoxCollider2D>();

        doorCollider.enabled = true; // Ensure the doorCollider is enabled at the start


        animator.SetBool("isUnlocked", !locked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Debug.Log("Key entered.");
            locked = false;
            animator.SetBool("isUnlocked", true);//
            doorCollider.enabled = false; // Disable the blocking collider



            // Ensure the door is unlocked before destroying the key
            StartCoroutine(DestroyKeyAfterUnlock(other.gameObject));
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Debug.Log("Key exited.");
            locked = true;
            animator.SetBool("isUnlocked", false);
            doorCollider.enabled = true; // Enable the blocking collider
        }
    }
    */

    private IEnumerator DestroyKeyAfterUnlock(GameObject key)
    {
        yield return null; // Wait for the end of the frame to ensure all updates are applied

        Destroy(key);
    }
}
