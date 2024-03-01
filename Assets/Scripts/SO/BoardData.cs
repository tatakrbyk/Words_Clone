using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[System.Serializable]
[CreateAssetMenu(fileName = "Puzzle", menuName = " SO / Board Data")]
public class BoardData : ScriptableObject
{
    [System.Serializable]
    public class SearchingWord
    {
        [HideInInspector]
        public bool found = false;
        public string word;
    }

    [System.Serializable]
    public class BoardRow
    {
        public int _size;
        public string[] Row;
        
        public BoardRow() { }   

        public BoardRow(int size)
        {
            CreateRow(size);
        }

        public void CreateRow(int size)
        {
            _size = size;
            Row = new string[_size];
            ClearRow();
        }

        public void ClearRow() 
        {
            for(int i = 0; i < _size; i++)
            {
                Row[i] = "";
            }
        }
    }

    public float timeInSeconds;
    public int columns = 0;
    public int rows = 0;

    public BoardRow[] Board;
    public List<SearchingWord> SearchWords = new List<SearchingWord>();

    public void ClearData()
    {
        foreach(var word in SearchWords)
        {
            word.found = false; 
        }
    }

    public void ClearWithEmptyString()
    {
        for(int i = 0; i < columns; i++)
        {
            Board[i].ClearRow();
        }
    }

    public void CreateNewBoard()
    {
        Board = new BoardRow[columns];
        for (int i = 0; i < columns; i++)
        {
            Board[i] = new BoardRow(rows);
        }

    }
}
