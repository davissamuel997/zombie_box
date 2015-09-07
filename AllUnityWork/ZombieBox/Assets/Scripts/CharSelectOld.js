#pragma strict
import UnityEngine.UI;

public static var selected : GameObject;
public var canvasGroup : CanvasGroup;


function Update() 
{ 
	if (Input.GetMouseButtonUp (0)) 
	{
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		var hit : RaycastHit;
		
		if (Physics.Raycast (ray, hit, 100))
		{			
			var found = GameObject.Find(hit.collider.name);
			if(found.GetComponentInParent(Animator))
			{
				if(selected)
				{
					selected.GetComponentInParent(Animator).SetBool("selected", false);
				} 
				else 
				{ 
					canvasGroup.interactable = true;
        		 	canvasGroup.blocksRaycasts = true;
         			canvasGroup.alpha = 1; 
         		}
				selected = found;
				selected.GetComponentInParent(Animator).SetBool("selected", true);
				Debug.Log(selected);
			}
		}
	}
}