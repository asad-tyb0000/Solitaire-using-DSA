using System;
using System.Collections.Generic;
using System.IO;

namespace classLibrary.DL
{
    public class Images
    {
        private static string filePath = "E:\\semester 3\\DSA lab\\projects\\Solitaire project\\imagePaths.csv";

        public static Dictionary<string, string> GetImages()
        {
            Dictionary<string, string> imagePaths = new Dictionary<string, string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');

                        if (parts.Length == 2)
                        {
                            imagePaths.Add(parts[0], parts[1]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return imagePaths;
        }


        public static string giveImage(string name, Dictionary<string, string> images)
        {
            try
            {
                if (images.ContainsKey(name))
                {
                    return images[name];
                }
                else
                {
                    return $"Image with name '{name}' not found.";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string GetImage(string name)
        {
            Dictionary<string, string> images = GetImages();
            return giveImage(name, images);
        }

        public string giveBackSide()
        {
            return "E:/semester 3/DSA lab/projects/Solitaire project/Images/backside2.png";
        }

        public string giveReloadImage()
        {
            return "E:/semester 3/DSA lab/projects/Solitaire project/Images/reload.png";
        }

    }
}
