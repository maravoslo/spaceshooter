using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject spaceship;
    public GameObject EnemySpawner;
    public GameObject Planet_1Spawner;
    public GameObject GameOver;
    public GameObject PointsCounter;
    public GameObject GameTitle;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }
    GameManagerState GMState;
    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Update gamemanager state
    void UpdateGMState()
    {
        switch(GMState)
        {
        case GameManagerState.Opening:
            //hide gameover
            GameOver.SetActive(false);

            //display gamename
            GameTitle.SetActive(true);

            //set play button visible
            PlayButton.SetActive(true);
            break;

        case GameManagerState.Gameplay:
            //reset the score
            PointsCounter.GetComponent<GameScore>().Score = 0;

            //hide the gamename
            GameTitle.SetActive(false);

            //hide playbutton on gameplay state
            PlayButton.SetActive(false);

            //set the ship visible and init the player lives
            spaceship.GetComponent<ShipControl>().Init();

            //start enemy and planet spawner
            EnemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
            Planet_1Spawner.GetComponent<Planet_1Spawner>().SchedulePlanetSpawner();
            break;

        case GameManagerState.GameOver:
            //stop enemy and planet spawner
            EnemySpawner.GetComponent<EnemySpawner>().StopEnemySpawner();
            Planet_1Spawner.GetComponent<Planet_1Spawner>().StopPlanetSpawner();

            //display gameover text
            GameOver.SetActive(true);
            
            //change game manager state to opening state after 8 seconds
            Invoke("ChangeToOpeningState", 8f);
            break;
        }
    }

    public void SetGMState(GameManagerState state)
    {
        GMState = state;
        UpdateGMState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGMState();
    }

    public void ChangeToOpeningState()
    {
        SetGMState(GameManagerState.Opening);
    }
}
