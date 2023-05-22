using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject wallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Instantiate(wallPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //Touch touch = Input.GetTouch(0);
        if (Input.GetMouseButtonDown(0))
        {
            float screenSize = Screen.height;
            float cameraSize = Camera.main.orthographicSize * 2;
            float yPoz = Input.mousePosition.y / screenSize * cameraSize - cameraSize / 2;
            transform.position = new Vector3(transform.position.x, yPoz, transform.position.z); 
        }
        else if (Input.touchCount > 0)
        {
            
        }
        spriteRenderer.color = new Color(255,0,0);
        //Player movement
        transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
    }
}
