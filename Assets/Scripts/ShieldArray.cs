using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldArray : MonoBehaviour
{
    [SerializeField]
    private GameObject shieldPrefab;

    [SerializeField]
    private int numOfShields;


    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minX;
    

    private List<GameObject> shields = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int n = 0; n < numOfShields; n++)
        {
            float dx = Random.Range(minX, maxX);

            GameObject obj = Instantiate(shieldPrefab, new Vector3(dx, 3, -10), Quaternion.identity);
            shields.Add(obj);

        }

    }

    // Update is called once per frame
    void Update()
    {
        for(int n = 0; n < numOfShields; n++)
        {
            ShieldScript p  = shields[n].GetComponent<ShieldScript>();
           
            if(p.getNumberOfHits() == 3)
            {
                Debug.Log("Träff " + p.getNumberOfHits());
                shields[n].SetActive(false);
                //shields.RemoveAt(n);
            }
        }
    }
}
