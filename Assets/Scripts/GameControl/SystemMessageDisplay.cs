using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SystemMessageDisplay : MonoBehaviour, IPointerClickHandler {

	protected GameControl control;

	protected Text[] texts;
	protected List<SystemMessage> messages = new List<SystemMessage>();

	// Use this for initialization
	void Start () {
		texts = GetComponentsInChildren<Text> ();
		foreach(Player pl in GetComponentInParent<GameControl>().playersList)
		{
			pl.addPointsToPlayerDelegate(createPointsMessage);
		}
	}
	
	// Update is called once per frame
	void Update () {
		try {
			texts [0].text = messages [0].ToString ();
		} catch (System.Exception ex) {
			texts [0].text = "";
		}
		try {
			texts [1].text = messages [1].ToString ();
		} catch (System.Exception ex) {
			texts [1].text = "";
		}
		if(messages.Count == 0)
			GetComponent<CanvasGroup>().alpha = 0;
		else
			GetComponent<CanvasGroup>().alpha = 1;
	}
	
	protected void createPointsMessage(int points, string reason, Player player)
	{
		messages.Add(new SystemMessage(points, reason, player));
	}

	#region IPointerClickHandler implementation

	public void OnPointerClick (PointerEventData eventData)
	{
		try
		{
			messages.RemoveAt(0);
			messages.RemoveAt(0);
		}
		catch(System.ArgumentOutOfRangeException)
		{
		}
	}

	#endregion
}
