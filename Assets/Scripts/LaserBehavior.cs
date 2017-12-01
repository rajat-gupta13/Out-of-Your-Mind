using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {

    public float moveSpeed;
    public float radius;
    public float power;
    

    //private Vector3 startVector;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        StartCoroutine(Despawn());
        //startVector = Camera.main.transform.forward;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        // transform.localPosition = transform.localPosition + new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
        // transform.Translate(startVector * moveSpeed * Time.deltaTime);
	}

    IEnumerator Despawn() {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Destructible") {
            // Trigger the other object's explosion from other script
            other.gameObject.GetComponent<Destructible>().DestroyShatter(this.gameObject);
            Debug.Log("laser hit: " + other.gameObject.name);
        }

        StopCoroutine("Despawn");
        Destroy(this.gameObject);
    }

    public IEnumerator DestroyDestructible(GameObject current, GameObject shatter)
    {
        current.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        shatter.SetActive(true);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject.tag != "Player")
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                //Debug.Log("Force Added");
                rb.useGravity = true;
            }
        }
        yield return null;
    }

}
