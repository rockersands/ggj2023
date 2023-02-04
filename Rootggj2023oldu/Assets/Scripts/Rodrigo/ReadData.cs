using UnityEngine;
using System.IO;


public class ReadData : MonoBehaviour
{
    // Start is called before the first frame update

    public string[,] ReadFromCSV(string filepath)
    {
        string csvFile = File.ReadAllText(filepath);
        string[] data = csvFile.Split(new char[] { '\n' });

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
    
}
