using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvasPrefab;

    void Start()
    {
        // Instantiate the Canvas prefab
        GameObject canvasInstance = Instantiate(canvasPrefab);
        // Optionally, you can set the instantiated Canvas as a child of another GameObject
        canvasInstance.transform.SetParent(transform); // Set Canvas instance as a child of the GameObject this script is attached to
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
