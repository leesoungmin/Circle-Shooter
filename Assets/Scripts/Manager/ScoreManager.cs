using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int currentScore;
    public int GetCurrentScore() { return currentScore; }
    public void ResetCurrentScore() { maxDistance = 0;}
    public void AllReset() { maxDistance = 0; currentScore = 0; extraScore = 0; distanceSocre = 0; }
    public static int extraScore;  //아이템 점수
    int distanceSocre; //거리점수
    float maxDistance; //플레이어가 이동한 최대 거리
    float originPosZ; //플레이어의 최초 위치의 값

    [SerializeField] Text txt_Score;
    [SerializeField] Transform tf_Player; //플레이어의 위치 정보

    private void Start()
    {
        originPosZ = tf_Player.position.z;
        currentScore = 0;
        maxDistance = 0;
        extraScore = 0;
        distanceSocre = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(tf_Player.position.z > maxDistance)
        {
            maxDistance = tf_Player.position.z;
            distanceSocre = Mathf.RoundToInt(maxDistance - originPosZ);
        }
        currentScore = extraScore + distanceSocre;
        txt_Score.text = string.Format("{0:000,000}", currentScore);
    }
}
