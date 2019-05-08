using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarBehavior : MonoBehaviour
{
    private bool inCar;
    public GameObject car;


    // Start is called before the first frame update
    void Start()
    {
        inCar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("e") && !inCar && Vector3.Distance(transform.position, car.transform.position) < 10)
        {
            inCar = true;
            car.GetComponent<CarUserControl>().enabled = true;
        }
    }
}
