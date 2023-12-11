using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController chController;
     public float speed;
    [SerializeField] private float rotationSpeed;
    public float jumpForce;
    private  Animator animator;
    private float gravity;
    void Awake() // se ejecuta antes del start
    {
        chController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    { // getAxis da una trasicion entre valores si esat en cero no hace nada y si se presiona una tecla ya hace
        Vector2 inputVector =  new Vector2 (
            Input.GetAxisRaw("Horizontal"), //saber si lo presiona o no  
            Input.GetAxisRaw("Vertical")
            );
        if (!chController.isGrounded)
        {
            gravity += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            gravity = Physics.gravity.y;
        }



        //Vector3 movementVector = new Vector3(
        // inputVector.x,
        //  0f,
        //  inputVector.y ); 
       
        Vector3 movementVector = Camera.main.transform.forward * inputVector.y + Camera.main.transform.right * inputVector.x;// siempre se va a quedar como direccion  y se multiplica por la posicion y que sera la magnitud 


        movementVector.y = 0f;

        

        if (Input.GetKeyDown(KeyCode.Space) && chController.isGrounded)
        {
            gravity = jumpForce;

        }
        Vector3 composedVector = new Vector3(0f, gravity, 0f);
        chController.Move(movementVector * speed * Time.deltaTime + composedVector * Time.deltaTime); // la normalizacion ayuda a tener la magnitud constante y que lo unico que varie sea la direccion

        if (inputVector != Vector2.zero)// es un atajo para escribir new Vector2(0,0)
        {// en este caso se evalua directamente a cero porque el getAxis devuelve valores negativos
           Quaternion targetRotation = Quaternion.LookRotation(movementVector);


             transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,Time.deltaTime * rotationSpeed);

            animator.SetBool("isRunning", true);
            
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }
}
