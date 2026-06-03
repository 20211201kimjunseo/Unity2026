using UnityEngine;
public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    public GameObject starPrefab;
    public GameObject magnetPrefab;
    public GameObject heartPrefab;
    public GameObject superBombPrefab;
    public float span = 1f;
    public int ratio = 3;
    float delta = 0f;
    public bool isRound2 = false;
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            int dice = Random.Range(0, 100);
            GameObject item;
            if (dice < ratio * 10)       
            {
                item = Instantiate(bombPrefab);
            }
            else if (dice < 40 && isRound2)    
            {
                item = Instantiate(superBombPrefab);
            }
            else if (dice < 43)     
            {
                item = Instantiate(starPrefab);
            }
            else if (dice < 46 && isRound2)    
            {
                item = Instantiate(magnetPrefab);
            }
            else if (dice < 49)             
            {
                item = Instantiate(heartPrefab);
            }
            else                          
            {
                item = Instantiate(applePrefab);
            }

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 7, z);
            item.transform.SetParent(transform);
            if (isRound2)
            {
                item.GetComponent<ItemController>().dropSpeed = -3f;
            }
            delta = 0f;
        }
    }
}