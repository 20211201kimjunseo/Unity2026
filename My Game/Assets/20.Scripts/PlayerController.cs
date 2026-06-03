using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    public GameObject appleExplosion;
    public GameObject bombExplosion;
    public GameObject heartExplosion;
    public GameObject magnetExplosion;
    public GameObject starExplosion;
    public GameObject superBombExplosion;
    public UnityEngine.UI.Image starTimerImage;
    public bool isMagnet = false;

    GameObject director;
    AudioSource aud;
    Animator animator;
    bool isHit = false;
    bool isInvincible = false;

    void Start()
    {

        Application.targetFrameRate = 60;
        aud = GetComponent<AudioSource>();
        director = GameObject.Find("GameDirector");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isHit) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = ~LayerMask.GetMask("Player");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                x = Mathf.Clamp(x, -1, 1);
                z = Mathf.Clamp(z, -1, 1);

                transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isHit) return;
        if (other.gameObject.tag == "Apple")
        {
            Instantiate(appleExplosion, other.transform.position, Quaternion.identity);
            Debug.Log("+100Á¡");
            aud.PlayOneShot(appleSE);
            director.GetComponent<GameDirector>().GetApple();
        }
        else if (other.gameObject.tag == "Bomb")
        {
            if (isInvincible) { Destroy(other.gameObject); return; }
            Instantiate(bombExplosion, other.transform.position, Quaternion.identity);
            aud.PlayOneShot(bombSE);
            director.GetComponent<GameDirector>().GetBomb();
            isHit = true;
            animator.SetTrigger("Hit");
            Invoke(nameof(RecoverFromHit), 2.0f);
        }
        else if (other.gameObject.tag == "ExtraLife")
        {
            Instantiate(heartExplosion, other.transform.position, Quaternion.identity);
            director.GetComponent<GameDirector>().GetHeart();
        }
        else if (other.gameObject.tag == "Star")
        {
            Instantiate(starExplosion, other.transform.position, Quaternion.identity);
            StopAllCoroutines();
            StartCoroutine(Invincible());
        }
        else if (other.gameObject.tag == "Magnet")
        {
            Instantiate(magnetExplosion, other.transform.position, Quaternion.identity);
            StopAllCoroutines();
            StartCoroutine(MagnetEffect());
        }
        else if (other.gameObject.tag == "SuperBomb")
        {
            Instantiate(bombExplosion, other.transform.position, Quaternion.identity);
            aud.PlayOneShot(bombSE);
            director.GetComponent<GameDirector>().GetSuperBomb();
            isHit = true;
            animator.SetTrigger("Hit");
            Invoke(nameof(RecoverFromHit), 2.0f);
        }
        Destroy(other.gameObject);
    }

    void RecoverFromHit()
    {
        isHit = false;
    }
    IEnumerator Invincible()
    {
        isInvincible = true;
        starTimerImage.gameObject.SetActive(true);
        float duration = 5f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            starTimerImage.fillAmount = 1 - (elapsed / duration);
            yield return null;
        }
        starTimerImage.gameObject.SetActive(false);
        isInvincible = false;
    }
    IEnumerator MagnetEffect()
    {
        isMagnet = true;
        float duration = 5f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
            foreach (GameObject apple in apples)
            {
                apple.transform.position = Vector3.MoveTowards(
                    apple.transform.position,
                    transform.position,
                    5f * Time.deltaTime
                );
            }
            yield return null;
        }
        isMagnet = false;
    }
}