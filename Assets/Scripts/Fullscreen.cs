using UnityEngine;
using System.Runtime.InteropServices;
public class Fullscreen : MonoBehaviour {
    [DllImport("__Internal")]
    private static extern void FullScreen ();
    public void SomeMethod () {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    FullScreen();
#endif
    }
}