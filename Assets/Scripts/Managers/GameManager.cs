using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int points;
    [SerializeField]
    public int round { get; private set; }
    public delegate void ChangeRound();
    public ChangeRound changeRound;
    public delegate void ChangeRoundText(int round);
    public ChangeRoundText changeRoundText;
    public delegate void ChangePoints(int points);
    public ChangePoints changePoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = 0;
        round = 1;
        StartCoroutine(Points());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Points()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            points++;
            changePoints.Invoke(points);
            if (points % 100 == 0)
            {
                round++;
                changeRound.Invoke();
                changeRoundText.Invoke(round);
            }
        }
    }
}
