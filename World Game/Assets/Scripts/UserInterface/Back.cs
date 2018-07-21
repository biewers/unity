using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour {

    Image[] images;

    private void Awake()
    {
        images = FindObjectsOfType<Image>();
    }

    public void OnClick()
    {
        GameObject obj = GetGameObjectFromState(GameState.currentState);
        obj.GetComponent<Navigate>().ZoomOut(obj.GetComponent<Animator>());
    }

    GameObject GetGameObjectFromState(State state)
    {
        GameObject obj = null;

        foreach (Image img in images)
        {
            if (img.name == state.ToString())
            {
                obj = img.gameObject;
            }
        }

        return obj;
    }

}
