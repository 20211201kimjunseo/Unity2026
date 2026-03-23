using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float startSpeed = 30f;
    float decreaseRatio = 0.99f;

    float rotSpeed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 30;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = startSpeed;
        }

        transform.Rotate(0, 0, rotSpeed);

        rotSpeed *= decreaseRatio;
    }
}
