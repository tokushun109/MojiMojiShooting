using UnityEngine;

namespace Target.Generator
{
	public partial class TargetGenerator : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			Application.targetFrameRate = 60;
			GameObject target = Instantiate(targetObj);
			target.transform.SetParent(canvasObj.transform, false);
			target.GetComponent<RectTransform>().anchoredPosition = new Vector2(-220, 170);
		}
	}
}
