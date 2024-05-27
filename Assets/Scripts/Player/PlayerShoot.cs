using UnityEngine;

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

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!PauseMenu.isPaused)
        {
            if (Time.time >= nextShoot)
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    Shoot();
                    nextShoot = Time.time + 1f / fireRate;
                    animator.SetTrigger("isShooting");
                }
            }
        }
        
    }

    void Shoot()
    {
        Instantiate(shoot, shootPoint.position, shootPoint.rotation);
    }
}
