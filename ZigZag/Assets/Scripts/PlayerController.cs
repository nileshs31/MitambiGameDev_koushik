using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    public bool isDead , isPowerup;
    [SerializeField] TextMeshProUGUI tapToPlayText;
   // [SerializeField] GameObject scoretext;
    [SerializeField] GameController gameController;
    void Start()
    {
        dir = Vector3.forward;
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0) && !isDead)
        //if (Input.GetMouseButtonDown(0) && !isDead)
        {
            tapToPlayText.enabled = false;
           // scoretext.SetActive(true);
            gameController.gameon = true;
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

        //playerpos
  /*      Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("Playerpos" + playerPos);*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            gameController.DiamondCount(1);
        }

       /* if (other.CompareTag("PowerUp"))
        {
            other.gameObject.SetActive(false);
            isPowerup = true;
           // PlatformController.Instance.DeactivatePlatform();   
          //  PlatformController.Instance.SpawnPlatformPowerup();
        }*/
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
                // retryBtn.SetActive(true);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ShowAdsPannel();
            }
        }
    }
}
