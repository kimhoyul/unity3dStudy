using Unity.AppUI.Core;
using UnityEngine;
using static Define;

public class SoundManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    // [BGM(AudioSource)] [EFFECT(AudioSource)] 

    // 음원 재생기 -> AudioSource
    // 음원 -> AudioClip
    // 듣는 귀 -> AudioListener

    public void Init() // 현재로써는 Start 에서 Init 할수가 없는상황, 앞으로도 발생할 수 있음
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" }; // 빈 게임 오브젝트 생성, 부모가 될녀석
            Object.DontDestroyOnLoad(root); // 씬이 바뀌어도 파괴되지 않도록 설정

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < (int)Define.Sound.MaxCount; i++) 
            {
                GameObject go = new GameObject(soundNames[i]);
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Sound.Bgm].loop = true;
        }
    }

    public void Play(Define.Sound type, string path, float pitch = 1.0f)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        if (type == Define.Sound.Bgm)
        {
            AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Logger.Log($"AudioClip Missing! {path}");
                return;
            }

        }
        else // effect
        {
            AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Logger.Log($"AudioClip Missing! {path}");
                return;
            }

            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }
}
