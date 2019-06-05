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
            Vector3 newPos = new Vector3((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
            newStairs = Instantiate(Stairs, newPos, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
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
            Vector3 newPos = cam.transform.position + new Vector3(0, -1.5f, 0) + transform.forward.normalized * 7;
            float constant = 3.5f;
            newPos = new Vector3(Mathf.Round(newPos.x / constant) * constant, Mathf.Round(newPos.y / 2.6f) * 2.6f, Mathf.Round(newPos.z / constant) * constant);
            newStairs.transform.position = newPos;
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(Mathf.Round(rot.x / 90) * 90, Mathf.Round(rot.y / 90) * 90, Mathf.Round(rot.z / 90) * 90);
            newStairs.transform.rotation = Quaternion.Euler(rot) * Quaternion.Euler(new Vector3(0,180,0));
        }
    }
}
