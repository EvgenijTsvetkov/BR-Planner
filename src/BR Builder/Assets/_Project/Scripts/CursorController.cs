using UnityEngine;

namespace _Project.Scripts
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Texture2D _defaultTexture;
        [SerializeField] private Vector2 _defaultHotspot = new Vector2(16f, 0f);
        
        private void Awake() => 
            SetCursor(_defaultTexture);

        private void SetCursor(Texture2D texture) => 
            Cursor.SetCursor(texture, _defaultHotspot, CursorMode.Auto);
    }
}
