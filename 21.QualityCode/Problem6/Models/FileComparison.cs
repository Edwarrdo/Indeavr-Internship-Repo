using System.IO;

namespace Problem6.Models
{
    public class FileComparison
    {
        public static int Compare(string fileName1, string fileName2)
        {
            using (StreamReader file1 = new StreamReader(fileName1), file2 = new StreamReader(fileName2))
            {
                string line1 = file1.ReadLine();
                string line2 = file2.ReadLine();

                while (line1 != null && line2 != null)
                {
                    int comparisonResult = line1.CompareTo(line2);

                    if (comparisonResult != 0)
                    {
                        return comparisonResult;
                    }

                    line1 = file1.ReadLine();
                    line2 = file2.ReadLine();
                }

                if (line1 == null && line2 != null)
                {
                    return -1;
                }
                else if (line1 != null && line2 == null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
