using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour {
    string readPath;
    string writePath;

    public List<string> stringList = new List<string>();
    public List<string> writeList = new List<string>();

    // Use this for initialization
    void Start () {
        readPath = Application.dataPath + "/Scores.txt";
        writePath = Application.dataPath + "/ScoresFile.txt";

        ReadFile(readPath);
        WriteFile(writePath);
        AppendFile(writePath);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void ReadFile(string filePath)
    {
        StreamReader sReader = new StreamReader(filePath);

        while (!sReader.EndOfStream)
        {
            string line = sReader.ReadLine();
            stringList.Add(line);
        }
    }
}
