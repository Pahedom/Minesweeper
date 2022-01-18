using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileProperties : MonoBehaviour
{
    public Vector2 myPosition;

    GridController gridController;

    private void Start()
    {
        gridController = FindObjectOfType<GridController>();
    }

    public void OpenTile(bool checkForMine)
    {
        if (MineDrawer.tileValues[(int)myPosition.x, (int)myPosition.y] == -1)
        {
            gridController.GameOver(myPosition);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
