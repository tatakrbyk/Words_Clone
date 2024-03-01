using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Game Level Data", menuName = " SO / Game Level Data")]
public class GameLevelData : ScriptableObject
{
    [System.Serializable]
    public struct CategoryRecord
    {
        public string categoryName;
        public List<BoardData> boardData;
    }

    public List<CategoryRecord> data;
}
