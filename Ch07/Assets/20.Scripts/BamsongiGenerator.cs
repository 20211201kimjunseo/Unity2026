using Unity.Hierarchy;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    public float throwForce = 10f;
    public float minPower = 200f;

    float startY;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {


            float power = Input.mousePosition.y - startY;
            if (power < minPower) return;

            GameObject bamsoni = Instantiate(bamsongiPrefab);
            bamsoni.transform.position = transform.position;

            Vector3 dir = transform.forward + transform.up * 0.5f;
            bamsoni.GetComponent<Bamsongicontroller>().Shoot(dir * power * throwForce);

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //bamsoni.GetComponent<Bamsongicontroller>().Shoot(ray.direction * 2000);
        }
    }
}
