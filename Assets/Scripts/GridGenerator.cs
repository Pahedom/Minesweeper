using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GridGenerator : MonoBehaviour
{
    RectTransform grid;

    int minWidth = 8;
    int maxWidth = 78;
    int minHeight = 1;
    int maxHeight = 39;

    public static int width;
    public static int height;
    public static int mines;

    int gridWidth;
    int gridHeight;

    int cornersWidth = 18;
    int topCornersHeight = 81;
    int bottomCornersHeight = 17;
    int tileSize = 24;

    public GameObject tileArea;
    
    public GameObject emptyTile;
    public GameObject tileCover;

    public static Image[,] tiles;
    
    public static Button[,] tileCovers;

    public Sprite[] tileSprites;
    public Sprite mineClickedSprite;

    private void Start()
    {
        Debug.Log("Grid Generator");

        grid = GetComponent<RectTransform>();

        SetGridSize();

        tiles = new Image[width, height];

        tileCovers = new Button[width, height];
    }

    void SetGridSize()
    {
        gridWidth = cornersWidth * 2 + tileSize * width;

        gridHeight = topCornersHeight + bottomCornersHeight + tileSize * height;

        grid.sizeDelta = new Vector2(gridWidth, gridHeight);
    }

    public void PlaceTilesContent(int[,] thisTiles)
    {
        Vector2 tilePosition;

        GameObject thisTile;
        GameObject thisCover;
        
        for (int i = 0; i < thisTiles.GetLength(0); i++)
        {
            for (int ii = 0; ii < thisTiles.GetLength(1); ii++)
            {
                tilePosition = new Vector2(i * tileSize, -ii * tileSize);

                // Instantiate tile
                
                thisTile = Instantiate(emptyTile, tileArea.transform);

                thisTile.GetComponent<RectTransform>().anchoredPosition = tilePosition;

                tiles[i, ii] = thisTile.GetComponent<Image>();

                // Change tile sprite according to its number
                
                if (thisTiles[i, ii] == -1)
                {
                    thisTile.GetComponent<Image>().sprite = tileSprites[0];
                }
                else if (thisTiles[i, ii] != 0)
                {
                    thisTile.GetComponent<Image>().sprite = tileSprites[thisTiles[i, ii]];
                }

                // Instantiate tile cover

                thisCover = Instantiate(tileCover, tileArea.transform);

                thisCover.GetComponent<RectTransform>().anchoredPosition = tilePosition;

                thisCover.GetComponent<TileProperties>().myPosition = new Vector2(i, ii);

                tileCovers[i, ii] = thisCover.GetComponent<Button>();
            }
        }
    }

    public void ChangeGridParameters(Vector3 newParameters)
    {
        if (newParameters.x < minWidth)
        {
            width = minWidth;
        }
        else if (newParameters.x > maxWidth)
        {
            width = maxWidth;
        }
        else
        {
            width = (int)newParameters.x;
        }
        
        if (newParameters.y < minHeight)
        {
            height = minHeight;
        }
        else if (newParameters.y > maxHeight)
        {
            height = maxHeight;
        }
        else
        {
            height = (int)newParameters.y;
        }
        
        if (newParameters.z < 1)
        {
            mines = 1;
        }
        else if (newParameters.z >= width * height)
        {
            mines = width * height - 1;
        }
        else
        {
            mines = (int)newParameters.z;
        }

        ReloadGrid();
    }

    public void ReloadGrid()
    {
        SceneManager.LoadScene(0);
    }
}