using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] StageManager theSM;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(theSM.currentStage == 2)
            {
                theSM.GameClearUI();
            }
            else
            {
                theSM.ShowClearUI();
            }
        }
    }
}
