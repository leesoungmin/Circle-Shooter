using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float destoryTime;
    [SerializeField] Animation ani;

    // Start is called before the first frame update
    void Start()
    {
        ani.Play();
        Destroy(gameObject, destoryTime);
    }

    
}
