using UnityEngine;
using UnityEngine.UI;
public class ShipControl : MonoBehaviour
{   
    public GameObject GameManager;
    public GameObject bullet;
    public GameObject BulletPosition01;
    public GameObject Explosion;
    public Text LivesCounter;
    const int MaxLives = 3;//maximum player lives
    int lives;//current player lives
    public float speed;
    public void Init()
    {
        lives = MaxLives;
        //update de lives UI text
        LivesCounter.text = lives.ToString();

        //reset de player posirion to the center of the screen
        transform.position = new Vector2(0,0);
        
        //set player game object to activate
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            GameObject bullet01 = (GameObject)Instantiate (bullet);//instatiate bullet
            bullet01.transform.position = BulletPosition01.transform.position;

        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2 (x,y).normalized;

        Move(direction);
    }
    void Move(Vector2 direction)//movement function
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));//bottom-left corner
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));//top-right corner
        
        //substracting the spaceship
        max.x = max.x - 2f;
        min.x = min.x + 2f;

        max.y = max.y - 2f;
        min.y = min.y + 2f;

        Vector2 pos = transform.position;//get current position

        pos += direction * speed * Time.deltaTime;//calculate new position

        //make sure you can't go outside the screen
        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);

        transform.position = pos;//update position

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //detect collision with enemy or planet
        if((col.tag == "EnemyShipTag") || (col.tag == "PlanetTag"))
        {
            PlayExplosion();
            lives--;//substract lives
            LivesCounter.text = lives.ToString();//update lives UI text

            if(lives == 0)
            {
                //change game manager state to game over
                GameManager.GetComponent<GameManager>().SetGMState(global::GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);//hide the ship
            }
        }
    }
    void PlayExplosion()//function to instantiate explosion
    {
        GameObject explode = (GameObject)Instantiate(Explosion);
        explode.transform.position = transform.position;
    }
}
