using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [Tooltip("Час (у секундах), за який чорна картинка зникне.")]
    public float fadeDuration = 2f;

    private CanvasGroup canvasGroup;
    private float timer = 0f;
    private bool isFading = true;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f; // Початково повністю чорний (видимий)
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    void Update()
    {
        if (!isFading)
            return;

        timer += Time.deltaTime;
        float progress = Mathf.Clamp01(timer / fadeDuration);
        canvasGroup.alpha = 1f - progress; // Зменшуємо прозорість

        if (progress >= 1f)
        {
            isFading = false;
            canvasGroup.alpha = 0f; // Повністю прозорий
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
