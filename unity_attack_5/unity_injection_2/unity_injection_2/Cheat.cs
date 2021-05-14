using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Cheat.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Reflection;

namespace unity_injection_2    
{
    public class Cheat : UnityEngine.MonoBehaviour
    {
        static string[] exlist = new string[] { "Image", "Text (TMP)", "CompassMarkerDirection(Clone)", "ImageBackground",
            "Level_Combined", "CompassMarkerEnemy(Clone)","ForegroundImage","Dun_Wall", "Floor_3x3", "Hitbox Top","GunMuzzle",
            "Wall_1m","Dun_Corner", "Floor_18x18","Floor_15x15","WeaponRoot","GunRoot","Wall_Corner","Weapon_MachineGun",
            "DetectionModule", "Basic_Floor", "Mesh","Wall_4m","ShortSteps", "Floor_9x9", "Floor_6x6","Sign_Diamond"};
        public static Component hcmpt = new Component();
        public static PropertyInfo hpi;
        float hp;
        private void OnGUI()
        {
            /*Scene s = SceneManager.GetSceneByName("MainScene");
            GameObject[] gameObjects = s.GetRootGameObjects();*/

/*            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

            foreach (GameObject objs in allObjects)
            {
                if (objs.activeInHierarchy)
                {
                    Debug.Log(objs.name);
                }
            }*/
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                GetObjectName();
                Debug.Log("make Objlist File");
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                /*Debug.Log(GameObject.Find("Player").GetComponent("Health"));*/
                getcpts(GameObject.Find("Player"));
            }
            hp = (float)System.Convert.ToDouble(hpi.GetValue(hcmpt));
            if (hp < 80f)
            {
                Debug.Log(string.Format("{0} = {1}", hpi, hp));
                hpi.SetValue(hcmpt, 100f);
                Debug.Log("HP is set to 100");
            }
        }
        public static void GetObjectName()
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

            string filePath = Path.Combine(Application.streamingAssetsPath, "G:\\webgl\\Object.txt");
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));

            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.Unicode);
            
            foreach (GameObject objs in allObjects)
            {
                if (objs.activeInHierarchy)
                {
                    if (!exlist.Contains(objs.name))
                        writer.WriteLine(objs.name);
                }
            }
            writer.Close();
        }

        public static void getcpts(GameObject o) {
           Component[] allcmpts =  o.GetComponents(typeof(Component));
            Component fcmpt; //개별 오브젝트

            foreach (Component cmpts in allcmpts) {
                if (cmpts.GetType().Name == "Health"){
                    hcmpt = cmpts;
                    fcmpt = cmpts;
                    PropertyInfo[] pis = fcmpt.GetType().GetProperties();
                    foreach (PropertyInfo pi in pis){
                        if (pi.Name == "currentHealth"){
                            hpi = pi;
                        }
                    }
                }
            }

        }

    }
}
