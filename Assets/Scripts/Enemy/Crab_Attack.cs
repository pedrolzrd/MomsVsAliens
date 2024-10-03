using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_Attack : MonoBehaviour
{
    [SerializeField]public int attackDmg = 3;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    private Health playerHealth;


    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();   
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(colInfo != null)
        {
            DealDamage();
        }
    }

    public void DealDamage()
    {
        playerHealth.TakeDamage(attackDmg);
    }


    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
