using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float delay = 0.5f;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlatformController.Instance.SpawnPlatform();
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(2);
        switch (gameObject.name)
        {
            case "LeftPlatform":
                PlatformController.Instance.LeftPlatform.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "TopPlatform":
                PlatformController.Instance.TopPlatform.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "Platform":
                break;
        }
    }
}
