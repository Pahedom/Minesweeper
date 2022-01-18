using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDrawer : MonoBehaviour
{
    GridGenerator gridGenerator;

    public static int[,] tileValues;

    private void Start()
    {
        Debug.Log("Mine Drawer");
        
        gridGenerator = FindObjectOfType<GridGenerator>();

        tileValues = new int[GridGenerator.width, GridGenerator.height];

        DrawMinePositions();

        gridGenerator.PlaceTilesContent(tileValues);
    }

    void DrawMinePositions()
    {
        Vector2 position;
        
        for (int i = 0; i < GridGenerator.mines; i++)
        {
            // Draw mine position on the grid
            
            do
            {
                position = new Vector2(Random.Range(0, tileValues.GetLength(0)), Random.Range(0, tileValues.GetLength(1)));
            }
            while (tileValues[(int)position.x, (int)position.y] == -1);

            tileValues[(int)position.x, (int)position.y] = -1;

            // Set the numbers on the tiles around the mine

            if (position.x > 0)
            {
                if (position.y > 0 && tileValues[(int)position.x - 1, (int)position.y - 1] >= 0)
                {
                    tileValues[(int)position.x - 1, (int)position.y - 1]++;
                }
                if (tileValues[(int)position.x - 1, (int)position.y] >= 0)
                {
                    tileValues[(int)position.x - 1, (int)position.y]++;
                }
                if (position.y < GridGenerator.height - 1 && tileValues[(int)position.x - 1, (int)position.y + 1] >= 0)
                {
                    tileValues[(int)position.x - 1, (int)position.y + 1]++;
                }
            }
            if (position.x < GridGenerator.width - 1)
            {
                if (position.y > 0 && tileValues[(int)position.x + 1, (int)position.y - 1] >= 0)
                {
                    tileValues[(int)position.x + 1, (int)position.y - 1]++;
                }
                if (tileValues[(int)position.x + 1, (int)position.y] >= 0)
                {
                    tileValues[(int)position.x + 1, (int)position.y]++;
                }
                if (position.y < GridGenerator.height - 1 && tileValues[(int)position.x + 1, (int)position.y + 1] >= 0)
                {
                    tileValues[(int)position.x + 1, (int)position.y + 1]++;
                }
            }
            if (position.y > 0 && tileValues[(int)position.x, (int)position.y - 1] >= 0)
            {
                tileValues[(int)position.x, (int)position.y - 1]++;
            }
            if (position.y < GridGenerator.height - 1 && tileValues[(int)position.x, (int)position.y + 1] >= 0)
            {
                tileValues[(int)position.x, (int)position.y + 1]++;
            }
        }
    }
}
