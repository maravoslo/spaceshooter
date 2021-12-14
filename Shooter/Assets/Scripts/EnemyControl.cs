using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{   
    GameObject PointsCounter;
    public GameObject Explosion;
    float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;//enemy speed

        PointsCounter = GameObject.FindGameObjectWithTag("ScoreTag");//get the Points text
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos =  transform.position;//current position

        pos = new Vector2 (pos.x, pos.y - speed * Time.deltaTime);//new position
        transform.position = pos;//update position

        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));//bottom-left corner
        
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //detect collision with spaceship or bullet
        if((col.tag == "SpaceShipTag") || (col.tag == "BulletTag"))
        {
            PlayExplosion();

            //add 10 points to the score
            PointsCounter.GetComponent<GameScore>().Score += 10;

            Destroy(gameObject);//destroy enemy
        }
    }
    void PlayExplosion()//function to instantiate explosion
    {
        GameObject explode = (GameObject)Instantiate(Explosion);
        explode.transform.position = transform.position;
    }
}
