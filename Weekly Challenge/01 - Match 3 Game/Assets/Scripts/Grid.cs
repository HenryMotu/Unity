using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using System.Xml.Serialization;

public class Grid : MonoBehaviour
{

    public int xDim;
    public int yDim;
    public enum PieceType
    {
        NORMAL,
        COUNT,
    }

    [System.Serializable]
    public struct PiecePrefab
    {
        public PieceType type;
        public GameObject prefab;
    }
    public PiecePrefab[] piecePrefabs;
    private Dictionary<PieceType, GameObject> piecePrefabDict;
    public GameObject backgroundPrefab;
    private GamePiece[,] pieces;

    // Use this for initialization
    void Start()
    {
        piecePrefabDict = new Dictionary<PieceType, GameObject>();
        foreach (var item in piecePrefabs)
        {
            if (piecePrefabDict.ContainsKey(item.type)) continue;

            piecePrefabDict.Add(item.type, item.prefab);
        }

        for (int x = 0; x < xDim; x++)
        {
            for (int y = 0; y < yDim; y++)
            {
                var backtround = (GameObject)Instantiate(backgroundPrefab, GetWorldsPosition(x, y), Quaternion.identity);
                backtround.transform.parent = transform;
            }
        }

        pieces = new GamePiece[xDim, yDim];
        for (int x = 0; x < xDim; x++)
        {
            for (int y = 0; y < yDim; y++)
            {
                var newPiece = Instantiate<GameObject>(piecePrefabDict[PieceType.NORMAL], Vector3.zero, Quaternion.identity);
                newPiece.name = $"Piece ({x},{y})";
                newPiece.transform.parent = transform;

                pieces[x, y] = newPiece.GetComponent<GamePiece>();
                pieces[x, y].Init(x, y, this, PieceType.NORMAL);

                if (pieces[x, y].IsMovable())
                {
                    pieces[x, y].MovableComponent.Move(x, y);
                }

                if (pieces[x, y].IsColored())
                {
                    pieces[x, y].ColoredComponent.SetColor(ColorPiece.GetRandom());
                }

            }

        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 GetWorldsPosition(int x, int y)
    {
        return new Vector2(transform.position.x - xDim / 2.0f + x,
            transform.position.y + yDim / 2.0f - y);
    }
}
