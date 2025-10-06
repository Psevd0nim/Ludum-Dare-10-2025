using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class ViewConfig : ScriptableObject
{
    public List<RoomUIView> roomViewList;

    public Sprite GetSpriteByType(RoomType roomType)
    {
        return roomViewList.Where(x => x.type == roomType).FirstOrDefault().sprite;
    }

    public List<ReliqView> reliqSpriteList;

    public Sprite GetReliqSpriteByRandom()
    {
        return reliqSpriteList.ElementAt(Random.Range(0, reliqSpriteList.Count)).sprite;
    }
}

[Serializable]
public class RoomUIView
{
    public RoomType type;
    [PreviewField] public Sprite sprite;
}

[Serializable]
public class ReliqView
{
    [PreviewField] public Sprite sprite;
}