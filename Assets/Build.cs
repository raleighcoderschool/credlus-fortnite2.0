using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject Stairs;
    public Camera cam;
    private bool holdingStairs = false;
    private GameObject newStairs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && !holdingStairs)
        {
            newStairs = Instantiate(Stairs, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
            holdingStairs = true;
        }
        else if (Input.GetKeyDown(KeyCode.F1) && holdingStairs)
        {
            Destroy(newStairs);
            holdingStairs = false;
        }

        if (Input.GetMouseButtonDown(0) && holdingStairs)
        {
            newStairs = Instantiate(Stairs, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
        }
        if (holdingStairs)
        {
            newStairs.transform.position = cam.transform.position + new Vector3(0,-1.5f,0) + transform.forward.normalized*7;
            newStairs.transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0,180,0));
        }
    }
}
