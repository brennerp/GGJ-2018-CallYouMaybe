
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Script for writing any useful Extension Methods

public static class ExtensionMethods {

	#region Transform extensions
	public static void ResetTransform (this Transform target) {
		target.position = Vector3.zero;
		target.localRotation = Quaternion.identity;
		target.localScale = new Vector3 (1, 1, 1);
	}

	public static Vector2 GetPositionWithSpriteOffset (this Transform target, Vector2 offset) {
		if (!target.GetComponentInChildren<SpriteRenderer>()) {
			return Vector2.zero;
		}

		offset = offset.ClampValues(-1, 1);

		Sprite sprite = target.GetComponentInChildren<SpriteRenderer>().sprite;
		Vector2 spriteOffset = new Vector2 ((offset.x * sprite.rect.size.y * target.lossyScale.y)/(sprite.pixelsPerUnit * 2), 
			(offset.y * sprite.rect.size.y * target.lossyScale.y)/(sprite.pixelsPerUnit * 2));
		Vector2 finalPosition = target.position.xy() + spriteOffset;
		return finalPosition;
	}
	#endregion

	#region RectTransform extensions
	public static Rect RectTransformToScreenRect (this RectTransform target) {
		Vector2 size = Vector2.Scale (target.rect.size, target.lossyScale);
		float rectX = target.position.x - (target.pivot.x * size.x);
		float rectY = Screen.height - target.position.y - (target.pivot.y * size.y);
		return new Rect (rectX, rectY, size.x, size.y);
	}

	public static RectTransform GetParentCanvas (this RectTransform target) {
		return target.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
	}

	public static Vector2 WorldToScreenRectTransformPoint (this RectTransform target, Vector2 point) {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (point);
		Vector2 pointOnRect = Vector2.Scale (screenPosition, target.sizeDelta);
		pointOnRect.x /= Screen.width;
		pointOnRect.y /= Screen.height;
		return pointOnRect;
	}

	public static void AdjustRectPositionToParent (this RectTransform target, RectTransform parent, Vector2 margin) {
		target.anchorMin = Vector2.zero;
		target.anchorMax = Vector2.zero;
		target.pivot = new Vector2 (0.5f, 0.5f);

		Vector2 targetSize = target.sizeDelta;
		Vector2 idealPosition = target.anchoredPosition;

		Vector2 minBounds = margin + targetSize/2;
		Vector2 maxBounds = parent.sizeDelta - minBounds;

		idealPosition.x = Mathf.Clamp (idealPosition.x, minBounds.x, maxBounds.x);
		idealPosition.y = Mathf.Clamp (idealPosition.y, minBounds.y, maxBounds.y);

		target.SetPosition (idealPosition);
	}

	public static void SetPosition (this RectTransform target, Vector2 anchoredPosition) {
		target.anchoredPosition = anchoredPosition;
	}

	public static void SetSize (this RectTransform target, Vector2 sizeDelta) {
		target.sizeDelta = sizeDelta;
	}

	public static void SetMargin (this RectTransform target, Vector2 margin) {
		target.offsetMin = margin;
		target.offsetMax = -margin;
	}
	#endregion

	#region Vector2 and Vector3 extensions
	public static Vector2 ClampValues (this Vector2 target, int x, int y) {
		target.x = Mathf.Clamp (target.x, -1f, 1f);
		target.y = Mathf.Clamp (target.y, -1f, 1f);
		return target;
	}

	public static Vector2 xy (this Vector3 target) {
		return new Vector2 (target.x, target.y);
	}
	#endregion

	#region String extensions
	public static bool IsBlank (this string target) {

		if (target != null) {
			foreach (char c in target) {
				if (c != ' ')
					return false;
			}
		}

		return true;
	}

	public static bool IsTwineActionList (this string target) {
		if (target != null) {
			if (target[0] == '<' || target[target.Length - 1] == '>') {
				return true;
			}
		}

		return false;
	}

	public static List<int> ToListOfIntegers (this string target) {
		List<int> numberList = new List<int>();
		string [] allNumberStrings = target.Split (',');
		foreach (string numberString in allNumberStrings) {
			int integer = 0;
			int.TryParse(numberString, out integer);
			numberList.Add (integer);
		}
		return numberList;
	}

	public static int InstancesOf (this string target, char character) {
		int count = 0;
		foreach (char c in target) {
			if (c == character) {
				count++;
			}
		}
		return count;
	}
	#endregion

	#region List extensions
	public static string ToString (this List<int> target) {
		string s = "";
		foreach (int i in target) {
			s+=  i + ",";
		}
		return s;
	}
	#endregion
}
