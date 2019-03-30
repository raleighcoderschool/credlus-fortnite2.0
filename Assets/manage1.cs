using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manage1 : MonoBehaviour
{
    public Camera cam;
    public GameObject snipper;
    public GameObject AK;
    public GameObject scopedy;
    public GameObject AKSCOPE;
    public GameObject reticle;
    private MeshRenderer snipperMesh;
    private MeshRenderer akmesh;
    //public NewBehaviourScript111 guy;
    // Start is called before the first frame update
    void Start()
    {
        snipperMesh = snipper.GetComponent<MeshRenderer>();
        akmesh = AK.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") > 0 && snipper.activeSelf)
        {
            snipperMesh.enabled = false; 
            scopedy.SetActive(true);
            cam.fieldOfView = 15;
            reticle.SetActive(false);
        } else
        {
            snipperMesh.enabled = true;
            scopedy.SetActive(false);
            reticle.SetActive(true);
            


        }
        if (Input.GetAxis("Fire2") > 0 && AK.activeSelf)
        {
            akmesh.enabled = false;
            AKSCOPE.SetActive(true);
            cam.fieldOfView = 30;
            reticle.SetActive(false);
        }
        else
        {
            akmesh.enabled = true;
            AKSCOPE.SetActive(false);
        }
        if (Input.GetAxis("Fire2")==0f)
        {
            cam.fieldOfView = 60;
        }


    }

}
