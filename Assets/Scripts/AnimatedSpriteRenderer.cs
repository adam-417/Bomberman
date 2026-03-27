using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite idleSprite;
    public Sprite[] animationSprites;

    public float animationTime = 0.25f;

    public bool loop = true;
    public bool idle = true;

    private int animationFrame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }

    private void NextFrame()
    {
        if (idle)
        {
            spriteRenderer.sprite = idleSprite;
            return;
        }

        animationFrame++;

        if (animationFrame >= animationSprites.Length)
        {
            if (loop)
            {
                animationFrame = 0;
            }
            else
            {
                animationFrame = animationSprites.Length - 1;
            }
        }

        spriteRenderer.sprite = animationSprites[animationFrame];
    }
}