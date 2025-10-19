using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float fadeDuration = 2f;
    [SerializeField] private bool isFading = false;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // поступове зникання
        if (isFading)
        {
            Color c = rend.material.color;
            c.a -= Time.deltaTime / fadeDuration;
            rend.material.color = c;
        }
    }

    public void StartFade(float duration)
    {
        fadeDuration = duration;
        isFading = true;
    }
}