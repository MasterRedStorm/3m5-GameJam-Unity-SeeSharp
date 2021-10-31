using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioEffects
{
    public AudioClip Switch;
    public AudioClip Mixer;
    public AudioClip CharacterSteps;
}

public class AudioEffectSource : SingletonBase<AudioEffectSource>
{
    [SerializeField] private AudioEffects effects;
    
    [SerializeField]
    private AudioSource source;

    private void Reset() => source = GetComponent<AudioSource>();
    
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKey(KeyCode.F1)) Debug.Log("Test");
        if (Input.GetKey(KeyCode.F1)) Play_Switch();
        if (Input.GetKey(KeyCode.F2)) Play_Mixer();
        if (Input.GetKey(KeyCode.F3)) Play_CharacterSteps();
    }

#endif

    private void PlayOneShot(AudioClip clip) => source.PlayOneShot(clip);

    public void Play_Switch() => PlayOneShot(effects.Switch);

    public void Play_Mixer() => PlayOneShot(effects.Mixer);

    public void Play_CharacterSteps() => PlayOneShot(effects.CharacterSteps);
}

