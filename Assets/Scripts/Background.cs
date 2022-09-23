using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private void LateUpdate()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = LevelManager.instance.currentLevel.backgroundImage;
    }

}
