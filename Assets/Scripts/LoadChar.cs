using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadChar : MonoBehaviour
{
    public RuntimeAnimatorController[] charAnimators;
    public Animator playerAnimator;

    public RuntimeAnimatorController newAnimator;

    private void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedChar");
        RuntimeAnimatorController CharAnimator = charAnimators[selectedCharacter];

        playerAnimator.runtimeAnimatorController = CharAnimator;
        //playerAnimator = GetComponent<Animator>();
    }
}
