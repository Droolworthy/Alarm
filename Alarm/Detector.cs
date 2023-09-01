using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Detector : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedOfSound;

    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void RunCoroutineBoostSoundLevel() 
    {
        int soundLevelMax = 1;

        _coroutine = StartCoroutine(ChangeSoundLevel(soundLevelMax));
    }

    public void RunCoroutineReduceSoundLevel() 
    {
        int soundLevelMin = 0;

        _coroutine = StartCoroutine(ChangeSoundLevel(soundLevelMin));
    }

    private IEnumerator ChangeSoundLevel(int soundLevel)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _audioSource.Play();

        yield return StartCoroutine(TransformSoundLevel(soundLevel));

        DisableAudio();
    }

    private IEnumerator TransformSoundLevel(int soundLevel)
    {
        bool isWork = true;

        while (isWork)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume,
                    soundLevel, Time.deltaTime * _speedOfSound);

            if (_audioSource.volume == soundLevel)
                isWork = false;
     
            yield return null;
        }
    }

    private void DisableAudio()
    {
        int minSoundLevel = 0;

        if (_audioSource.volume == minSoundLevel)
        _audioSource.Stop();
    }
}
