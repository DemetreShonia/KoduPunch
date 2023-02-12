using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

namespace KODUA
{

    public class FilePicker : MonoBehaviour
    {
        [SerializeField] AvatarSelector _avatarSelector;

        string _finalPath;

        public void LoadFile()
        {
            string FileType = NativeFilePicker.ConvertExtensionToFileType("*");
            NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) =>
            {
                if (path == null)
                    Debug.Log("Operation Canceled");
                else
                {
                    _finalPath = path;
                    StartCoroutine(LoadTexture());
                    Debug.Log("Picked file: " + _finalPath);
                }
            }, new string[] {FileType});
        }

        public void SaveFile()
        {
            // create dummy text file
            string filePath = Path.Combine(Application.temporaryCachePath, "test.txt");
            File.WriteAllText(filePath, "Hello world!");

            // export the file
            NativeFilePicker.Permission permission = NativeFilePicker.ExportFile(filePath, (success) => Debug.Log("File Exported " + success));
        }
        IEnumerator LoadTexture()
        {
            WWW www = new WWW(_finalPath);
            while (!www.isDone)
                yield return null;

            // www.texrture
            Texture2D texture = www.texture;
            print(texture.width);
            Sprite sprite = Sprite.Create(texture, new Rect(150, 150, 300, 300), new Vector2(0.5f, 0.5f));
            
            _avatarSelector.CurrentFaceSpriteRenderer.GetSpriteRenderer().sprite = sprite;
        }
    }

}