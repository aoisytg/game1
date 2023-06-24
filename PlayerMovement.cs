using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float jumpForce = 8f;

    [SerializeField]
    private float potionTimer;

    [SerializeField]
    private float underwather;

    public bool nokillwather = false;
    public Text Score;

    private float horizontalInput;
    private Scene ascene;
    private bool isJumping = false;
    private bool hasPurchasedItem;
    private bool HasBoost = false;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private int desiredIndex = 3;
    private Animator animator;
    private int loadscore;
    private float duration = 3f;
    private int coins = 0;

    private void Start()
    {
        coins = SaveManager.LoadCoins();
        animator = GetComponent<Animator>();
        loadscore = PlayerPrefs.GetInt("Score", coins);
        hasPurchasedItem = PlayerPrefs.GetInt("HasPurchasedItem", 0) == 1;
        rb = GetComponent<Rigidbody2D>();
        Score = GameObject.Find("ScoreText").GetComponent<Text>();
        SetScoreText(loadscore);
        horizontalInput = Input.GetAxis("Horizontal");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SetScoreText(int score1)
    {
        Score.text = "Score: " + score1.ToString();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        if (moveX > 0)
        {
            spriteRenderer.flipX = false; // No flip
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true; // Flip horizontally
        }

        SetScoreText(coins);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        if (potionTimer >= 0 && HasBoost)
        {
            potionTimer -= Time.deltaTime;
        }
        if (potionTimer <= 0)
        {
            StopTimer();
        }

        if (HasBoost)
        {
            jumpForce = 16f;
        }
        else
        {
            jumpForce = 8f;
        }

        if (moveX != 0)
        {
            animator.Play("RedWalk");
        }
        else
        {
            animator.Play("RedIdle");
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.Play("Redjump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (collision.gameObject.CompareTag("Boost"))
        {
            HasBoost = true;
            Destroy(collision.gameObject);
            StartTimer();
        }
        if (collision.gameObject.CompareTag("GiveWeapon")) { }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coins += 1;
            SetScoreText(loadscore);
            SaveManager.SaveCoins(coins);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            ascene = SceneManager.GetActiveScene();
            if (ascene.buildIndex == desiredIndex)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (other.gameObject.CompareTag("UWP"))
        {
            nokillwather = true;
            Destroy(other.gameObject);
        }
    }

    private void StartTimer()
    {
        potionTimer = duration;
    }

    private void StopTimer()
    {
        potionTimer = 0f;
        HasBoost = false;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", coins);
        PlayerPrefs.SetInt("HasPurchasedItem", hasPurchasedItem ? 1 : 0);
        PlayerPrefs.Save();
    }
}
