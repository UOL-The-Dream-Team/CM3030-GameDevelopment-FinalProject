using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABEneEnd : MonoBehaviour
{
    public float onScreenDelay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, onScreenDelay);
    }
}
