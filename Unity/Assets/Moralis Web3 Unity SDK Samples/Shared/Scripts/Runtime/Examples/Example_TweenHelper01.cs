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
	public class Example_TweenHelper01 : MonoBehaviour
	{
		// Properties -------------------------------------
		
		
		// Fields -----------------------------------------
		[SerializeField] 
		private List<GameObject> _cubes = null;
		
		[SerializeField] 
		private List<Button> _buttons = null;

		[SerializeField] 
		private Image _image01 = null;

		[SerializeField] 
		private List<CanvasGroup> _canvasGroups = null;

		private const float DelayStart = 0;
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
						button.GetComponentInChildren<TMP_Text>().text = "TransformDoScale";
						button.onClick.AddListener(() => 
						{
							TweenHelper.TransformDoScale(cube, 
								new Vector3(1,1,1), 
								new Vector3(2,2,2), 
								Duration,
								DelayStart
							);
						});
						break;
					
					case 1:
						button.GetComponentInChildren<TMP_Text>().text = "TransformDOBlendableMoveBy";
						button.onClick.AddListener(() => 
						{
							TweenHelper.TransformDOBlendableMoveBy(
								cube,
								cube.transform.position, 
								new Vector3(0.05f, 0, 0), 
								Duration,
								DelayStart
							);
						});
						break;
					
					case 2:
						button.GetComponentInChildren<TMP_Text>().text = "RenderersDoFade";
						button.onClick.AddListener(() => 
						{
							Debug.Log(cube.GetComponentsInChildren<Renderer>().ToList().Count);
							TweenHelper.RenderersDoFade(
								cube.GetComponentsInChildren<Renderer>().ToList(),
								1,
								0,
								Duration,
								DelayStart
							);
						});
						break;
					
					case 3:
						button.GetComponentInChildren<TMP_Text>().text = "ImageDoFade";
						button.onClick.AddListener(() => 
						{
							TweenHelper.ImageDoFade(
								_image01,
								1,
								0,
								Duration,
								DelayStart
							);
						});
						break;
					
					case 4:
						button.GetComponentInChildren<TMP_Text>().text = "CanvasGroupsDoFade";
						button.onClick.AddListener(() => 
						{
							TweenHelper.CanvasGroupsDoFade(
								_canvasGroups,
								1,
								0,
								Duration,
								DelayStart,
								0.25f
							);
						});
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
