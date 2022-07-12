using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABEnemyMov : MonoBehaviour
{
    GameObject target;
    public float explosionForce;
    public float enemySpeed;

    Rigidbody rb;

    ABGameBehav gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player");
        rb.AddForce(rb.transform.up * explosionForce, ForceMode.Impulse);

        gameManager = GameObject.Find("GameManager").GetComponent<ABGameBehav>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localTarget = target.transform.position;
        Vector3 enemyForce = (localTarget - transform.position).normalized * enemySpeed;
       
        rb.AddForce(enemyForce, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameManager.playerHP -= 1;
            Destroy(gameObject);
        }
    }
}
