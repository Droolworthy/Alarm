using UnityEngine;

[RequireComponent(typeof(Detector))]
public class Alarm : MonoBehaviour
{
    private Detector _detector;

    private void Start()
    {
        _detector = GetComponent<Detector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        _detector.RunCoroutineBoostSoundLevel();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        _detector.RunCoroutineReduceSoundLevel();
    }
}
