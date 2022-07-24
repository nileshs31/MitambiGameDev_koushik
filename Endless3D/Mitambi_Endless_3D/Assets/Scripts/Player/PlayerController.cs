using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

//[RequireComponent(typeof(CharacterController),typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    //[Header("Player Speed")]
    //private float playerSpeed;
    //private float gravity;
    ////[SerializeField] private float maxPlayerSpeed = 4f;
    ////[SerializeField] private float playerSpeedRate = 4f;
    //[SerializeField] private float initialPlayerSpeed = 4f;
    //[SerializeField] private float initialGravityValue = -9.8f;
    //[SerializeField] private float jumpHeight = 1f;

    //[SerializeField] private LayerMask groundLayer;
    //[SerializeField] private Animator animator;
    //[SerializeField] private AnimationClip slideAnimationClip;
    //[SerializeField] private UnityEvent<Vector3> turnEvent;

    //private Vector3 movementDirection = Vector3.forward;
    //private Vector3 playerVelocity;

    ////sliding
    //private bool isSliding = false;
    //private int slidingAnimationId;

    //private PlayerInput playerInput;
    //private InputAction turnAction;
    //private InputAction jumpAction;
    //private InputAction slideAction;

    //private void Awake()
    //{
    //    playerInput = GetComponent<PlayerInput>();
    //    characterController = GetComponent<CharacterController>();

    //    turnAction = playerInput.actions["Turn"];
    //    jumpAction = playerInput.actions["Jump"];
    //    slideAction = playerInput.actions["Slide"];

    //    slidingAnimationId = Animator.StringToHash("Sliding"); 
    //}

    ////events
    //private void OnEnable()
    //{
    //    turnAction.performed += PlayerTurn;
    //    slideAction.performed += PlayerSlide;
    //    jumpAction.performed += PlayerJump;
    //}

    //private void OnDisable()
    //{
    //    turnAction.performed -= PlayerTurn;
    //    slideAction.performed -= PlayerSlide;
    //    jumpAction.performed -= PlayerJump;
    //}

    //private void PlayerTurn(InputAction.CallbackContext context)
    //{

    //}

    //private void PlayerSlide(InputAction.CallbackContext context)
    //{
    //    if(!isSliding && IsGround()) { StartCoroutine(Slide()); }
    //}

    //private IEnumerator Slide()
    //{   

    //    isSliding = true;
    //    //shrink colllider
    //    Vector3 originalControllerCenter = characterController.center;
    //    Vector3 newControllerCenter = originalControllerCenter;
    //    characterController.height /= 2;
    //    newControllerCenter.y -= characterController.height / 2;
    //    characterController.center = newControllerCenter;


    //    animator.Play(slidingAnimationId); 
    //    yield return new WaitForSeconds(slideAnimationClip.length);


    //    characterController.height *= 2;
    //    characterController.center = originalControllerCenter;
    //    isSliding = false;
    //}

    //private void PlayerJump(InputAction.CallbackContext context)
    //{
    //    Debug.Log("PlayerJUmp");
    //    if (IsGround())
    //    {
    //        playerVelocity.y += Mathf.Sqrt(jumpHeight * gravity * -3f);
    //        characterController.Move(playerVelocity * Time.deltaTime);
    //    }
    //}


    //private void Start()
    //{
    //    playerSpeed = initialPlayerSpeed;
    //    gravity = initialGravityValue;
    //    Debug.Log("playerSpeed");
    //}

    //private void Update()
    //{
    //    characterController.Move(transform.forward * playerSpeed * Time.deltaTime);    
    //    if(IsGround() && playerVelocity.y < 0)
    //    {
    //        playerVelocity.y = 0f;
    //    }

    //    playerVelocity.y += gravity * Time.deltaTime;
    //    characterController.Move(playerVelocity * Time.deltaTime);

    //}

    //private bool IsGround(float length = 0.2f)
    //{
    //    Vector3 raycastOriginFirst = transform.position;
    //    raycastOriginFirst.y -= characterController.height / 2f;
    //    raycastOriginFirst.y += 0.1f;

    //    Vector3 raycastOriginSecond = raycastOriginFirst;
    //    raycastOriginFirst -= transform.forward * 0.2f;
    //    raycastOriginSecond += transform.forward * 0.2f;

    //    Debug.DrawLine(raycastOriginFirst, Vector3.down, Color.red, 2f);
    //    Debug.DrawLine(raycastOriginSecond, Vector3.down, Color.blue, 2f);



    //    if (Physics.Raycast(raycastOriginFirst,Vector3.down, out RaycastHit hit,length,groundLayer) 
    //    || Physics.Raycast(raycastOriginSecond, Vector3.down, out RaycastHit hit2, length, groundLayer))
    //    {
    //        return true;
    //    }
    //    return false;

    //}

    private Vector3 direction;
    private float forwardSpeed;
    public float jumpForce = 7;
    public float Gravity = -9.8f;
    public int lane = 1; //0:left,1:center,2:right
    public float laneDistance = 1;
    //public bool isGrounded;
    public Animator animator;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //direction.z = forwardSpeed;


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lane++;
            if (lane == 3) { lane = 2; }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lane--;
            if (lane == -1)
            {
                lane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (lane == 0) { targetPosition += Vector3.left * laneDistance; }
        else if (lane == 2) { targetPosition += Vector3.right * laneDistance; }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 100);
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.deltaTime);

        //animator.SetBool("IsJumping", IsGround());
        if (characterController.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private bool IsGround(float length = 0.2f)
    {
        Vector3 raycastOriginFirst = transform.position;
        raycastOriginFirst.y -= characterController.height / 2f;
        raycastOriginFirst.y += 0.1f;

        Vector3 raycastOriginSecond = raycastOriginFirst;
        raycastOriginFirst -= transform.forward * 0.2f;
        raycastOriginSecond += transform.forward * 0.2f;

        Debug.DrawLine(raycastOriginFirst, Vector3.down, Color.red, 2f);
        Debug.DrawLine(raycastOriginSecond, Vector3.down, Color.blue, 2f);



        if (Physics.Raycast(raycastOriginFirst, Vector3.down, out RaycastHit hit, length, groundLayer)
        || Physics.Raycast(raycastOriginSecond, Vector3.down, out RaycastHit hit2, length, groundLayer))
        {
            return true;
        }
        return false;
    }
}
