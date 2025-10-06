using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class LevelConfig : ScriptableObject
{
    public List<Stage> stages;

    public RoomType GetRoomTypeByStageType(StageType stageType)
    {
        List<RoomType> possibleRooms = stages.Where(x => x.stageType == stageType).FirstOrDefault().possibleRooms;
        return possibleRooms.ElementAt(Random.Range(0, possibleRooms.Count));
    }
}

[Serializable]
public class Stage
{
    public StageType stageType;
    public List<RoomType> possibleRooms;
}

public enum RoomType
{
    None, Enemy, Treasure, Boss
}

public enum StageType
{
    None, One, Two, Three, Four
}