using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    GameObject director;
    AudioSource aud;
    Animator animator;
    bool isHit = false;

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
                transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isHit) return;

        if (other.gameObject.tag == "Apple")
        {
            Debug.Log("사과를 잡았다!!");
            aud.PlayOneShot(appleSE);
            director.GetComponent<GameDirector>().GetApple();
        }
        else if (other.gameObject.tag == "Bomb")
        {
            Debug.Log("폭탄에 맞았다!!");
            aud.PlayOneShot(bombSE);
            director.GetComponent<GameDirector>().GetBomb();
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
}