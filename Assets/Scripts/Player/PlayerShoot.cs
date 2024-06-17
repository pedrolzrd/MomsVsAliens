using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] public GameObject shootEffect;

    [SerializeField]GameObject shoot;
    [SerializeField]Transform shootPoint;
    Animator animator;

    [SerializeField]public AudioSource shootSound;

    [SerializeField]
    float fireRate;
    float nextShoot;

    [SerializeField] public PlayerInput playerInput;

    public bool canShoot = false;

    public RuntimeAnimatorController newController;

    [SerializeField]private bool pointingUP = false;

    //Point UP Logic
    private InputAction UpAimAction;

    private void Start()
    {
        playerInput.GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        UpAimAction = playerInput.actions["UpAim"];
        UpAimAction.performed += OnButtonPressed;
        UpAimAction.canceled += OnButtonReleased;
        UpAimAction.Enable();
    }

    private void OnDisable()
    {
        UpAimAction.performed -= OnButtonPressed;
        UpAimAction.canceled -= OnButtonReleased;
        UpAimAction.Disable();
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        if (canShoot)
        {
            animator.SetBool("upAim", true);
            //StartCoroutine(changeAimPositionUp());
            ChangeAimPositionUp();
        }
    }

    private void OnButtonReleased(InputAction.CallbackContext context)
    {
        animator.SetBool("upAim", false);
        //StartCoroutine(changeAimPositionFront());
        ChangeAimPositionFront();   
    }

    void Update()
    {
        if(!PauseMenu.isPaused)
        {
            if (Time.time >= nextShoot)
            {
                if (canShoot)
                {
                    if (playerInput.actions["Fire"].triggered)
                    {
                        Shoot();
                        nextShoot = Time.time + 1f / fireRate;
                        animator.SetTrigger("isShooting");
                    }
                }
                
            }
        }

        /*if (canShoot)
        {
            if (playerInput.Controls.UpAim.IsPress())
            {
                Debug.Log("registro do UPaim");
                if (pointingUP == true)
                {

                }
                else
                {
                    Debug.Log("Entrou no if do Change Position UP");
                    animator.SetBool("upAim", true);
                    StartCoroutine(changeAimPositionUp());
                }
            }
            
            //Mudar para mirar pra cima qunado segurar.

            //Mudar para parar de mirar pra cima qunado parar de segurar
            


            if(playerInput.actions["Move"].triggered)
            {
                animator.SetBool("upAim", false);
                StartCoroutine(changeAimPositionFront());
            }
        }*/
       

    }

    void Shoot()
    {
        Instantiate(shoot, shootPoint.position, shootPoint.rotation);
        shootSound.Play();
        Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            canShoot = true;
            animator.runtimeAnimatorController = newController;
            animator = GetComponent<Animator>();
            Destroy(collision.gameObject);
        }
    }


    public IEnumerator changeAimPositionUp()
    {

        shootPoint.Rotate(0f, 0f, 90f);
        shootPoint.localPosition = new Vector3(-0.056f, 0.384f, 0);
        pointingUP = true;
        yield return null;
    }

    public IEnumerator changeAimPositionFront()
    {
        if (pointingUP == true)
        {
            shootPoint.Rotate(0f, 0f, -90f);
            shootPoint.localPosition = new Vector3(0.265f, 0.144f, 0);
            pointingUP = false;
        }
        yield return null;
    }

    public void ChangeAimPositionUp()
    {

        shootPoint.Rotate(0f, 0f, 90f);
        shootPoint.localPosition = new Vector3(-0.056f, 0.384f, 0);
        pointingUP = true;
        
    }

    public void ChangeAimPositionFront()
    {
        if (pointingUP == true)
        {
            shootPoint.Rotate(0f, 0f, -90f);
            shootPoint.localPosition = new Vector3(0.265f, 0.144f, 0);
            pointingUP = false;
        }
       
    }
}
