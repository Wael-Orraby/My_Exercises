namespace File_System_Command_Line
{
    internal class Program
    {
        /* [ File System Command Line ]
         * List files & directories: list [path]
         * Print file & directory info: info [path]
         * Create directory: mkdir [path]
         * Remove directory or File: rm [path]
         * Create file: mkfil [path]
         * Write to file: write [path]
         * Read file content: read [path]
         */
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">> ");
                var input = Console.ReadLine().Trim();
                var whiteSpaceIndex = input.IndexOf(' ');
                var command = input.Substring(0, whiteSpaceIndex).ToLower();
                var path = input.Substring(whiteSpaceIndex + 1).Trim();

                switch (command)
                {
                    case "list":
                        DisplayList(path);
                        break;
                    case "info":
                        DisplayInfo(path);
                        break;
                    case "mkdir":
                        CreateDirectory(path);
                        break;
                    case "rm":
                        Remove(path);
                        break;
                    case "mkfil":
                        CreateFile(path);
                        break;
                    case "write":
                        WriteFunction(path);
                        break;
                    case "read":
                        ReadFile(path);
                        break;
                    /*
                    case "cp":
                        break; To Do!
                    case "mv":
                break;
                    */
                    case "exit":
                        break;
                }
            }
        }

        private static void CreateFile(string path)
        {
            File.Create(path);
        }

        private static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        private static void Remove(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
            else if (Directory.Exists(path))
                Directory.Delete(path);
            else
                Console.WriteLine("Path Can Not Found!");
        }

        private static void ReadFile(string path)
        {
            if (File.Exists(path))
            {
                var content = File.ReadAllText(path);
                Console.WriteLine(content);
            }
            else
                Console.WriteLine("File Not Found!");
        }

        private static void DisplayList(string path)
        {
            foreach (var entry in Directory.GetDirectories(path))
            {
                Console.WriteLine($"\t[Dir] {entry}");
            }
            foreach (var entry in Directory.GetFiles(path))
            {
                Console.WriteLine($"\t[File] {entry}");
            }
        }

        private static void DisplayInfo(string path)
        {
            if (Directory.Exists(path))
            {
                var dirInfo = new DirectoryInfo(path);
                Console.WriteLine($"Type Directory");
                Console.WriteLine($"Created At : {dirInfo.CreationTime}");
                Console.WriteLine($"Last Modified At: {dirInfo.LastWriteTime}");
            }
            else if (File.Exists(path))
            {
                var fileInfo = new FileInfo(path);
                Console.WriteLine($"Type: File");
                Console.WriteLine($"Created At: {fileInfo.CreationTime}");
                Console.WriteLine($"Last Modified At: {fileInfo.LastWriteTime}");
                Console.WriteLine($"Size In Bytes: {fileInfo.Length} (Byte)");
            }
        }

        private static void WriteFunction(string path)
        {
            if (File.Exists(path))
            {
                Console.Write("write the text : ");
                File.AppendAllText(path, " " + Console.ReadLine());
            }
            else
                Console.WriteLine("File Not Found!");
        }
    }
}