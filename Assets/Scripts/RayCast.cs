using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    //fire range 
    public float range = 20f;
    public GameObject prefab;
    private GameObject activeTeleporter;
    
    //fire and impact effect 
    //public ParticleSystem fire;
    //public GameObject impactEffect;
    [SerializeField] LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() { 
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    
    void Shoot() {

        //particle effect on fire
        //fire.Play();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, layerMask))
            {
            if(activeTeleporter != null) {
                Destroy(activeTeleporter);
            }
            //Destroy(prefab);
            Rigidbody rb = Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            activeTeleporter = rb.gameObject;

            //Instantiate(prefab, hit.point, Quaternion.identity);
            Debug.Log("Hit something");
            }
        else
            {
    Debug.Log("Hit nothing");
    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);

            }
        //particle effect on inpact
        //GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //Destroy(impactGO, 2f);
    }
}
