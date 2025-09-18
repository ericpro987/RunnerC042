using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI pointsText;
    [SerializeField]
    TextMeshProUGUI roundsText;
    [SerializeField]
    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager.changePoints += changePointsText;
        gameManager.changeRoundText += changeRoundsText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void changePointsText(int points)
    {
        pointsText.text = $"Points: {points}";
    }
    private void changeRoundsText(int round)
    {
        roundsText.gameObject.SetActive(true);
        roundsText.text = $"Round {round}";
        StartCoroutine(desactiveRoundText());
    }
    IEnumerator desactiveRoundText()
    {
        yield return new WaitForSeconds(2);
        roundsText.gameObject.SetActive(false);
    }
}
