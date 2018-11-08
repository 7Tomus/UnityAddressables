using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour {

	public Slider downloadProgressBar;

	private void Start()
	{
		StartCoroutine(DownloadAsset("bg2"));
	}

	IEnumerator DownloadAsset(string assetName)
	{
		var operation = Addressables.LoadAsset<Sprite>(assetName);
		StartCoroutine(ShowProgress(operation));
		operation.Completed += assign =>
		{
			GetComponent<Image>().sprite = assign.Result;
		};
		yield return null;
	}

	IEnumerator ShowProgress(UnityEngine.ResourceManagement.IAsyncOperation<Sprite> op)
	{
		while(!op.IsDone)
		{
			downloadProgressBar.value = op.PercentComplete;
			yield return new WaitForEndOfFrame();
		}
	}
}
