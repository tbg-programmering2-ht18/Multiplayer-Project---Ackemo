using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreSystem : MonoBehaviour
{
    public Text p1Score;
    public Text p2Score;
    public int score1;
    public int score2;

    public void LoadCurrent()
    {
        string path1 = Application.dataPath + "/p1Score.txt";
        string path2 = Application.dataPath + "/p2Score.txt";
        try
        {
            if (File.Exists(path1))
            {
                string data = File.ReadAllText(path1);
                p1Score.text = data;
            }
            if (File.Exists(path2))
            {
                string data = File.ReadAllText(path2);
                p2Score.text = data;
            }
            return;
        }
        catch
        {
            Debug.LogError("File not found");
        }

    }

    public void SaveCurrent()
    {
        string path1 = Application.dataPath + "/p1Score.txt";
        if (!File.Exists(path1))
        {
            File.WriteAllText(path1, "0");
        }
        File.WriteAllText(path1, "");
        string content1 = score1.ToString();
        File.AppendAllText(path1, content1);

        string path2 = Application.dataPath + "/p2Score.txt";
        if (!File.Exists(path2))
        {
            File.WriteAllText(path2, "0");
        }
        File.WriteAllText(path2, "");
        string content2 = score2.ToString();
        File.AppendAllText(path2, content2);
        return;
    }

    public void BtnPressP1()
    {
        score1++;
        p1Score.text = score1.ToString();
    }

    public void BtnPressP2()
    {
        score2 += 1;
        p2Score.text = score2.ToString();
    }

    public void BtnPressReset()
    {
        score1 = 0;
        p1Score.text = score1.ToString();
        score2 = 0;
        p2Score.text = score2.ToString();
    }
}
