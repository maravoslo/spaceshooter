using UnityEngine;

public class Planet_2Control : MonoBehaviour
{
    float speed;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;//planet2 speed
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
        if(col.tag == "SpaceShipTag")
        {
            PlayExplosion();
            Destroy(gameObject);//destroy planet
        }
    }
    void PlayExplosion()//function to instantiate explosion
    {
        GameObject explode = (GameObject)Instantiate(Explosion);
        explode.transform.position = transform.position;
    }
}
