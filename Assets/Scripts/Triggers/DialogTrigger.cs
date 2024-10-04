using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]GameObject dialogBox;

    [SerializeField] PlayerInput playerInput;

    [SerializeField] public float dialogTimer = 3f;

    Coroutine corotinaDeEspera;

    [SerializeField] bool travarPlayer = true;

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
        if (travarPlayer)
        {
            playerInput.DeactivateInput();
        }
        

        dialogBox.SetActive(true);

        yield return new WaitForSeconds(dialogTimer);

        if (travarPlayer)
        {
            playerInput.ActivateInput();
        }
        

        Destroy(this);
        
    }
}
