using UnityEngine;

public class Alarm : MonoBehaviour
{
    public bool IsEnabled { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Criminal>(out Criminal criminal))
        {
            IsEnabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Criminal>(out Criminal criminal))
        {
            IsEnabled = false;
        }
    }
}
