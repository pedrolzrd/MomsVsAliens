using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] public GameObject shootEffect;

    [SerializeField] GameObject initialShoot;
    [HideInInspector]
    public GameObject shoot;
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject special;
    Animator animator;
    Tupperware tupperware;
    PlayerMovement playerMovement;

    [SerializeField]public AudioSource shootSound;
    [SerializeField]public AudioSource weaponCollectSound;

    [SerializeField]
    public float initialFireRate;
    [HideInInspector]
    public float fireRate; 
    float nextShoot;
    [SerializeField]
    float spreadPositive;
    [SerializeField]
    float spreadNegative;

    [SerializeField] public PlayerInput playerInput;

    public bool canShoot = false;
    public int ammoMetralhadora;

    public RuntimeAnimatorController newController;

    [SerializeField]private bool pointingUP = false;

    //Point UP Logic
    private InputAction UpAimAction;

    private InputAction FireAction;

    [SerializeField]
    bool firing;


    float shotCounter;
    public float rateOfFire = 0.2f;

    private void Start()
    {
        playerInput.GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        tupperware = GetComponent<Tupperware>();
        playerMovement = GetComponent<PlayerMovement>();
        fireRate = initialFireRate;
        shoot = initialShoot;
    }

    private void OnEnable()
    {
        UpAimAction = playerInput.actions["UpAim"];
        UpAimAction.performed += OnButtonPressed;
        UpAimAction.canceled += OnButtonReleased;
        UpAimAction.Enable();

        FireAction = playerInput.actions["Fire"];
        FireAction.performed += FirePressed;
        FireAction.canceled += FireCanceled;
        FireAction.Enable();
    }

    private void FireCanceled(InputAction.CallbackContext context)
    {
        firing = false;
    }

    private void FirePressed(InputAction.CallbackContext context)
    {
        firing = true;
    }

    private void OnDisable()
    {
        UpAimAction.performed -= OnButtonPressed;
        UpAimAction.canceled -= OnButtonReleased;
        UpAimAction.Disable();

        FireAction.performed -= FirePressed;
        FireAction.canceled -= FireCanceled;
        FireAction.Disable();
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        if (canShoot)
        {
            animator.SetBool("upAim", true);
            ChangeAimPositionUp();
        }
    }

    private void OnButtonReleased(InputAction.CallbackContext context)
    {
        //Volta o Sprite para a posição normal e chama o Metodo que falta o shootpoint pra frente.
        animator.SetBool("upAim", false);
        ChangeAimPositionFront();   
    }

    void Update()
    {    
        if(ammoMetralhadora <= 0)
        {
            fireRate = initialFireRate;
            shoot = initialShoot;
        }

        if(!PauseMenu.isPaused)
        {
            if (Time.time >= nextShoot)
            {
                if (canShoot)
                {
                    if (playerInput.actions["Fire"].triggered && ammoMetralhadora <= 0)
                    {
                        Shoot();
                        nextShoot = Time.time + 1f / fireRate;                        
                        animator.SetTrigger("isShooting");
                    }


                    if (firing && ammoMetralhadora > 0)
                    {
                        shotCounter -= Time.deltaTime;

                        if (shotCounter <= 0)
                        {
                            shotCounter = rateOfFire;
                            ShootMetralhadora();
                        }
                    }
                    else
                    {
                        shotCounter -= Time.deltaTime;
                    }

                    if (tupperware.score >= tupperware.maxScore && Input.GetKeyDown(KeyCode.P))
                    {
                        ShootSpecial();
                        animator.SetTrigger("isShooting");
                        tupperware.LoseScoreTupperware(tupperware.maxScore);
                    }
                }
            }
        }

    }

    void Shoot()
    {
        Instantiate(shoot, shootPoint.position, shootPoint.rotation);
        shootSound.Play();
        
        Instantiate(shootEffect, shootPoint.localPosition, shootPoint.rotation);

    }

    void ShootMetralhadora()
    {
        float spread = Random.Range(spreadPositive, spreadNegative);
        if((shootPoint.rotation.z >= 0 && shootPoint.rotation.z < 10) || 
            (shootPoint.rotation.z >= 80 && shootPoint.rotation.z <= 100))
        {
            shootPoint.Rotate(0, 0, spread);
            Instantiate(shoot, shootPoint.position, shootPoint.rotation);
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
            ammoMetralhadora -= 1;
        } else
        {
            Instantiate(shoot, shootPoint.position, shootPoint.rotation);
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
            ammoMetralhadora -= 1;
        }
    }
        
    void ShootSpecial()
    {
        Instantiate(special, shootPoint.position, shootPoint.rotation);
        shootSound.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            weaponCollectSound.Play();
            canShoot = true;
            animator.runtimeAnimatorController = newController;
            animator = GetComponent<Animator>();
            
            Destroy(collision.gameObject);
        }
    }

    public void ChangeAimPositionUp()
    {
        shootPoint.localRotation = Quaternion.Euler(0f, 0f, 90f);
        shootPoint.localPosition = new Vector3(0.029f, 0.450f, 0);
        pointingUP = true;
    }

    public void ChangeAimPositionFront()
    {
        if (pointingUP == true)
        {
            shootPoint.localRotation = Quaternion.Euler(0f, 0f, 0f);
            shootPoint.localPosition = new Vector3(0.265f, 0.144f, 0);
            pointingUP = false;
        }
    }
}
