using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject shoot;
    [SerializeField]
    Transform shootPoint;
    Animator animator;

    [SerializeField]
    float fireRate;
    float nextShoot;

    [SerializeField] public PlayerInput playerInput;

    public bool canShoot = false;

    public RuntimeAnimatorController newController;
    
    private void Start()
    {
        playerInput.GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
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
                        //animator.SetTrigger("isShooting");
                    }
                }
                
            }
        }
        
    }

    void Shoot()
    {
        Instantiate(shoot, shootPoint.position, shootPoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            canShoot = true;
            animator.runtimeAnimatorController = newController;
            Destroy(collision.gameObject);
        }
    }
}
