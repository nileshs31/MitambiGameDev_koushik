using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlatformController.Instance.SpawnPlatform();
            StartCoroutine(Fall());
            Debug.Log("Spawn Platform");
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
