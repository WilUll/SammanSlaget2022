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
		if (Input.GetMouseButtonDown(0)) 
		{
			// Starting to showing trajectory
		
			// Taking first point on screen for force vector
			_startPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 10f);
			if (Physics.Raycast(ray, out hit, 1000))
			{
				Debug.Log(hit.transform.name);
				if (hit.transform.gameObject.GetComponent<Throwable>())
				{
					objectToThrow = hit.transform.gameObject.GetComponent<Throwable>();
				}
			}
		}

        if (Input.GetMouseButton(0) && objectToThrow != null) 
        {
			_endPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			
			Vector3 direction = (_startPos - _endPos).normalized;
			float distance = Vector2.Distance(_startPos, _endPos);
			
			_forcevector = direction * distance * pushForce;
			_forcevector.z = _forcevector.y * zMultiplier;
			_forcevector = Vector3.ClampMagnitude(_forcevector, maxForce);
			_forcevector.y = 0;
			
			Debug.Log(_forcevector);

		}

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
