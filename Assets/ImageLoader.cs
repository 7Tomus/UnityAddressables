using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour {

	public AssetReferenceSprite imageToLoad;

	void Start () {
		imageToLoad.LoadAsset().Completed += (op) =>
		{
			GetComponent<Image>().sprite = op.Result;
		};
	}
}
