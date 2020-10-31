using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPiece : MonoBehaviour
{
    public enum ColorType
    {
        YELLOW,
        PURPLE,
        RED,
        BLUE,
        GREEN,
        PINK,
        ANY,
        COUNT
    }
    [Serializable]
    public struct ColorSprite
    {
        public ColorType color;
        public Sprite sprite;
    }
    public ColorSprite[] colorSprites;
    private SpriteRenderer sprite;
    private Dictionary<ColorType, Sprite> colorSPriteDict;
    private ColorType color;

    public ColorType Color
    {
        get
        {
            return color;
        }
        set
        {
            SetColor(value);
        }
    }

    public void SetColor(ColorType value)
    {
        color = value;
        if (colorSPriteDict.ContainsKey(value))
        {
            sprite.sprite = colorSPriteDict[value];
        }
    }

    private void Awake()
    {
        sprite = transform.Find("piece").GetComponent<SpriteRenderer>();
        colorSPriteDict = new Dictionary<ColorType, Sprite>();
        foreach (var sprite in colorSprites)
        {
            if (colorSPriteDict.ContainsKey(sprite.color))
                continue;
            colorSPriteDict.Add(sprite.color, sprite.sprite);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int NumColors
    {
        get { return colorSprites.Length; }
    }

    internal static ColorType GetRandom() => (ColorType)(UnityEngine.Random.Range(0, Enum.GetValues(typeof(ColorType)).Length));
}
