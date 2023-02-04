using UnityEngine;
using System.IO;


public class ReadData : MonoBehaviour
{
    // Start is called before the first frame update

    public string[,] ReadFromCSV(string filename)
    {
        try
        {
            if (Resources.LoadAll<TextAsset>($"levels/") != null)
            {
                TextAsset csvFile = Resources.Load<TextAsset>($"levels/{ filename}");
                if (csvFile == null)
                {
                    Debug.Log("Error, reader not found");
                    return constructDummyMap();
                }
            
                string[] data = csvFile.text.Split(new char[] { '\n' });

                int rowCount = data.Length;
                int colCount = data[0].Split(new char[] { ',' }).Length;

                string[,] csvData = new string[rowCount, colCount];

                for (int i = 0; i < rowCount; i++)
                {
                    string[] row = data[i].Split(new char[] { ',' });

                    for (int j = 0; j < colCount; j++)
                    {
                        csvData[i, j] = row[j];
                    }
                }
                return csvData;
            }
            return constructDummyMap();
        }


        catch (FileNotFoundException ex)
        {
            Debug.LogError("File not found: " + ex.Message);

            //No such file, throw the basic example
            return constructDummyMap();
        }
    }

    public string[,] constructDummyMap()
    {
        string[,] dummyData = new string[10, 10];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (i == 0 || i == 9 || j == 0 || j == 9)
                {
                    dummyData[i, j] = "1";
                }
                else if (i == 1 && j == 1)
                {
                    dummyData[i, j] = "2";
                }
                else if (i == 8 && j == 8)
                {
                    dummyData[i, j] = "4";
                }
                else
                {
                    dummyData[i, j] = "5";
                }
            }
        }
        return dummyData;
    }
    
}
