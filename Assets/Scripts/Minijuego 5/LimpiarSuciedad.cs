using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LimpiarSuciedad : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] private ParticleSystem burbujas;
    public MouseManager mouse;
    public Camera cam;
    public int brushSize = 20;

    private Texture2D texture;
    private SpriteRenderer sr;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        sr = GetComponent<SpriteRenderer>();

        // Hacemos una copia de la textura para no modificar el asset original
        texture = Instantiate(sr.sprite.texture);

        sr.sprite = Sprite.Create(
            texture,
            sr.sprite.rect,
            new Vector2(0.5f, 0.5f),
            sr.sprite.pixelsPerUnit
        );
        isLimpio();
    }

    void Update()
    {
        Limpiar();
        if(isLimpio())
        {
            EndMinigame();
        }
    }
    private void Limpiar()
    {
        if (!mouse.isDragging)
        {
            burbujas.Stop();
            return;
        }
        Vector2 mouseWorld = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Collider2D col = GetComponent<Collider2D>();

        // Solo limpia si el ratón está sobre el collider
        if (!col.OverlapPoint(mouseWorld))
        {
            burbujas.Stop();
            return;
        }

        // Posición local respecto al sprite
        Vector2 localPos = transform.InverseTransformPoint(mouseWorld);

        Sprite sprite = sr.sprite;

        // Tamaño del sprite en unidades del mundo
        float width = sprite.bounds.size.x;
        float height = sprite.bounds.size.y;

        // Convertimos a coordenadas entre 0 y 1
        float x = (localPos.x + width / 2f) / width;
        float y = (localPos.y + height / 2f) / height;

        // Convertimos a píxeles dentro de la textura
        int pixelX = Mathf.RoundToInt(x * sprite.rect.width);
        int pixelY = Mathf.RoundToInt(y * sprite.rect.height);
        burbujas.Play();
        BorrarTextura(pixelX, pixelY);
    }
    void BorrarTextura(int x, int y)
    {
        for (int i = -brushSize; i <= brushSize; i++)
        {
            for (int j = -brushSize; j <= brushSize; j++)
            {
                if (i * i + j * j > brushSize * brushSize)
                {
                    continue;
                }

                int px = x + i;
                int py = y + j;
                if (px < 0 || py < 0 || px >= texture.width || py >= texture.height)
                {
                    continue;
                }

                Color color = texture.GetPixel(px, py);
                color.a = 0f;
                texture.SetPixel(px, py, color);
            }
        }

        texture.Apply();
    }
    private bool isLimpio()
    {
        Color[] pixels = texture.GetPixels();
        int alphaPixels = 0;
        foreach(Color c in pixels)
        {
            if(c.a == 0)
            {
                alphaPixels++;
            }
        }
        if(alphaPixels >= 2359240)
        {
            return true;
        }
        return false;
    }
    void EndMinigame()
    {
        SceneManager.LoadScene(nextScene);
    }
}
