using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject Stairs;
    public GameObject Floor;
    public GameObject Wall;
    public Camera cam;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;
    public bool holdingObject = false;
    private GameObject newObject;
    public AudioSource Pickup;
    // Start is called before the first frame update
    void Start()
    {
    // Pickup = gameObject.GetComponent<AudioSource>();
        gun1.SetActive(false);
        gun2.SetActive(false);
        gun3.SetActive(false);
        gun4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gun1.active == false)
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
            gun3.SetActive(false);
            gun4.SetActive(false);
            Pickup.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && gun1.active == true)
            gun1.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Alpha2) && gun2.active == false)
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
            gun3.SetActive(false);
            gun4.SetActive(false);
            Pickup.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && gun2.active == true)
            gun2.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Alpha3) && gun3.active == false)
        {

            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(true);
            gun4.SetActive(false);
            Pickup.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && gun3.active == true)
            gun3.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Alpha4) && gun4.active == false)
        {

            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(false);
            gun4.SetActive(true);
            Pickup.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && gun4.active == true)
            gun4.SetActive(false);
        if ((Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.F3)) && !holdingObject)
        {
            Vector3 newPos = new Vector3((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
            if (Input.GetKeyDown(KeyCode.F1))
            {
             newObject = Instantiate(Stairs, newPos, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
             newObject = Instantiate(Wall, newPos, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
             newObject = Instantiate(Floor, newPos, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
            }
               

            holdingObject = true;
        }
        else if ((Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.F3)) && holdingObject)
        {
            Destroy(newObject);
            holdingObject = false;
        }

        if (Input.GetMouseButtonDown(0) && holdingObject)
        {
            newObject = Instantiate(newObject, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0)));
        }
        if (holdingObject)
        {
            Vector3 newPos = cam.transform.position + new Vector3(0, -1.5f, 0) + transform.forward.normalized * 7;
            float constant = 3.5f;
            newPos = new Vector3(Mathf.Round(newPos.x / constant) * constant, Mathf.Round(newPos.y / 2.6f) * 2.6f, Mathf.Round(newPos.z / constant) * constant);
            newObject.transform.position = newPos;
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(Mathf.Round(rot.x / 90) * 90, Mathf.Round(rot.y / 90) * 90, Mathf.Round(rot.z / 90) * 90);
            newObject.transform.rotation = Quaternion.Euler(rot) * Quaternion.Euler(new Vector3(0,180,0));
        }
    }
}
