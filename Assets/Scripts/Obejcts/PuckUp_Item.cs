using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckUp_Item : MonoBehaviour
{
    [SerializeField] Gun[] guns;

    GunController theGC;
    StatusManager theSM;

    private void Start()
    {
        theGC = FindObjectOfType<GunController>();
        theSM = FindObjectOfType<StatusManager>();
    }

    const int NOMAL_GUN = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();

            int extra = 0;

            if(item.itemType == ItemType.Score)
            {
               SoundManager.instance.PlaySE("Score");
                extra = item.extraSocre;
                ScoreManager.extraScore += extra;
            }
            if(item.itemType == ItemType.bullet)
            {
                SoundManager.instance.PlaySE("Bullet");
                extra = item.extraBullet;
                guns[NOMAL_GUN].bulletCount += extra;
                theGC.BulletUIset();
            }
            if(item.itemType == ItemType.Life)
            {
                extra = item.LifeUp;
                theSM.IncreaseHP(extra);
            }
            string message = "+" + extra;
            FloatTextManager.instance.CreateFloatingText(other.transform.position, message);
            Destroy(other.gameObject);
        }
    }
}
