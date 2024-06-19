using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{
    [SerializeField] BossHealth bossHealth;

    [SerializeField] GameObject cutscene;
    void Start()
    {
        
    }


    void Update()
    {
        if(!bossHealth.isActiveAndEnabled)
        {
            cutscene.SetActive(true);
        }
    }
}
