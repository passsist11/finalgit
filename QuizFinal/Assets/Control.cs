using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    
    public float speed = 2f;
    public GameObject newAsteroid;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        rb.AddTorque(Random.Range(-10f, 10f));
		
	}
	
	// Update is called once per frame
    void OnTriggerEnter2D (Collider2D other) {

        if(other.gameObject.CompareTag("Laser")){

            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;

            Instantiate(newAsteroid, transform.position, Quaternion.Euler(0, 0, angle + 60));
            Instantiate(newAsteroid, transform.position, Quaternion.Euler(0, 0, angle - 60));


            Destroy(gameObject);
            Destroy(other.gameObject);
        }
	}
}
