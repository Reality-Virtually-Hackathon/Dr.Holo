using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

public class ReadWriteText : MonoBehaviour {
    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "C:/Users/denny/Desktop/ReadWriteTest.txt";
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}
