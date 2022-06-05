using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{

    [SerializeField] Text txt_CurrentScore;
    [SerializeField] Text gameclear_txt_CurrentScore;
    [SerializeField] Text gameover_txt_CurrentScore;
    [SerializeField] GameObject GameClear_panel;
    [SerializeField] GameObject GameOver_panel;
    [SerializeField] GameObject go_UI;
    [SerializeField] ScoreManager theSM;
    [SerializeField] GameObject[] go_stages;
    public int currentStage = 0;


    [SerializeField] Rigidbody PlayerRigid;
    [SerializeField] Transform tf_OriginPos;

    void Start()
    {
        currentStage = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }


    public void ShowClearUI()
    {
        PlayerMovement.cnaMove = false;
        PlayerRigid.isKinematic = true; //모든 중력이 꺼짐
        go_UI.SetActive(true);
        txt_CurrentScore.text = string.Format("{0:000,000}", theSM.GetCurrentScore()); 
    }

    public void GameOverUI()
    {
        PlayerMovement.cnaMove = false;
        PlayerRigid.isKinematic = true; //모든 중력이 꺼짐
        GameOver_panel.SetActive(true);
        gameover_txt_CurrentScore.text = string.Format("{0:000,000}", theSM.GetCurrentScore());
    }

    public void GameClearUI()
    {
        PlayerMovement.cnaMove = false;
        PlayerRigid.isKinematic = true; //모든 중력이 꺼짐
        GameClear_panel.SetActive(true);
        gameclear_txt_CurrentScore.text = string.Format("{0:000,000}", theSM.GetCurrentScore());
    }



    public void Exit_BTN()
    {
        SceneManager.LoadScene("TitleScene");
        theSM.AllReset();
        currentStage = 0;
        go_UI.SetActive(false);
        GameOver_panel.SetActive(false);
        GameClear_panel.SetActive(false);
    }

    public void ReGame_BTN()
    {
        SceneManager.LoadScene(1);
        PlayerMovement.cnaMove = true;
        go_UI.SetActive(false);
    }

    public void NextBtn()
    {
        if(currentStage < go_stages.Length - 1)
        {
            theSM.ResetCurrentScore();
            PlayerMovement.cnaMove = true;
            PlayerRigid.isKinematic = false; //모든 중력이 꺼짐
            PlayerRigid.gameObject.transform.position = tf_OriginPos.position;
            go_stages[currentStage++].SetActive(false);
            go_stages[currentStage++].SetActive(true);
            go_UI.SetActive(false);
        }
        else
        {
            Debug.Log("모든 스테이지를 클리어함.");
        }
        
    }
}
