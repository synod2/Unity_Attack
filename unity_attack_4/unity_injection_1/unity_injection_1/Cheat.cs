using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Cheat.cs
namespace unity_injection_1
{
    public class Cheat : UnityEngine.MonoBehaviour
    {
        private void OnGUI()
        {
            UnityEngine.GUI.Label(new UnityEngine.Rect(10, 10, 200, 40), "This is a very useful cheat");
        }
    }
}
