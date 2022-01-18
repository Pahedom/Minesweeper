using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour
{
    GridGenerator gridGenerator;
    
    Vector3 beginnerParameters = new Vector3(9, 9, 10);
    Vector3 intermediateParameters = new Vector3(16, 16, 40);
    Vector3 specialistParameters = new Vector3(30, 16, 99);
    Vector3 customParameters;

    public Button beginnerButton;
    public Button intermediateButton;
    public Button specialistButton;
    public Button customButton;

    public GameObject customInputs;
    
    public InputField widthInput;
    public InputField heightInput;
    public InputField minesInput;

    public static string parameters;

    private void Start()
    {
        Debug.Log("Top Menu");
        
        gridGenerator = FindObjectOfType<GridGenerator>();

        if (GridGenerator.width == 0 && GridGenerator.height == 0 && GridGenerator.mines == 0)
        {
            ChangeToBeginner();
        }

        beginnerButton.interactable = parameters != "beginner";
        intermediateButton.interactable = parameters != "intermediate";
        specialistButton.interactable = parameters != "specialist";
        customButton.interactable = parameters != "custom";
        customInputs.SetActive(parameters == "custom");

        widthInput.text = GridGenerator.width.ToString();
        heightInput.text = GridGenerator.height.ToString();
        minesInput.text = GridGenerator.mines.ToString();
    }

    public void ChangeToBeginner()
    {
        gridGenerator.ChangeGridParameters(beginnerParameters);

        parameters = "beginner";
    }

    public void ChangeToIntermediate()
    {
        gridGenerator.ChangeGridParameters(intermediateParameters);

        parameters = "intermediate";
    }

    public void ChangeToSpecialist()
    {
        gridGenerator.ChangeGridParameters(specialistParameters);

        parameters = "specialist";
    }

    public void ChangeToCustom()
    {
        if (widthInput.text == "" || heightInput.text == "" || minesInput.text == "")
        {            
            return;
        }
        
        customParameters.x = int.Parse(widthInput.text);
        customParameters.y = int.Parse(heightInput.text);
        customParameters.z = int.Parse(minesInput.text);
        
        gridGenerator.ChangeGridParameters(customParameters);
    }

    public void OpenCustomParameters()
    {
        parameters = "custom";

        customInputs.SetActive(true);
        
        beginnerButton.interactable = true;
        intermediateButton.interactable = true;
        specialistButton.interactable = true;
        customButton.interactable = false;
    }
}
