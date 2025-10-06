using System;
using System.Collections.Generic;

[Serializable]
public class PlayerStatsDefaultData
{
    public List<PlayerStatData> listStats;
}

[Serializable]
public class PlayerStatData
{
    public StatType type;
    public float value;
}