using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]GameObject dialogBox;

    [SerializeField] PlayerInput playerInput;

    [SerializeField] public float dialogTimer = 3f;

    Coroutine corotinaDeEspera; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            corotinaDeEspera = StartCoroutine(EsperarDialogo());
            
        }
    }
    
    //Construir um Case para Verificar qual mae ta jogando pra mudar a frase. 

    IEnumerator EsperarDialogo()
    {
        playerInput.DeactivateInput();

        dialogBox.SetActive(true);

        yield return new WaitForSeconds(dialogTimer);

        playerInput.ActivateInput();    

        Destroy(this);
        
    }
}
