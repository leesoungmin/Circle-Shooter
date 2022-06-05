using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCount;

    [SerializeField] MeshRenderer mesh_Player;

    [SerializeField] ScoreManager theSM;

    [SerializeField] StageManager theStageM;

    public int maxHp;
    public int currentHp;

    bool isInvincibleMode = false; //현재 무적 상태인지

    [SerializeField] Text[] txt_Hp; //체력 ui


    void Start()
    {
        currentHp = maxHp;
        HpUpdata();

    }

    
    public void DecreaseHp(int _num)
    {
        if(!isInvincibleMode)
        {
            StartCoroutine(BlinkCor());

            currentHp -= _num;
            HpUpdata();
            if (currentHp <= 0)
            {
                PlayerDead();
                theStageM.GameOverUI();
            }
            SoundManager.instance.PlaySE("Hit");
        }
        
    }

    public void IncreaseHP(int _num)
    {
        if (currentHp == maxHp)
            return;

        currentHp += _num;
        if (currentHp > maxHp)
            currentHp = maxHp;

         HpUpdata();
    }
    void HpUpdata()
    {
        for(int i =0; i<txt_Hp.Length; i++)
        {
            if(i < currentHp)
            {
                txt_Hp[i].gameObject.SetActive(true);
                
            }
            else
            {
                txt_Hp[i].gameObject.SetActive(false);

            }
        }
    }
    IEnumerator BlinkCor()
    {
        isInvincibleMode = true;
        for (int i = 0; i < blinkCount * 2; i++)
        {
            mesh_Player.enabled = !mesh_Player.enabled;
            yield return new WaitForSeconds(blinkSpeed);

        }
        isInvincibleMode = false;
    }

    void PlayerDead()
    {
        Debug.Log("유다희");
    }
}
