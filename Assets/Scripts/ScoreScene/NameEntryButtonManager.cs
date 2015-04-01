using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class NameEntryButtonManager : MonoBehaviour {

    public float numberOfButtonsPerRow = 8;
    public const string charactersToRepresent = "abcdefghijklmnopqrstuvwxyz .,!_-~+@#";

    public GridGenerator gridGenerator;
    public Button buttonPrefab;
    public Button deleteButtonPrefab;
    public Button EnterButtonPrefab;

    public StringBuilder stringBuilder;

    private Vector3 dimensionsOfPrefab;

	// Use this for initialization
	void Start () {

        int _instantiatedButtons = 0;

        List<Vector3> _coordinateList = gridGenerator.GenerateGridCoordinates((uint) numberOfButtonsPerRow, (uint) 6, buttonPrefab.gameObject);
        Button _newButton;
        foreach (char _char in charactersToRepresent)
        {
            _newButton = (Instantiate(buttonPrefab.gameObject) as GameObject).GetComponent<Button>();
            _newButton.transform.SetParent(this.transform, false);
            _newButton.name = _char.ToString();
            _newButton.GetComponentInChildren<Text>().text = _char.ToString();
            
            dimensionsOfPrefab = _newButton.collider.bounds.size;

            _newButton.GetComponent<RectTransform>().localPosition +=  Vector3.Scale( _coordinateList[_instantiatedButtons], _newButton.transform.localScale);

            NameEntryButton _buttonComponent = _newButton.GetComponent<NameEntryButton>();
            _buttonComponent.stringSnippet = _char.ToString();
            _buttonComponent.stringBuilder = stringBuilder;

            //_newButton.transform.localScale = Vector3.one;

            _instantiatedButtons += 1;
        }
        #region Add Delete Button
        // Add delete button;
        _instantiatedButtons += 1;

        _newButton = (Instantiate(deleteButtonPrefab.gameObject) as GameObject).GetComponent<Button>();
        _newButton.transform.SetParent(this.transform, false);

        dimensionsOfPrefab = _newButton.collider.bounds.size;
        _newButton.GetComponent<RectTransform>().localPosition += Vector3.Scale(_coordinateList[_instantiatedButtons], _newButton.transform.localScale);

        NameEntryButton _deleteComponent = _newButton.GetComponent<NameEntryButton>();
        _deleteComponent.stringBuilder = stringBuilder;



        #endregion


    }
	



}
