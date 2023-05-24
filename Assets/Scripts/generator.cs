using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public GameObject wallPrefab;
    float squarePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.x > squarePosition) 
        {
            GameObject newSquare = Instantiate(wallPrefab);
            newSquare.transform.position = new Vector3(squarePosition, Random.Range(-4, 4), 0);
            squarePosition += Random.Range(3,5);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
