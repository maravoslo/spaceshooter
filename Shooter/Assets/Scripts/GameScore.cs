using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text PointsCounter;

    int score;

    public int Score{
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScore();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PointsCounter = GetComponent<Text> ();
    }

    //function to update score
    void UpdateScore(){
        string scoreStr = string.Format ("{0:000}", score);
        PointsCounter.text = scoreStr;
    }
}
