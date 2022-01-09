using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;

    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    [SerializeField]
    private AudioClip mainBgmAudioClip;
    [SerializeField]
    private AudioClip adventureBgmAudioClip;

    [SerializeField]
    private AudioClip[] sfxAudioClips;

    Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        var bgm = new GameObject("BGMSoundPlayer");
        bgm.transform.SetParent(this.transform);
        var sfx = new GameObject("SFXSoundPlayer");
        sfx.transform.SetParent(this.transform);

        bgmPlayer = bgm.AddComponent<AudioSource>();
        sfxPlayer = sfx.AddComponent<AudioSource>();

        foreach (AudioClip audioclip in sfxAudioClips)
        {
            audioClipsDic.Add(audioclip.name, audioclip);
        }
    }

    public void PlaySFXSound(string name, float volume = 1f)
    {
        if (audioClipsDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " : 존재하지 않는 오디오 클립");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[name], volume * masterVolumeSFX);
    }

    public void PlayBGMSound(float volume = 1f)
    {
        bgmPlayer.loop = true;
        bgmPlayer.volume = volume * masterVolumeBGM;

        if (SceneManager.GetActiveScene().name == "Title")
        {
            bgmPlayer.clip = mainBgmAudioClip;
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.clip = adventureBgmAudioClip;
            bgmPlayer.Play();
        }
    }

    private void Start()
    {
        PlayBGMSound(0.2f);
    }
}
