using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UnityExtensions {
	public static Transform InstantiateAsChild(this Transform parent, Transform original) {
		Transform result = GameObject.Instantiate(original, parent.position, parent.rotation) as Transform;

		result.SetParent(parent);

		result.localScale = original.localScale;
		result.localPosition = original.localPosition;

		return result;
	}

	public static GameObject InstantiateAsChild(this Transform parent, GameObject original) {
		GameObject result = GameObject.Instantiate(original, parent.position, parent.rotation) as GameObject;

		result.transform.SetParent(parent);

		result.transform.localScale = original.transform.localScale;
		result.transform.localPosition = original.transform.localPosition;

		return result;
	}

	public static Component InstantiateAsChild(this Transform parent, Component original) {
		Component result = GameObject.Instantiate(original, parent.position, parent.rotation) as Component;
		if (result != null) {
			result.transform.SetParent(parent);

			result.transform.localScale = original.transform.localScale;
			result.transform.localPosition = original.transform.localPosition;
		}
		return result;
	}

	public static UnityEngine.Object InstantiateAsChild(this Transform parent, UnityEngine.Object original) {
		Transform originalTransform = null; {
			Component component = original as Component;
			if (component != null) {
				originalTransform = component.transform;
			} else {
				GameObject obj = original as GameObject;
				if (obj != null) {
					originalTransform = obj.transform;
				} else {
					Transform t = original as Transform;
					if (t != null) {
						originalTransform = t;
					}
				}
			}
		}

		UnityEngine.Object result = UnityEngine.Object.Instantiate(original, parent.position, parent.rotation);
		if (result != null) {
			Component component = result as Component;
			if (component != null) {
				component.transform.SetParent(parent);
				if (originalTransform != null) {
					component.transform.localScale = originalTransform.localScale;
					component.transform.localPosition = originalTransform.localPosition;
				}
			} else {
				GameObject obj = result as GameObject;
				if (obj != null) {
					obj.transform.SetParent(parent);
					if (originalTransform != null) {
						obj.transform.localScale = originalTransform.localScale;
						obj.transform.localPosition = originalTransform.localPosition;
					}
				} else {
					Transform t = result as Transform;
					if (t != null) {
						t.SetParent(parent);
						if (originalTransform != null) {
							t.localScale = originalTransform.localScale;
							t.localPosition = originalTransform.localPosition;
						}
					}
				}
			}
		}
		return result;
	}

	public static Transform InstantiateAsChild(this GameObject parent, Transform original) {
		Transform result = GameObject.Instantiate(original, parent.transform.position, parent.transform.rotation) as Transform;

		result.SetParent(parent.transform);

		result.localScale = original.localScale;
		result.localPosition = original.localPosition;

		return result;
	}

	public static GameObject InstantiateAsChild(this GameObject parent, GameObject original) {
		GameObject result = GameObject.Instantiate(original, parent.transform.position, parent.transform.rotation) as GameObject;

		result.transform.SetParent(parent.transform);

		result.transform.localScale = original.transform.localScale;
		result.transform.localPosition = original.transform.localPosition;

		return result;
	}

	public static Component InstantiateAsChild(this GameObject parent, Component original) {
		Component result = GameObject.Instantiate(original, parent.transform.position, parent.transform.rotation) as Component;
		if (result != null) {
			result.transform.SetParent(parent.transform);

			result.transform.localScale = original.transform.localScale;
			result.transform.localPosition = original.transform.localPosition;
		}
		return result;
	}

	public static UnityEngine.Object InstantiateAsChild(this GameObject parent, UnityEngine.Object original) {
		Transform originalTransform = null; {
			Component component = original as Component;
			if (component != null) {
				originalTransform = component.transform;
			} else {
				GameObject obj = original as GameObject;
				if (obj != null) {
					originalTransform = obj.transform;
				} else {
					Transform t = original as Transform;
					if (t != null) {
						originalTransform = t;
					}
				}
			}
		}

		UnityEngine.Object result;
		if (originalTransform != null) {
			result = UnityEngine.Object.Instantiate(original, originalTransform.position, originalTransform.rotation);
		} else {
			result = UnityEngine.Object.Instantiate(original);
		}
		if (result != null) {
			Component component = result as Component;
			if (component != null) {
				component.transform.SetParent(parent.transform);
				if (originalTransform != null) {
					component.transform.localScale = originalTransform.localScale;
					component.transform.localPosition = originalTransform.localPosition;
				}
			} else {
				GameObject obj = result as GameObject;
				if (obj != null) {
					obj.transform.SetParent(parent.transform);
					if (originalTransform != null) {
						obj.transform.localScale = originalTransform.localScale;
						obj.transform.localPosition = originalTransform.localPosition;
					}
				} else {
					Transform t = result as Transform;
					if (t != null) {
						t.SetParent(parent.transform);
						if (originalTransform != null) {
							t.localScale = originalTransform.localScale;
							t.localPosition = originalTransform.localPosition;
						}
					}
				}
			}
		}
		return result;
	}

	public static void DestroyAllChildren(this Transform trans) {
		List<GameObject> children = new List<GameObject>();
		foreach (Transform child in trans)
			children.Add(child.gameObject);

		children.ForEach(delegate(GameObject child) {
			child.transform.SetParent(null);
			GameObject.Destroy(child);
		});
	}

	public static uint UnixTimestamp(this DateTime dateTime) {
		return (uint) (dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
	}

	public static void ChangeLayer(this GameObject obj, int layer) {
		foreach (Transform trans in obj.GetComponentsInChildren<Transform>(true))
			trans.gameObject.layer = layer;

#if OLD_CODE
		foreach (UIWidget widget in obj.GetComponentsInChildren<UIWidget>(true))
			widget.ParentHasChanged();
#endif
	}

	public static void SetLocalPositionX(this Transform trans, float x) {
		Vector3 pos = trans.localPosition;
		pos.x = x;
		trans.localPosition = pos;
	}

	public static void SetLocalPositionY(this Transform trans, float y) {
		Vector3 pos = trans.localPosition;
		pos.y = y;
		trans.localPosition = pos;
	}

	public static void SetLocalPositionZ(this Transform trans, float z) {
		Vector3 pos = trans.localPosition;
		pos.z = z;
		trans.localPosition = pos;
	}

	public static void AddLocalPositionX(this Transform trans, float x) {
		Vector3 pos = trans.localPosition;
		pos.x += x;
		trans.localPosition = pos;
	}

	public static void AddLocalPositionY(this Transform trans, float y) {
		Vector3 pos = trans.localPosition;
		pos.y += y;
		trans.localPosition = pos;
	}

	public static void AddLocalPositionZ(this Transform trans, float z) {
		Vector3 pos = trans.localPosition;
		pos.z += z;
		trans.localPosition = pos;
	}

	public static void SetLocalScaleX(this Transform trans, float x) {
		Vector3 pos = trans.localScale;
		pos.x = x;
		trans.localScale = pos;
	}

	public static void SetLocalScaleY(this Transform trans, float y) {
		Vector3 pos = trans.localScale;
		pos.y = y;
		trans.localScale = pos;
	}

	public static void SetLocalScaleZ(this Transform trans, float z) {
		Vector3 pos = trans.localScale;
		pos.z = z;
		trans.localScale = pos;
	}

	public static GameObject FindInChildren(this GameObject obj, string name) {
		var children = obj.GetComponentsInChildren<Transform>(true);
		foreach (Transform child in children) {
			if (child.name == name)
				return child.gameObject;
		}

		return null;
	}

	public static T Find<T>(this T[] array, Predicate<T> pred) where T : class {
		foreach (T item in array) {
			if (pred(item))
				return item;
		}

		return null;
	}

	public static int IndexOf<T>(this T[] array, T obj) where T : class {
		for (int i = 0; i < array.Length; ++i) {
			if (array[i] == obj)
				return i;
		}

		return -1;
	}

	public static List<T> FindAll<T>(this T[] array, Predicate<T> pred) {
		List<T> result = new List<T>();
		foreach (T item in array) {
			if (pred(item))
				result.Add(item);
		}
		return result;
	}

	public static List<int> FindIndexes<T>(this List<T> list, Predicate<T> pred) {
		List<int> result = new List<int>();
		for (int i = 0; i < list.Count; ++i) {
			if (pred(list[i]))
				result.Add(i);
		}
		return result;
	}

	public static float TickTowards(this float val, float target, float perSecond) {
		return TickTowards(val, target, perSecond, perSecond);
	}

	public static float TickTowards(this float val, float target, float perSecondUp, float perSecondDown) {
		perSecondUp = Mathf.Abs(perSecondUp);
		perSecondDown = Mathf.Abs(perSecondDown);

		if (val < target) {
			val += Time.deltaTime * perSecondUp;
			if (val > target)
				val = target;
		} else if (val > target) {
			val -= Time.deltaTime * perSecondDown;
			if (val < target)
				val = target;
		}

		return val;
	}

	public static string ToHexString(this Color color) {
		return ((int) (color.r * 255)).ToString("X2") + ((int) (color.g * 255)).ToString("X2") + ((int) (color.b * 255)).ToString("X2");
	}
}

public static class RectTransformExtensions {
	public static void SetDefaultScale(this RectTransform trans) {
		trans.localScale = new Vector3(1, 1, 1);
	}
	public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec) {
		trans.pivot = aVec;
		trans.anchorMin = aVec;
		trans.anchorMax = aVec;
	}

	public static Vector2 GetSize(this RectTransform trans) {
		return trans.rect.size;
	}
	public static float GetWidth(this RectTransform trans) {
		return trans.rect.width;
	}
	public static float GetHeight(this RectTransform trans) {
		return trans.rect.height;
	}

	public static void SetPositionOfPivot(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x, newPos.y, trans.localPosition.z);
	}

	public static void SetLeftBottomPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
	}
	public static void SetLeftTopPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
	}
	public static void SetRightBottomPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
	}
	public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
	}

	public static void SetSize(this RectTransform trans, Vector2 newSize) {
		Vector2 oldSize = trans.rect.size;
		Vector2 deltaSize = newSize - oldSize;
		trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
		trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
	}
	public static void SetWidth(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(newSize, trans.rect.size.y));
	}
	public static void SetHeight(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(trans.rect.size.x, newSize));
	}

	// 
	// http://forum.unity3d.com/threads/move-ui-above-touchkeyboard-for-mobile.353493/#post-2688697
	// http://answers.unity3d.com/questions/781643/unity-46-beta-rect-transform-position-new-ui-syste.html
	public static Rect GetScreenRect(this RectTransform rectTransform, Canvas canvas) {
		Vector3[] corners = new Vector3[4];
		Vector3[] screenCorners = new Vector3[2];

		rectTransform.GetWorldCorners(corners);

		if (canvas.renderMode == RenderMode.ScreenSpaceCamera || canvas.renderMode == RenderMode.WorldSpace) {
			screenCorners[0] = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, corners[1]);
			screenCorners[1] = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, corners[3]);
		} else {
			screenCorners[0] = RectTransformUtility.WorldToScreenPoint(null, corners[1]);
			screenCorners[1] = RectTransformUtility.WorldToScreenPoint(null, corners[3]);
		}

		// world to screen return space where x increasing to the right, y increasing upwards
		// invert y so y increases downwards to match Unity GUI  and GUILayout space
		screenCorners[0].y = Screen.height - screenCorners[0].y;
		screenCorners[1].y = Screen.height - screenCorners[1].y;

		return new Rect(screenCorners[0], screenCorners[1] - screenCorners[0]);
	}

	public static void Shuffle<T>(this List<T> list) {
		System.Random rng = new System.Random();
		int n = list.Count;
		while (n > 1) {
			n--;
			int k = rng.Next(n + 1);
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}

	// copy and paste the value of a component into destination
	public static T CopyComponentInChildren<T>(this GameObject source, GameObject destination) where T : Component {
		var original = source.GetComponentInChildren<T>();
		if (original == null)
			return null;

		System.Type type = original.GetType();
		var dst = destination.GetComponent(type) as T;
		if (!dst) dst = destination.AddComponent(type) as T;
		var fields = type.GetFields();
		foreach (var field in fields) {
			if (field.IsStatic) continue;
			field.SetValue(dst, field.GetValue(original));
		}
		var props = type.GetProperties();
		foreach (var prop in props) {
			if (!prop.CanWrite || !prop.CanWrite || prop.Name == "name") continue;
			prop.SetValue(dst, prop.GetValue(original, null), null);
		}
		return dst as T;
	}

	//Tuha - Extension
	public static void AddWidth(this RectTransform rectTransform, float value) {
		float newWidth = rectTransform.GetWidth() + value;
		rectTransform.SetWidth(newWidth);
	}

	public static void AddHorizontalPosition(this ScrollRect scrollRect, float value) {
		float newPos = scrollRect.horizontalNormalizedPosition + value;
		scrollRect.horizontalNormalizedPosition = Math.Max(0, Math.Min(1, newPos));
	}
	public static void SetHorizontalPosition(this ScrollRect scrollRect, float value) {
		float newPos = value;
		scrollRect.horizontalNormalizedPosition = Math.Max(0, Math.Min(1, newPos));
	}
	//_End_
}