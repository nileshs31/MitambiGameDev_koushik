using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Vector3 dir;
    bool isDead;
    [SerializeField] GameObject taptoPlay,retryBtn;
 
    void Start()
    {
        dir = Vector3.zero;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            taptoPlay.SetActive(false);
            if (dir == Vector3.forward)
            {
                dir = Vector3.left;
            }
            else
            {
                dir = Vector3.forward;
            }
        }
        float move = speed * Time.deltaTime;
        transform.Translate(dir * move);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            //diamond add
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform") || other.CompareTag("MainPlatform"))
        {
            RaycastHit rhit;
            Ray rayDown = new Ray(transform.position, Vector3.down);

            if(!Physics.Raycast(rayDown, out rhit))
            {
                isDead = true;
                if(transform.childCount > 0)
                {
                    transform.GetChild(0).transform.parent = null; //camera
                }
                retryBtn.SetActive(true);
            }
        }
    }
}
