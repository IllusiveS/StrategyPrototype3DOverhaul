using UnityEngine;
using System.Collections;
using Zenject;
using AdvancedInspector;

[AdvancedInspector]
public class RecruitmentCanvasInstaller : MonoInstaller {

	[Inspect]
	public GameObject recruitmentPrefab;
	
	public override void InstallBindings()
	{
		Container.Bind<RecruitmentDisplay> ().ToSingleFromPrefab<RecruitmentDisplay> (recruitmentPrefab);
	}
}
