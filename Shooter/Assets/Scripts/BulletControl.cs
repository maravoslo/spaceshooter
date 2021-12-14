using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos =  transform.position;//current position

        pos = new Vector2 (pos.x, pos.y + speed * Time.deltaTime);//new position
        transform.position = pos;//update position

        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));//top-right corner

        if(transform.position.y > max.y)//if the bullet flies outside on top, gets destroyed
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //detect collision with spaceship or bullet
        if(col.tag == "EnemyShipTag")
            Destroy(gameObject);//destroy bullet

    }
}
