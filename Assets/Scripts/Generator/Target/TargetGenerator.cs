using UnityEngine;

namespace Target.Generator
{
	public partial class TargetGenerator : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			Application.targetFrameRate = 60;
			// TODO ここで文字に応じた初期値を入れる
			// TODO 現状はworld座標だが、スクリーンでずれないようにしたい
			Instantiate(targetObj, new Vector3(-1.35f, 1, 0), Quaternion.identity);
		}
	}
}
