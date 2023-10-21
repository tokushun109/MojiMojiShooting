using UnityEngine;

namespace Target.Generator
{
	public partial class TargetGenerator : MonoBehaviour
	{
		[SerializeField, Header("キャンバスのゲームオブジェクト")] GameObject canvasObj;
		[SerializeField, Header("ターゲットのゲームオブジェクト")] GameObject targetObj;
	}
}
