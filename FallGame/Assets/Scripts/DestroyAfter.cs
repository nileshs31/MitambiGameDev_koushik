using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    // Start is called before the first frame update
    public float activeAfter;
    public float destroyAfter;

    void Start()
    {
        Invoke("activeafter", activeAfter);
        this.gameObject.SetActive(false);
    }
    public void activeafter()
    {
        this.gameObject.SetActive(true);
        Invoke("destroyafter", destroyAfter);
    }

    public void destroyafter()
    {
        Destroy(this.gameObject);
    }
}
