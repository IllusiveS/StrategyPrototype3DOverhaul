using UnityEngine;
using System.Collections;
using Zenject;

public class PlayerColorSelector : MonoBehaviour {

    MeshRenderer[] meshRenderer;

	[Inject]
	GameControl control;

	Army army;

	void Start()
	{
		army = GetComponent<UArmy> ().army;
	}
	void Update()
    {
		meshRenderer = GetComponentsInChildren<MeshRenderer>();
		foreach(MeshRenderer ren in meshRenderer)
		{
			ren.material.color = control.getPlayer(army.getPlayer()).playerColor;
		}
    }

}
