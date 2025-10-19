using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    [SerializeField] private int coinValue;
    [SerializeField] private float timeToDestryAndFade;
    [SerializeField] private Disappear disappear;
    [SerializeField] private bool isCounted;

    private void OnTriggerEnter(Collider other)
    {
        if (isCounted == false)
        {
            isCounted = true;
            if (other.CompareTag("Player"))
            {
                FindFirstObjectByType<CoinCounter>().AddCoins(coinValue);
                disappear.StartFade(timeToDestryAndFade);
                Destroy(gameObject, timeToDestryAndFade + 0.05f);
            }
        }
    }
}