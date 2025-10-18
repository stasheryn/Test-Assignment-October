using UnityEngine;

public class FadeWithShader : MonoBehaviour
{
    public float duration = 3f;
    private Material mat;
    private float timer = 0f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / duration);
            Color c = mat.color;
            c.a = alpha;
            mat.color = c;
        }
    }
}
