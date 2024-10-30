using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]GameObject dialogBox;

    [SerializeField] PlayerInput playerInput;

    [SerializeField] public float dialogTimer = 3f;

    Coroutine corotinaDeEspera;

    [SerializeField] bool travarPlayer = true;

    [SerializeField] bool destroyAfter = true;

    [SerializeField]GameObject[] DialogImages;

    int selectedCharacter;

    

    void Start()
    {
        //Verifica a mãe selecionada.
         selectedCharacter = PlayerPrefs.GetInt("selectedChar");
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

        //Mudar de Acordo com o Personagem.
        switch(selectedCharacter)
           {
            case 0:
                DialogImages[0].SetActive(true);
                break;

                
            case 1:
                DialogImages[1].SetActive(true);
                break;
                
            case 2:
                DialogImages[2].SetActive(true);
                break;
        }
        dialogBox.SetActive(true);

        yield return new WaitForSeconds(dialogTimer);

        if (travarPlayer)
        {
            playerInput.ActivateInput();
        }

        dialogBox.SetActive(false);

        if (destroyAfter)
        {
            Destroy(this);
        }
        
        
    }
}
