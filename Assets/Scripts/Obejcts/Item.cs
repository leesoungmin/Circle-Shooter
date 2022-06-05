using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Score,
    Life,
    bullet

}
public class Item : MonoBehaviour
{
    public ItemType itemType;   //item유형

    public int extraSocre; //추가 점수

    public int extraBullet; //추가 총알

    public int LifeUp;  //목숨 추가

    private void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }
}
