using Unity.VisualScripting;
using UnityEngine;

namespace Target.Controller
{
	public partial class TargetController : MonoBehaviour
	{
		// Start is called before the first frame update
		// void Start()
		// {

		// }

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButtonDown((int)MouseButton.Left))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

				if (hit2d && hit2d.collider.gameObject == gameObject)
				{
					Debug.Log(hit2d.transform.gameObject.name);
					// TODO ターゲットを次の場所に移動する
					Destroy(hit2d.transform.gameObject);
				}
			}
		}
	}
}
