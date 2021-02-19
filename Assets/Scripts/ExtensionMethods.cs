using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
	private static System.Random _random = new System.Random ();

	public static float Remap (this float value, float from1, float to1, float from2, float to2)
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

	public static void Shuffle<T> (this T[] array)
	{
		int p = array.Length;
		for (int n = p - 1; n > 0; n--) {
			int r = _random.Next (0, n);
			T t = array [r];
			array [r] = array [n];
			array [n] = t;
		}
	}

	public static void PrintArray<T> (this T[] array)
	{
		Debug.Log (string.Join (" - ",
			new System.Collections.Generic.List<T> (array)
			.ConvertAll (i => i.ToString ())
			.ToArray ()));
	}

	public static void MapArrayToArray (this float[] _out, float[] _in)
	{
		if (_in.Length == _out.Length) {
			_out = _in;
		} else {
			for (float i = 0; i < _out.Length; i = i + 1) {
				float index = i.Remap (0.0f, _out.Length, 0.0f, _in.Length);
				float indexBase = Mathf.Floor (index);
				float indexLerp = index - indexBase;
				_out [(int)i] = Mathf.Lerp (_in [(int)indexBase], _in [(int)Mathf.Clamp (indexBase + 1, 0, _in.Length - 1)], indexLerp);
			}
		}
	}
}
