using UnityEngine;

[RequireComponent(typeof(SoundControl))]
public class Alarm : MonoBehaviour
{
    private SoundControl _soundControl;

    private void Start()
    {
        _soundControl = GetComponent<SoundControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int soundLevel = 1;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(_soundControl.ChangeSoundLevel(soundLevel));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int soundLevel = 0;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(_soundControl.ChangeSoundLevel(soundLevel));
        }
    }
}