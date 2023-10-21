using UnityEngine;

namespace Target.Controller
{
	public partial class TargetController : MonoBehaviour
	{
		// 現在のターゲット位置のインデックス番号
		public int currentPositionIndex { get; private set; } = 0;
	}
}
