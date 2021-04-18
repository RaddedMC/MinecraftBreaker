using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBrickCollider : MonoBehaviour
{
    //Variables
    [SerializeField] Sprite[] lifeSprites;
    [SerializeField] AudioClip destroyClip;
    [SerializeField] int pointsPerDestroyed = 50;
    [SerializeField] int pointsPerDamaged = 25;
    [SerializeField] GameObject particleVFX;
    int remainingHits;
    public SpriteRenderer spriteRenderer;

    //Set up the block with however many lives is set in editor
    private void Start()
    {
        remainingHits = lifeSprites.Length;
        Debug.Log("This block has " + remainingHits + " lives.");
        spriteRenderer.sprite = lifeSprites[remainingHits - 1];
    }

    // When collision occurs
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Sparkles!!
        GameObject sparkes = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(sparkes, 2f);

        //Play noise!!
        AudioSource.PlayClipAtPoint(destroyClip, new Vector2(transform.position.x, transform.position.y));

        // Calculate how many lives the block has left, set new sprite or destroy it
        remainingHits--;
        Debug.Log("IMPACT! This block has " + remainingHits + " lives remaining.");
        if (remainingHits == 0)
        {
            FindObjectOfType<StatusScript>().AddToScore(pointsPerDestroyed);
            Debug.Log("You destroyed this block!");
            Destroy(gameObject);
        }
        else
        {
            FindObjectOfType<StatusScript>().AddToScore(pointsPerDamaged);
            spriteRenderer.sprite = lifeSprites[remainingHits - 1];
        }
    }
}
