using Game.Director;
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

				// クリック先にオブジェクトがある かつオブジェクトがターゲットだった時
				if (hit2d && hit2d.collider.gameObject == gameObject)
				{
					Vector2[] positions = GameDirector.instance.currentCharacter.positions;
					GameDirector.instance.NextPosition();
					if (GameDirector.instance.currentPositionIndex <= positions.Length - 1)
					{
						// ターゲットを移動する
						transform.GetComponent<RectTransform>().anchoredPosition = GameDirector.instance.GetPosition();
					}
					else
					{
						// ポジションをリセットする
						GameDirector.instance.ResetPosition();
						// オブジェクトを消す
						Destroy(gameObject);
					}
				}
			}
		}
	}
}
