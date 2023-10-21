using UnityEngine;

namespace Target.Generator
{
	public partial class TargetGenerator : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			Application.targetFrameRate = 60;
			Instantiate(targetObj, new Vector3(-1.35f, 1, 0), Quaternion.identity);
		}

		// Update is called once per frame
		// void Update()
		// {

		// }
	}
}
