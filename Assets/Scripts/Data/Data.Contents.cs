using System;
using System.Collections.Generic;

#region Stat
// 데이터 모델 == 직렬화 라는 부분 나오면 굉장히 굉장히 집중해서 들으세요!!!!!!!! <- 핵중요
[Serializable]
public class Stat
{
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class StatData : ILoader<int, Stat>
{
    public List<Stat> stats = new List<Stat>();

    public Dictionary<int, Stat> MakeDict()
    {
        Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
        foreach (Stat stat in stats)
            dict.Add(stat.level, stat);

        return dict;
    }
}
#endregion

