using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Vehicles.Car;

public class CarBehavior : MonoBehaviour
{
    private bool inCar;
    public GameObject car;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        inCar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && !inCar && Vector3.Distance(transform.position, car.transform.position) < 10)
        {
            inCar = true;
            car.GetComponent<CarUserControl>().enabled = true;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.transform.position = car.transform.position + new Vector3(-0.25f,0.75f,-0.25f) + car.transform.forward*-0.75f;
            player.transform.SetParent(car.transform);
            player.GetComponent<CharacterController>().enabled = false;

        }
        else if (Input.GetKeyDown("e") && inCar)
        {
            inCar = false;
            car.GetComponent<CarUserControl>().enabled = false;
            player.GetComponent<FirstPersonController>().enabled = true;
            player.transform.SetParent(null);
            player.GetComponent<CharacterController>().enabled = true;

        }
    }
}
