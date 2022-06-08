using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceScript : MonoBehaviour
{
    
    [SerializeField]
    private RawImage chosenFace;

    void Start()
    {
        chosenFace = PlayerDataHandler.playerFace;
        Texture2D tex = (Texture2D)chosenFace.texture;
        Debug.Log(tex.width + " " + tex.height);
        Rect rect = new Rect(0.0f,0.0f,tex.width,tex.height);
        Vector2 pivot = new Vector2(0.5f,0.5f);
        float ppu = tex.width;
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex,rect,pivot,ppu);  //Create sprite with given texture, same size and center as the texture and 50 pixels per unit
    }

}
