using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutScale : MonoBehaviour
{
	GridLayoutGroup gridLayoutGroup;
	RectTransform rect;
	public int cellCount = 8;

	void Start()
	{
		gridLayoutGroup = GetComponent<GridLayoutGroup>();
		rect = GetComponent<RectTransform>();

		gridLayoutGroup.cellSize = new Vector2(rect.rect.height /1.9f, rect.rect.height/1.9f);
	}

	void OnRectTransformDimensionsChange()
	{
		if (gridLayoutGroup != null && rect != null)
			if ((rect.rect.height + (gridLayoutGroup.padding.horizontal * 2)) * cellCount < rect.rect.width)
				gridLayoutGroup.cellSize = new Vector2(rect.rect.height / 1.9f, rect.rect.height / 1.9f);
	}
}
