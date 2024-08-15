using System.Collections;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    Health health;

    //bool canTakeDamage = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && canTakeDamage == true)
        {
            Debug.Log("Encostou no inimigo");
            health.TakeDamage(1);
            StartCoroutine(Damage());
        }
    } */
    

    IEnumerator Damage()
    {
        //canTakeDamage = false;
        sr.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.2f);
        sr.enabled = true;
        //canTakeDamage = true;
    }
}
