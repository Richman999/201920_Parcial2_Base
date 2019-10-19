using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public delegate void OnTaggedChange(string newTagged);

    public event OnTaggedChange onTaggedChange;

    [SerializeField]
    private float playTime = 60F;

    [SerializeField]
    private int playerCount = 4;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private bool instantiateHumanPlayer = true;


    private int targetPlayer;


    private Dictionary<string, int> taggedScore = new Dictionary<string, int>();

    public string GetWinner()
    {
        
        return string.Empty;
    }

    private void Start()
    {
        targetPlayer = Random.Range(1, 5);
        for (int i = 0; i < playerCount; i++)
        {
            string prefabPath = i == 0 && instantiateHumanPlayer ? "HumanPlayer" : "AIPlayer";

            GameObject playerInstance = Instantiate(Resources.Load<GameObject>(prefabPath), new Vector3(i+i,0f,0f), Quaternion.identity);
            playerInstance.name = string.Format("Player{0}", i + 1);

            taggedScore.Add(playerInstance.name, 0);
            playerInstance.GetComponent<PlayerController>().eventoOnTagge += UpdateTaggedScore;
            if (i == targetPlayer)
            {
                playerInstance.GetComponent<PlayerController>().IsTagged = true;
            }
        }

        Invoke("EndGame", playTime);
    }

    private void EndGame()
    {
        onTaggedChange -= UpdateTaggedScore;
    }

    private void UpdateTaggedScore(string newTaggedPlayer)
    {
        taggedScore[newTaggedPlayer] += 1;
    }


}