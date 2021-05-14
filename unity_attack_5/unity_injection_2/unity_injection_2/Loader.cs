using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace unity_injection_2
{
    public class Loader
    {
        static UnityEngine.GameObject gameObject;

        public static void Load()
        {
            gameObject = new UnityEngine.GameObject();
            gameObject.AddComponent<unity_injection_2.Cheat>();
            gameObject.AddComponent<Consolation.Console>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject);
        }


    }
}
