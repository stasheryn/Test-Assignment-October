using System;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    [SerializeField] private int coinValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<CoinCounter>().AddCoins(coinValue);
            // GameManager.instance.AddCollectible();
            Destroy(gameObject);
        }
    }

    public float duration = 3f;
    private Material mat;
    public Color c;
    private float timer = 0f;
    [SerializeField] private Renderer rend;
    [SerializeField] private SkinnedMeshRenderer mshRend;

    void Start()
    {
        // mat = rend.material;

        mat = new Material(mshRend.material); // створюємо копію
        mshRend.material = mat; // призначаємо копію назад
    }

    void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / duration);

            c = mat.color;
            c.a = alpha;
            mat.color = c;
            //rend.material = mat;
            //mshRend.material.color = c;
            //mesh color?
        }
    }


    // public float rotationSpeed = 100f;
    //
    // [Header("Color")]
    //  
    //
    // public Renderer rend;
    // public Color originalColor;
    // public Color trsprntColor;
    // public Color curentColor;
    // private Material nMaterial;
    //
    // private bool isFading = false;
    // public float fadeDuration = 1f;// час зникання в секундах
    // private float fadeTimer = 0f;
    // public float timer;
    // public float duration;
    //
    // // void Update()
    // // {
    // //     transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    // // }
    // //
    // // private void OnTriggerEnter(Collider other)
    // // {
    // //     if (other.CompareTag("Player"))
    // //     {
    // //         //GameManager.instance.AddCollectible();
    // //         Destroy(gameObject);
    // //     }
    // // }
    // private void Start()
    // {
    //     //nMaterial = new Material();
    // }
    //
    // void Update()
    // {
    //     FadeOUT();
    // }
    //
    // // Метод для запуску зникання
    // // [ContextMenu("Start Fading")]
    // public void StartFadeOut()
    // {
    //     isFading = true;
    //     fadeTimer = 0f;
    // }
    //
    // [ContextMenu("Start Fading")]
    // public void FadeOUT()
    // {
    //     if (timer < duration)
    //     {
    //         timer += Time.deltaTime;
    //         float t = timer / duration;
    //         //rend.material.color = Color.Lerp(originalColor, trsprntColor, t);
    //         nMaterial.color = Color.Lerp(originalColor, trsprntColor, t);
    //         rend.material = nMaterial;
    //         curentColor = Color.Lerp(originalColor, trsprntColor, t);
    //     }
    // }
    //
    // // public void FadeOUT()
    // // {
    // //     if (isFading)
    // //     {
    // //         fadeTimer += Time.deltaTime;
    // //         float alpha = Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration);
    // //         Color newColor = originalColor;
    // //         newColor.a = alpha;
    // //         objectMaterial.color = newColor;
    // //
    // //         if (fadeTimer >= fadeDuration)
    // //         {
    // //             isFading = false;
    // //             Destroy(gameObject); // об'єкт знищується після зникання
    // //         }
    // //     }
    // // }
}