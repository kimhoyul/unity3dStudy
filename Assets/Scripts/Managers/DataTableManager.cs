using System;
using System.Collections.Generic;
using UnityEngine;

public class DataTableManager : MonoBehaviour
{
    private List<ChapterData> chapterDataTable = new List<ChapterData>();

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        LoadChapterDataTable();
    }

    private void LoadChapterDataTable()
    {
        var parseDataTable = CSVReader.Read("Data/ChapterDataTable");

        // parseDataTabled을 정보를 chapterDataTable에 채워주세요!

        foreach (var data in parseDataTable)
        {
            var chapterData = new ChapterData
            {
                chapterNo = Convert.ToInt32(data["chapter_no"]),
                totalStages = Convert.ToInt32(data["total_stages"]),
                chapterRewardGem = Convert.ToInt32(data["chapter_reward_gem"]),
                chapterRewardGold = Convert.ToInt32(data["chapter_reward_gold"]),
            };

            chapterDataTable.Add(chapterData);
        }
    }
}

// 데이터 모델
public class ChapterData
{
    public int chapterNo;
    public int totalStages;
    public int chapterRewardGem;
    public int chapterRewardGold;
}
