using UnityEngine;

public class Swipe : MonoBehaviour 
{
	[SerializeField] protected float pushForce;
	[SerializeField] protected float maxForce;
	[SerializeField] [Range(0f, 10f)] protected float zMultiplier;
																	
	private Vector2 _startPos, _endPos;
	private Vector3 _forcevector;
	private Throwable objectToThrow;

	private void Update() {
		ControlSwipe();
	}

	private void ControlSwipe() {
		// Starting to drag
		

        

		if (Input.GetMouseButtonUp(0) && objectToThrow != null) 
		{
			if (objectToThrow) 
			{
				objectToThrow.Throw(-1 * _forcevector);
				objectToThrow = null;
			}
		}
	}
	
}
