using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmcTextDecoder
{
    /// <summary>
    /// C# port of https://github.com/fei-ke/OmcTextDecoder
    /// to decode cscfeature*.xml files from Samsung Stock ROMs
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 2 || args.Length > 3)
            {
                Console.WriteLine("USAGE: OmcTextDecoder <e,d> <inputdirectory> [outputdirectory]");
            }

            bool decode = true;
            decode = args[0] == "d";
            string inputdirectory = args[1];

            string outputdirectory = string.Empty;
            if (args.Length == 3)
            {
                outputdirectory = args[2];
            }

            Console.WriteLine("OmcTextDecoder {0} {1}", args[0], args[1]);

            if (Directory.Exists(inputdirectory))
            {
                string[] filesList = Directory.GetFiles(inputdirectory, "cscfeature*.xml", SearchOption.AllDirectories);
                foreach (var inputFile in filesList)
                {
                    FileInfo fi = new FileInfo(inputFile);
                    if (string.IsNullOrEmpty(outputdirectory))
                        processFile(inputFile, inputFile, decode);
                    else
                        processFile(inputFile, Path.Combine(outputdirectory, fi.Name), decode);
                }

                if (filesList.Length == 0)
                {
                    Console.WriteLine("No cscfeature.xml found in given path!: {0}", inputdirectory);
                }
            }
        }

        private static void processFile(string inputFile, string outputFile, bool decode)
        {
            try
            {
                OmcDecoderClass decoder = new OmcDecoderClass();
                FileInfo ifInfo = new FileInfo(inputFile);
                FileInfo ofInfo = new FileInfo(outputFile);

                if (!ifInfo.FullName.EndsWith(".xml"))
                {
                    //not xml file, ignored
                    return;
                }

                string s = File.ReadAllText(inputFile);

                if (decode && File.ReadAllText(inputFile).StartsWith("<?xml"))
                {
                    // already decoded, ignored
                    return;
                }

                byte[] bytes;
                if (decode)
                    bytes = decoder.decode(inputFile);
                else
                {
                    bytes = decoder.encode(inputFile);
                }

                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }

                File.WriteAllBytes(outputFile, bytes);

                System.Console.WriteLine("output " + outputFile.ToString() + " success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}