using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
     
    [Header("사운드 등록")]
    [SerializeField]
    Sound[] bgmSounds;
    [SerializeField]
    Sound[] sfxSounds;

    [Header("브금 플레이어")]
    [SerializeField]
    AudioSource bgmPlayer;
    [Header("효과음 플레이어")]
    [SerializeField] AudioSource[] sfxPlayer;
    
    void Start()
    {
        instance = this;
        PlayRandomBGM();
    }
    public void PlaySE(string _soundName)
    {
        for(int i = 0; i < sfxSounds.Length; i++)
        {
            if (_soundName == sfxSounds[i].soundName)
            {
                for(int x = 0; x < sfxPlayer.Length; x++)
                {
                    if(!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfxSounds[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                Debug.Log("모든 효과음이 플레이어가 사용중입니다.");
                return;
            }
        }
        Debug.Log("등록된 효과음이 없다");
    }

    public void PlayRandomBGM()
    {
        int radom = Random.Range(0, 2); //정수는 최대값을 안구함 2개를 구할려면 0,3
        bgmPlayer.clip = bgmSounds[radom].clip;
        bgmPlayer.Play();
    }
}
