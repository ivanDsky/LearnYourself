using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public ScoreController scoreController;

    public void ScoreUpdate(float val)
    {
        scoreController.ScoreAdd(val);
    }
    
    public void AllScoreUpdate(float val)
    {
        scoreController.AllScoreAdd(val);
    }
}