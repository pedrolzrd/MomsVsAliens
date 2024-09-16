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
    int scoreQuantity;
    [SerializeField]
    float spreadPositive;
    [SerializeField]
    float spreadNegative;

    [SerializeField] public PlayerInput playerInput;

    public bool canShoot = false;
    public int ammoMetralhadora;
    public int ammoDoze;

    public RuntimeAnimatorController newController;

    [SerializeField]private bool pointingUP = false;

    //Point UP Logic
    private InputAction UpAimAction;

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
            ChangeAimPositionUp();
        }
    }

    private void OnButtonReleased(InputAction.CallbackContext context)
    {
        animator.SetBool("upAim", false);
        ChangeAimPositionFront();   
    }

    void Update()
    {
        print(ammoDoze);
        print(shoot.name);
        print(fireRate);
        if(Input.GetKeyDown(KeyCode.E))
        {
            ammoDoze = 0;
        }

        if(ammoMetralhadora <= 0 || ammoDoze <= 0)
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
                    if (playerInput.actions["Fire"].triggered && ammoMetralhadora <= 0 && ammoDoze <= 0)
                    {
                        Shoot();
                        nextShoot = Time.time + 1f / fireRate;                        
                        animator.SetTrigger("isShooting");
                    }
                    else if (playerInput.actions["Fire"].triggered && ammoMetralhadora > 0 && ammoDoze <= 0)
                    {
                        ShootMetralhadora();
                        nextShoot = Time.time + 1f / fireRate;
                        animator.SetTrigger("isShooting");                        
                        ammoMetralhadora -= 1;
                    }
                    else if (playerInput.actions["Fire"].triggered && ammoDoze > 0 && ammoMetralhadora <= 0)
                    {
                        ShootDoze();
                        nextShoot = Time.time + 1f / fireRate;
                        animator.SetTrigger("isShooting");
                        ammoDoze -= 1;
                    }

                    if (tupperware.score >= scoreQuantity && Input.GetKeyDown(KeyCode.P))
                    {
                        ShootSpecial();
                        animator.SetTrigger("isShooting");
                        tupperware.score -= scoreQuantity;
                    }
                }
            }
        }
    }

    void Shoot()
    {
        if(playerMovement.isFacingRight == true)
        {
            shootPoint.rotation = Quaternion.Euler(0, 0, 0);
            Instantiate(shoot, shootPoint.position, shootPoint.rotation);
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
        }
        else if (playerMovement.isFacingRight == false)
        {
            shootPoint.rotation = Quaternion.Euler(0, 180, 0);
            Instantiate(shoot, shootPoint.position, shootPoint.rotation);
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
        }
    }

    void ShootMetralhadora()
    {
        float spread = Random.Range(spreadPositive, spreadNegative);
        if (playerMovement.isFacingRight == true)
        {
            shootPoint.rotation = Quaternion.Euler(0, 0, spread);
            Instantiate(shoot, shootPoint.position, shootPoint.rotation);
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
        }else if(playerMovement.isFacingRight == false)
        {
            shootPoint.rotation = Quaternion.Euler(0, 180, spread);
            Instantiate(shoot, shootPoint.position, shootPoint.rotation);
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
        }        
    }

    void ShootDoze()
    {
        if(playerMovement.isFacingRight == true)
        {
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 0, 10));
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 0, 0));
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 0, -10));
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
        }
        else if (playerMovement.isFacingRight == false)
        {
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 180, 10));
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 180, 0));
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 180, -10));
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
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

    public IEnumerator changeAimPositionUp()
    {
        if(pointingUP == true)
        {
            yield return null;

        } else
        {
            shootPoint.localRotation = Quaternion.Euler(0f, 0f, 90f);
            shootPoint.localPosition = new Vector3(-0.056f, 0.384f, 0);
            pointingUP = true;
            yield return null;
        }
    }

    public IEnumerator changeAimPositionFront()
    {
        if (pointingUP == true)
        {
            shootPoint.localRotation = Quaternion.Euler(0f, 0f, 0f);
            shootPoint.localPosition = new Vector3(0.265f, 0.144f, 0);
            pointingUP = false;
        }
        yield return null;
    }

    public void ChangeAimPositionUp()
    {
        shootPoint.localRotation = Quaternion.Euler(0f, 0f, 90f);
        shootPoint.localPosition = new Vector3(-0.056f, 0.384f, 0);
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
