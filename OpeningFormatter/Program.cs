using System.IO;
using System.Text.RegularExpressions;

List<string> list = new List<string>();

StreamReader sr = new StreamReader("C:/Users/Zohaib/Downloads/Openings/Openings5.pgn");

string writeString = "";

while (!sr.EndOfStream)
{
    writeString += sr.ReadLine();
}
sr.Close();

StreamWriter sw = new StreamWriter("C:/Users/Zohaib/Downloads/Openings/Openings5New.pgn");
sw.Write(writeString);
sw.Close();