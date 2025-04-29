using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Data/Level Game Play Data")]
public class LevelGamePlaySO : ScriptableObject
{
    public LevelSpawnData levelSpawnData;
    public MissionSO missionData;
    public float timeToComplete;
}
