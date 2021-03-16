using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float delay = 1;

    void Start()
    {
        Destroy(gameObject, delay);
    }

    public void DestroyFromEvent()
    {
        Destroy(gameObject);
    }
}
