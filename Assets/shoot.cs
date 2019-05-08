using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    public Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource gunAudio;
    private float nextFire;
    public bool automatic;

    public GameObject ImpactDust;

    
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();

    }


    void Update()
    {
        if ((Input.GetButton("Fire1") && Time.time > nextFire && automatic) || Input.GetButtonDown("Fire1") && Time.time > nextFire && !automatic)
        {
            nextFire = Time.time + fireRate;

            gunAudio.Play();

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {


                Instantiate(ImpactDust, hit.point, Quaternion.LookRotation(hit.normal));

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            
        }
    }

}