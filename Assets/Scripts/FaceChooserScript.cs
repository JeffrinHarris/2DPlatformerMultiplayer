using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;

public class FaceChooserScript : MonoBehaviour
{
    
    private RawImage face;
    [SerializeField]
    private UISkin skin;

    private void Start()
    {
        face = GetComponentInChildren<RawImage>();
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images",".jpg",".png"));
        FileBrowser.SetDefaultFilter(".png");
        FileBrowser.Skin = skin;
    }   
    
    public void ChooseFace()
    {
        FileBrowser.ShowLoadDialog((paths) => fileSelected(paths), () => fileCancelled(),FileBrowser.PickMode.FilesAndFolders,false,null,null,"Choose a Face","Select Face");
    }

    private void fileSelected(string[] paths)
    {
        Debug.Log("File selected! "+ FileBrowser.Result[0]);

        byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);

        Texture2D tex = new Texture2D(2,2);
        tex.LoadImage(bytes);

        face.texture = tex;

        PlayerDataHandler.playerFace = face;
    }

    private void fileCancelled()
    {
        Debug.Log("File failed to select.");
    }

}
