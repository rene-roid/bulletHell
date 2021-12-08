using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeserializerXML : MonoBehaviour
{
    public void LoadData()
    {
        DataManager player = XMLop.Deserialize<DataManager>("data.xml");
        playerValues.levelsUnlocked = player.levels;
    }

    public void UnSave()
    {
        DataManager player = XMLop.Deserialize<DataManager>("data.xml");
        playerValues.levelsUnlocked = 1;
    }

    public class XMLop
    {
        public static T Deserialize<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(path);
            T deserialized = (T)serializer.Deserialize(reader.BaseStream);
            reader.Close();

            return deserialized;
        }
    }
}
