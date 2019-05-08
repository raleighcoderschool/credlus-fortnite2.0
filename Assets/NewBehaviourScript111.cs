using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript111 : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;

    // Start is called before the first frame update
    void Start()
    {
        gun1.SetActive(false);
        gun2.SetActive(false);
        gun3.SetActive(false);
        gun4.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
            gun3.SetActive(false);
            gun4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
            gun3.SetActive(false);
            gun4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(true);
            gun4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(false);
            gun4.SetActive(true);
        }
        print(transform.GetChild(0).transform.rotation.x);
    }
}
