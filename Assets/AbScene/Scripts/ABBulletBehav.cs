using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABBulletBehav : MonoBehaviour
{
    GameObject target;
    public float bulletSpeed;

    Rigidbody rb;

    ABGameBehav gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<ABGameBehav>();

        //target = GameObject.FindWithTag("Player");
        //rb.AddForce(rb.transform.up * explosionForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            Destroy(gameObject);
        }

        if(collision.transform.tag == "Enemy")
        {
            gameManager.enemyDestroyed += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }



    }
}
