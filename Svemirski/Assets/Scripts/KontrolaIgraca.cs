using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaIgraca : MonoBehaviour {

    public GameObject projektil;
    public float brzinaProjektila;
    public float speed = 15.0f;
    float xmin;
    float xmax;
    public float snaga = 250f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Projektil missile = collider.gameObject.GetComponent<Projektil>();
        if(missile)
        {
            snaga -= missile.GetDamage();
            missile.Hit();
            if(snaga <= 0)
            {
                Die();
            }
        }
      
    }
    void Die()
        {
            Destroy(gameObject);
        }

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 krajnjelijevo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 krajnjedesno = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = krajnjelijevo.x;
        xmax = krajnjedesno.x;
    }


    // Update is called once per frame
    void Update () {
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Laser = Instantiate(projektil, transform.position, Quaternion.identity) as GameObject;
            Laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, brzinaProjektila, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

	}
}
