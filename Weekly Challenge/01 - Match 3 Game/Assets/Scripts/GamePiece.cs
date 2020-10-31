using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    private int y;
    private int x;
    private MovablePiece movableComponent;

    public MovablePiece MovableComponent
    {
        get
        {
            return movableComponent;
        }
    }
    private ColorPiece coloredComponent;

    public ColorPiece ColoredComponent
    {
        get
        {
            return coloredComponent;
        }
    }
    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            if (IsMovable())
            {
                y = value;
            }
        }
    }
    public Grid GridRef { get; private set; }
    public int X
    {
        get
        {
            return x;
        }
        set
        {
            if (IsMovable())
            {
                x = value;
            }
        }
    }
    public Grid.PieceType Type { get; private set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
        coloredComponent = GetComponent<ColorPiece>();
    }

    public void Init(int x, int y, Grid grid, Grid.PieceType pieceType)
    {
        this.x = x;
        this.y = y;
        GridRef = grid;
        Type = pieceType;
    }

    public bool IsMovable()
    {
        return movableComponent != null;
    }

    public bool IsColored()
    {
        return coloredComponent != null;
    }
}
