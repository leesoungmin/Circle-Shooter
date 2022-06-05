using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("총알 데미지")]
    [SerializeField] int dmg;

    [Header("피격 효과음")]
    [SerializeField]
    string sound_Ricochet;

    void OnCollisionEnter(Collision collision)
    {
        SoundManager.instance.PlaySE(sound_Ricochet);
        Destroy(gameObject);

        if(collision.transform.CompareTag("Mine"))
        {
            collision.transform.GetComponent<Mine>().Damaged(dmg);
        }
    }
}
