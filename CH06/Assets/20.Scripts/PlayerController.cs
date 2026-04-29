using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    float jumpForce = 300f;
    public float walkForce = 7f;
    float maxWalkSpeed = 1f;
    float timer = 0f;
    Rigidbody2D rb;
    Animator anim;
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            rb.linearVelocityY == 0)
        {
            rb.AddForce(transform.up * jumpForce);
        }
        if (rb.linearVelocityX < maxWalkSpeed)
        {
            rb.AddForce(transform.right * walkForce);
        }
        timer += Time.deltaTime;
        if (rb.linearVelocityY != 0)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (transform.position.y < -8)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
        Debug.Log("¼º°ø");
    }
}