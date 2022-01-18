using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    public GameObject RestartButton;

    public Sprite mineClicked;
    
    public void GameOver(Vector2 tileOpened)
    {
        RestartButton.SetActive(false);

        for (int i = 0; i < MineDrawer.tileValues.GetLength(0); i++)
        {
            for (int ii = 0; ii < MineDrawer.tileValues.GetLength(1); ii++)
            {
                GridGenerator.tileCovers[i, ii].interactable = false;

                if (MineDrawer.tileValues[i, ii] == -1)
                {
                    GridGenerator.tileCovers[i, ii].gameObject.SetActive(false);
                }
            }
        }

        GridGenerator.tiles[(int)tileOpened.x, (int)tileOpened.y].sprite = mineClicked;
    }
}
