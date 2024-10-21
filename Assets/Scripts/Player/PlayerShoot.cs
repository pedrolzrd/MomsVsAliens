using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] public GameObject shootEffect;

    [SerializeField] GameObject initialProjectile;

    [SerializeField] public GameObject projectile;
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject special;
    Animator animator;
    Tupperware tupperware;
    PlayerMovement playerMovement;

    [SerializeField]GameObject shotgunProjectile;

    //Point UP Logic
    private InputAction UpAimAction;

    private InputAction FireAction;

    public RuntimeAnimatorController newController;

    [SerializeField] RuntimeAnimatorController[] weaponControllers;

    [Header("Sons")]
    [SerializeField]public AudioSource shootSound;
    [SerializeField]public AudioSource weaponCollectSound;

    [Header("Arma")]
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

    [SerializeField]
    bool firing;

    float shotCounter;
    public float rateOfFire = 0.2f;

    [Header("Munições")]
    public int ammoMetralhadora;
    public int ammoShotgun;


    [SerializeField]private bool pointingUP = false;


    // Status Bar
    public TextMeshProUGUI ammoCounter;
    
    int selectedCharacter;



    private void Start()
    {
        playerInput.GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        tupperware = GetComponent<Tupperware>();
        playerMovement = GetComponent<PlayerMovement>();
        fireRate = initialFireRate;
        projectile = initialProjectile;

        selectedCharacter = PlayerPrefs.GetInt("selectedChar");
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
        //Volta o Sprite para a posi��o normal e chama o Metodo que falta o shootpoint pra frente.
        animator.SetBool("upAim", false);
        ChangeAimPositionFront();   
    }

    void Update()
    {    
        if(ammoShotgun <= 0 && ammoMetralhadora <= 0)
        {
            projectile = initialProjectile;
        }

        if(!GameManager.isPaused)
        {
            if (Time.time >= nextShoot)
            {
                if (canShoot)
                {
                    if (playerInput.actions["Fire"].triggered && ammoMetralhadora <= 0 && ammoShotgun <= 0)
                    {
                        Shoot();
                        nextShoot = Time.time + 1f / fireRate;                        
                        animator.SetTrigger("isShooting");
                    }

                    if (playerInput.actions["Fire"].triggered && ammoShotgun > 0 && ammoMetralhadora <= 0)
                    {
                        ShootShotgun();
                        nextShoot = Time.time + 1f / fireRate;
                        animator.SetTrigger("isShooting");
                        ammoShotgun -= 1;
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

                    if (tupperware.score >= tupperware.maxScore && playerInput.actions["SpecialShot"].triggered)
                    {
                        ShootSpecial();
                        animator.SetTrigger("isShooting");
                        tupperware.LoseScoreTupperware(tupperware.maxScore);
                    }

                    UpdateAmmoCounter();
                }
            }
        }

    }

    public void UpdateAmmoCounter()
    {
        int currentAmmo = -1;

        if(ammoMetralhadora > 0) {
            currentAmmo = ammoMetralhadora;
        }else if(ammoShotgun > 0) {
            currentAmmo = ammoShotgun;
        }

        ammoCounter.text = currentAmmo == -1 ? "-" : currentAmmo.ToString();
    }

    void Shoot()
    {
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        shootSound.Play();
        
        Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
    }

    void ShootMetralhadora()
    {
        float spread = Random.Range(spreadPositive, spreadNegative);
        if((shootPoint.rotation.z >= 0 && shootPoint.rotation.z < 10) || 
            (shootPoint.rotation.z >= 80 && shootPoint.rotation.z <= 100))
        {
            //shootPoint.Rotate(0, 0, spread);
            Instantiate(projectile, shootPoint.position, shootPoint.rotation);
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
            ammoMetralhadora -= 1;
        } else
        {
            Instantiate(projectile, shootPoint.position, shootPoint.rotation);
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

    void ShootShotgun()
    {
        AddZRotationOffset(10.0f);
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);

        AddZRotationOffset(-10.0f);
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);

        AddZRotationOffset(-10.0f);
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        shootSound.Play();

        AddZRotationOffset(10.0f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            switch (selectedCharacter)
            {
                case 2:
                    animator.runtimeAnimatorController = weaponControllers[2];

                        break;
            }
            weaponCollectSound.Play();
            canShoot = true;
            animator.runtimeAnimatorController = newController;
            animator = GetComponent<Animator>();
            
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("ShotgunAmmo"))
        {
            projectile = shotgunProjectile;
            ammoShotgun = 20;
            ammoMetralhadora = 0;
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
            shootPoint.localPosition = new Vector3(0.25f, 0.11f, 0);
            pointingUP = false;
        }
    }


    public void AddZRotationOffset(float offset)
    {
    // Pega a rotação local atual do objeto em ângulos de Euler
    Vector3 currentShootpointRotation = shootPoint.localEulerAngles;

        // Adiciona o offset na rotação do eixo Z local
        currentShootpointRotation.z += offset;

        // Atualiza a rotação local do objeto
        shootPoint.localEulerAngles = currentShootpointRotation;
    }
}
