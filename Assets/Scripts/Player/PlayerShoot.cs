using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] public GameObject shootEffect;

    [SerializeField]GameObject shoot;
    [SerializeField]Transform shootPoint;
    Animator animator;

    [SerializeField]public AudioSource shootSound;
    [SerializeField]public AudioSource weaponCollectSound;

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
