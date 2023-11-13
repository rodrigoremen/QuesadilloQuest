using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private Vector3 moveDirection;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravityScale = 5f;
    [SerializeField] Camera playerCamera;
    [SerializeField] private GameObject PlayerModel;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Animator animator;
    public bool isKnocking;
    public float knockBackLength = 0.5f;
    private float knockBackCounter;
    public Vector2 knockBackPower;
    public GameObject[] PlayerPieces;
    public float bounceForce = 8f;
    // Start is called before the first frame update

    public bool stopMovement;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnocking && !stopMovement)
        {
            // Guardar la altura del salto
            float yStore = moveDirection.y;
            // Movimiento
            // Mover al personaje en base a la cámara
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            // Normalizar el movimiento
            moveDirection.Normalize();
            moveDirection = moveDirection * moveSpeed;
            // Regresar la altura del salto
            moveDirection.y = yStore;


            // Salto
            if (controller.isGrounded)
            {
                moveDirection.y = -1f;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
            // if (Input.GetButtonDown("Jump") && controller.isGrounded)
            // {
            //    moveDirection.y = jumpForce;
            // }

            // Gravedad
            moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);
            // if (!controller.isGrounded)
            // {
            //     gravityScale += Physics.gravity.y * Time.deltaTime;
            // }
            // else
            // {
            //     gravityScale = Physics.gravity.y * Time.deltaTime;

            // }


            // Mover al personaje
            controller.Move(moveDirection * Time.deltaTime);

            // Mover la cámara

            // Validación para que la cámara no se mueva cuando el personaje no se mueve
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
                // Rotar al personaje en base a la cámara
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                PlayerModel.transform.rotation = Quaternion.Slerp(PlayerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            }
        }

        if (isKnocking)
        {
            knockBackCounter -= Time.deltaTime;


            float yStore = moveDirection.y;
            moveDirection = (PlayerModel.transform.forward * -knockBackPower.x);
            moveDirection.y = yStore;

            moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);

            controller.Move(moveDirection * Time.deltaTime);

            if (knockBackCounter <= 0)
            {
                isKnocking = false;
            }
        }

        if (stopMovement)
        {
            moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);
            moveDirection = Vector3.zero;
            controller.Move(moveDirection);
        }

        // Animación
        animator.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
        animator.SetBool("Grounded", controller.isGrounded);

    }

    public void KnockBack()
    {
        isKnocking = true;
        knockBackCounter = knockBackLength;
        Debug.Log("KnockBack");
        moveDirection.y = knockBackPower.y;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Bounce()
    {
        // isKnocking = true;
        // knockBackCounter = knockBackLength;
        // Debug.Log("KnockBack");
        moveDirection.y = bounceForce;
        // moveDirection.x = direction.x * knockBackPowerX;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
