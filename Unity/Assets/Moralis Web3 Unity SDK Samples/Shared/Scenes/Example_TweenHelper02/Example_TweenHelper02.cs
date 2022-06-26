using System.Collections.Generic;
using System.Linq;
using MoralisUnity.Samples.Shared.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MoralisUnity.Samples.Shared.Templates
{
	/// <summary>
	/// Demonstrate the <see cref="TweenHelper"/>
	/// </summary>
	public class Example_TweenHelper02 : MonoBehaviour
	{
		// Properties -------------------------------------
		
		
		// Fields -----------------------------------------
		[SerializeField] 
		private List<GameObject> _cubes = null;
		
		[SerializeField] 
		private List<Button> _buttons = null;

		private const float Duration = 0.5f;
		
		// Unity Methods ----------------------------------
		protected void Start()
		{
			for (int i = 0; i < _buttons.Count; i++)
			{
				Button button = _buttons[i];
				GameObject cube = _cubes[i];

				switch (i)
				{
					case 0:
						button.GetComponentInChildren<TMP_Text>().text = "CustomAddGameObjectToMap";
						button.onClick.AddListener(() => 
						{
							TweenHelper.GameObjectFallsIntoPosition(
								cube, 
								new Vector3(0, 2, 0), 
								Duration
							);
						});
						break;
					
					case 1:
						button.GetComponentInChildren<TMP_Text>().text = "GameObjectSpawns";
						button.onClick.AddListener(() => 
						{
							TweenHelper.GameObjectSpawns(
								cube, 
								Duration
							);
						});
						break;
					
					case 2:
						button.GetComponentInChildren<TMP_Text>().text = "GameObjectDespawns";
						button.onClick.AddListener(() =>
						{
							// Setup demo so its repeatable. Its ok that this is here and not inside the Tweenhelper
							cube.transform.localScale = new Vector3(1, 1, 1);
							
							// Do demo
							TweenHelper.GameObjectDespawns(
								cube, 
								Duration
							);
						});
						break;
					
					case 3:
						break;
					
					case 4:
						break;
					case 5:
						break;
				}
	
			}
		}

		
		// General Methods --------------------------------

		
		// Event Handlers ---------------------------------
		
	}
}
