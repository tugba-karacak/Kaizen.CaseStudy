// See https://aka.ms/new-console-template for more information

using JsonParser.Models;
using Newtonsoft.Json;
using System.Text;


/* 
 * sol üst 1.
 * sağ üst 2.
 * sağ alt 3.
 * sol alt 4.
 */

using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + "\\response.json", Encoding.UTF8))
{
    string json = r.ReadToEnd();
    List<Item> items
    = JsonConvert.DeserializeObject<List<Item>>(json) ?? new List<Item>();

    FileInfo fileInfo = new FileInfo(Directory.GetCurrentDirectory() + "\\response.txt");
    if (!fileInfo.Exists)
    {
        var sw = fileInfo.CreateText();
        sw.Close();

    }

    using var fr = fileInfo.OpenWrite();

    using var writer = new StreamWriter(fr);

    for (int i = 0; i < items.Count; i++)
    {
        if (i == 0)
        {
            writer.WriteLine(items[i].Description);
        }
        else
        {

            var x = items[i].BoundingPoly.Vertices[2].X;
            var y = items[i].BoundingPoly.Vertices[2].Y;
            int nextY = 0;
            if (i + 1 <= items.Count - 1)
            {
                nextY = items[i + 1].BoundingPoly.Vertices[2].Y;
            }


            if (576 - x < 77)
            {
                writer.WriteLine(items[i].Description);
            }
            //576-415 = 161
            else if (576 - x < 162 && 576 - x > 77)
            {
                if (y == nextY || y + 1 == nextY)
                {
                    writer.Write(items[i].Description + " ");
                }
                else
                {
                    writer.WriteLine(items[i].Description);
                }

            }
            else if (y + 19 == nextY || y + 28 == nextY || y + 51 == nextY || y + 21 == nextY || y + 22 == nextY || y + 25 == nextY || y + 26 == nextY || y + 24 == nextY || y + 20 == nextY)
            {
                writer.WriteLine(items[i].Description);
            }
            else
            {
                writer.Write(items[i].Description + " ");
            }
        }



    }


    writer.Close();

    using var fs = fileInfo.OpenRead();
    using var reader = new StreamReader(fs);
    var result = reader.ReadToEndAsync().Result;

    reader.Close();

    Console.WriteLine(result);


}