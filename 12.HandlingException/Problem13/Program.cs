using System;
using System.Net;

namespace Problem13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebClient wc = null;
            string errorMessage = null;
            string url = Console.ReadLine();

            try
            {
                wc = new WebClient();
                // downloading the file and placing it in the project directory
                wc.DownloadFile(url, @"..\..\..\google.png");
            }
            catch (WebException we)
            {
                errorMessage = we.Message;
            }
            catch (NotSupportedException nse)
            {
                errorMessage = nse.Message;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            finally
            {
                if (errorMessage != null) Console.WriteLine(errorMessage);
            }

        }
    }
}
