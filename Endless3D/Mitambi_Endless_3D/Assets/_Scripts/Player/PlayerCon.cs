using System.Collections;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move;
    public float forwardSpeed = 10f;
    public float maxSpeed = 30f;
    private float currentSpeed;

    private int desiredLane = 1;    //0:left, 1:middle, 2:right
    public float laneDistance = 1f; //The distance between tow lanes

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float gravity = -12f;
    public float jumpHeight = 2;
    private Vector3 velocity;

    public Animator animator;
    private bool isSliding = false;

    public float slideDuration = 1.5f;

    //bool toggle = false;
    [Header("Power Up Bool")]
    [SerializeField]bool powerUpSpeed = false;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1.2f;
    }

    private void FixedUpdate()
    {
        //Increase Speed
        //if (toggle)
        //{
        //    toggle = false;
        //    if (forwardSpeed < maxSpeed)
        //        forwardSpeed += 0.001f * Time.fixedDeltaTime;
        //}
        //else
        //{
        //    toggle = true;
        //    if (Time.timeScale < 2f)
        //        Time.timeScale += 0.005f * Time.fixedDeltaTime;
        //}
        
        if (!powerUpSpeed)
        {
            Debug.Log("'powerup not used'");
            if (forwardSpeed < maxSpeed)
                forwardSpeed += 0.001f * Time.fixedDeltaTime;
        }
        else if (powerUpSpeed)
        {
            Debug.Log("coroutine started");
            //forwardSpeed = 15f * Time.fixedDeltaTime;  
            //powerSpeed += forwardSpeed + 2f * Time.fixedDeltaTime;
        }
    }
    void Update()
    {
        animator.SetBool("IsGameStarted", true);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);
        if (isGrounded && velocity.y < 0)
            velocity.y = -1f;

        if (isGrounded)
        {
            if (SwipeManager.swipeUp)
                Jump();

            if (SwipeManager.swipeDown && !isSliding)
                StartCoroutine(Slide());
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            if (SwipeManager.swipeDown && !isSliding)
            {
                StartCoroutine(Slide());
                velocity.y = -10;
            }

        }
        controller.Move(velocity * Time.deltaTime);

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        //left right 
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
        move.z = forwardSpeed /** Time.fixedDeltaTime*/;
        controller.Move(move * Time.deltaTime);
    }

    private void Jump()
    {
        StopCoroutine(Slide());
        animator.SetBool("IsSliding", false);
        animator.SetTrigger("jump");
        //controller.center = Vector3.zero;
        controller.center = new Vector3(0, 0.8f, 0);
        controller.height = 1.6f;
        
        isSliding = false;

        velocity.y = Mathf.Sqrt(jumpHeight * 1.6f * -gravity);
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("IsSliding", true);
        //yield return new WaitForSeconds(0.25f / Time.timeScale);
        
        controller.center = new Vector3(0, 0.8f, 1f);
        controller.height = 0.5f;

        yield return new WaitForSeconds((slideDuration - 0.25f) / Time.timeScale);

        animator.SetBool("IsSliding", false);
        //controller.center = Vector3.zero;
        controller.center = new Vector3(0, 0.8f, 0);
        controller.height = 1.6f;
        
        isSliding = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedPowerUp"))
        {
            powerUpSpeed = true;
            currentSpeed = forwardSpeed;
            StartCoroutine(SpeedUpdater());
        }
    }

    IEnumerator SpeedUpdater()
    {
        //forwardSpeed = (currentSpeed < 25f) ? 24f : currentSpeed;
        //for (int i = 0; i < 4; i++)
        //{
        //    yield return new WaitForSeconds(0.25f);
        //    forwardSpeed += 0.25f;
        //}
        ////forwardSpeed = (forwardSpeed != 25f) ? 25f : forwardSpeed;
        //yield return new WaitForSeconds(7f);
        //print("spedd" + forwardSpeed);
        //powerUpSpeed = false;
        //forwardSpeed = currentSpeed;
        //yield return new WaitForSeconds(5f);
        //++ frame
        while (currentSpeed < 15f)
        {
            powerUpSpeed = false;
            currentSpeed += 0.25f * Time.deltaTime;
            forwardSpeed = currentSpeed;
            yield return new WaitForEndOfFrame();
        }
            
        yield return new WaitForSeconds(2f);
        
        //while (forwardSpeed > currentSpeed)
        //{
        //    forwardSpeed -= 0.25f * Time.deltaTime;
        //}
    }
//    while(transform.position!= posToMove.transform.position) 
//            {   

//                transform.position = Vector3.MoveTowards(transform.position, posToMove.transform.position, speed[Random.Range(0, 4)] * Time.deltaTime);
//    yield return new WaitForEndOfFrame();
//}

}
