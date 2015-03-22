using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AdvancedInspector;

[AdvancedInspector]
public class GraphicsDisplay : MonoBehaviour {

	public Sprite emptyUnit;

    UUnit unitToDisplay;

    // Use this for initialization
    void Start()
    {
        unitToDisplay = GetComponentInParent<UnitDisplayer>().unitToDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        unitToDisplay = GetComponentInParent<UnitDisplayer>().unitToDisplay;
    }

    public UUnit getUnitToDisplay()
    {
        return unitToDisplay;
    }
}
