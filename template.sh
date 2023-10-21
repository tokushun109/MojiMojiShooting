#!/bin/sh

# 第一引数: 作りたいオブジェクト(Player)
# 第二引数: オブジェクトの役割(Controller, Generator, Director)

# ディレクトリを作成
mkdir $1

# メインの処理ファイルを作成
touch "$1/$1$2.cs"
cat <<EOF>> "$1/$1$2.cs"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace $1.$2
{
	public partial class $1$2 : MonoBehaviour
	{
		// Start is called before the first frame update
		// void Start()
		// {

		// }

		// Update is called once per frame
		// void Update()
		// {

		// }
	}
}
EOF

# 定数のファイルを作成
touch "$1/Constant.cs"
cat <<EOF>> "$1/Constant.cs"
namespace $1.$2
{
	// public partial class $1$2 : MonoBehaviour
	// {
	// }
}
EOF

# Methodのファイルを作成
touch "$1/Method.cs"
cat <<EOF>> "$1/Method.cs"
using UnityEngine;

namespace $1.$2
{
	public partial class $1$2 : MonoBehaviour
	{
	}
}
EOF

# Propertyのファイルを作成
touch "$1/Property.cs"
cat <<EOF>> "$1/Property.cs"
using UnityEngine;

namespace $1.$2
{
	public partial class $1$2 : MonoBehaviour
	{
	}
}
EOF
