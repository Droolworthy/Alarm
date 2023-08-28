using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundControl : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private readonly float _volume = 0.1f;
    private readonly float _startValue = 0.001f;
    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _startValue;
    }

    public void RunCoroutine(int soundLevel)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeSoundLevel(soundLevel));
    }

    private IEnumerator ChangeSoundLevel(int soundLevel)
    {
        EnableAudio();

        yield return TransformSoundLevel(soundLevel);

        DisableAudio();
    }

    private void EnableAudio()
    {
        if (_audioSource.volume == _startValue)
        {
            _audioSource.Play();
        }
    }

    private IEnumerator TransformSoundLevel(int soundLevel)
    {
        bool isWork = true;

        while (isWork)
        {
            if (_audioSource.volume == soundLevel)
            {
                isWork = false;
            }
            else
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, soundLevel, Time.deltaTime * _volume);
            }

            yield return null;
        }
    }

    private void DisableAudio()
    {
        int minSoundLevel = 0;

        if (_audioSource.volume == minSoundLevel)
        {
            _audioSource.Stop();
        }
    }
}
