using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject car;
    //public GameObject flag;
    //public GameObject distance;
    public Transform car;
    public Transform flag;
    public TextMeshProUGUI distance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //car = GameObject.Find("car");
    }

    // Update is called once per frame
    void Update()
    {
        //float length = flag.transform.position.x
        //    - car.transform.position.x;
        float length = flag.transform.position.x
                - car.position.x;
        //distance.GetComponent<TextMeshProUGUI>().text =
        //    "Distance : " + length.ToString("F2") + "m";
        distance.text =
            "°Å¸® : " + length.ToString("F2") + "m";
    }
}
