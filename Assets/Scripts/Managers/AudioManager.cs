using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioConfig _config;
    [SerializeField] private AudioSource _audioSource;

    private List<SoundType> _playingSounds = new List<SoundType>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void PlaySomeSound(SoundType type)
    {
        SoundClass soundValue = _config.GetSoundClassByType(type);
        if (!_playingSounds.Contains(type))
        {
            _audioSource.PlayOneShot(soundValue.sound, soundValue.volume);
            _playingSounds.Add(type);
            StartCoroutine(RemoveAfterPlay(type, soundValue.sound.length));
        }
    }

    private IEnumerator RemoveAfterPlay(SoundType soundType, float time)
    {
        yield return new WaitForSeconds(time);
        _playingSounds.Remove(soundType);
    }
}