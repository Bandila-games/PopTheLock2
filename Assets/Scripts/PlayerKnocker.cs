using UnityEngine;

public class PlayerKnocker : MonoBehaviour
{
    public bool IsKnockerHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsKnockerHit = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsKnockerHit = false;
    }
}
