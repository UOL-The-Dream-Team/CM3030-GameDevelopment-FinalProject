using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABPlayFire : MonoBehaviour
{
    [SerializeField]
    GameObject laserBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFire()
    {
        GameObject newLaserBeam = Instantiate(laserBullet, transform.position + transform.forward, transform.rotation);
    }
}
