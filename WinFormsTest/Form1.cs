using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace WinFormsTest
{
    public partial class Form1 : Form
    {

        private readonly HttpClient _httpClient;
        private readonly string _directory = Directory.GetCurrentDirectory();


        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient() ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            await downloadFile();
            unzipFile(_directory + "\\download\\dw.rar");
        }

        private void ReadTxtButton_Click(object sender, EventArgs e)
        {
            readFile(_directory + "\\unzip\\48H.txt");
        }

        private void Zip_Click(object sender, EventArgs e)
        {
            zipFile();
        }

        private async Task downloadFile()
        {
            var downloadUri = new Uri("https://www.autoprice.stutzen.ru/price?download=52005925-84b8-410f-88e6-cd2ee825292a");
            using (HttpResponseMessage response = _httpClient.GetAsync(downloadUri, HttpCompletionOption.ResponseHeadersRead).Result)
            {
                response.EnsureSuccessStatusCode();
                Directory.CreateDirectory(_directory + "\\download");
                using (Stream stream = await response.Content.ReadAsStreamAsync(),//download/dw.rar"
                    fileStream = new FileStream(_directory + "\\download\\dw.rar", FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    // "download/dw.zip"
                    var totalRead = 0L;
                    var totalReads = 0L;
                    var buffer = new byte[8192];
                    var isMoreToRead = true;

                    do
                    {
                        var read = await stream.ReadAsync(buffer, 0, buffer.Length);
                        if (read == 0)
                        {
                            isMoreToRead = false;
                        }
                        else
                        {
                            await fileStream.WriteAsync(buffer, 0, read);

                            totalRead += read;
                            totalReads += 1;
                        }
                    }
                    while (isMoreToRead);

                }
            }

            MessageBox.Show("Файл скачался");
        }

        private void unzipFile(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                return;
            }
            Directory.CreateDirectory(_directory + "\\unzip");
            string pathToUnzip = _directory + "\\unzip";
            Process process = new Process();
            //ProcessStartInfo ps = new ProcessStartInfo();
            process.StartInfo.FileName = @"C:\Program Files\WinRAR\UnRAR";
            process.StartInfo.Arguments = $"x {pathToFile} {pathToUnzip}";
            process.Start();
            process.WaitForExit();
        }

        private void readFile(string pathToFile)
        {
            List<string> allLine = new List<string>();
            //mose[24] - 25 элемент   EKAT[23]
            var fileLine = File.ReadAllLines(pathToFile, Encoding.GetEncoding(1251));

            string firstLine = fileLine[0];

            List<string> list1 = new List<string>() { "sep=", firstLine };
            List<string> list2 = new List<string>() { "sep=", firstLine };
            List<string> list3 = new List<string>() { "sep=", firstLine };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.ForEach(fileLine, chunk =>
            {
                var splitLine = chunk.Split("\t").ToList();
                if (splitLine[0] == "TY" || splitLine[0] == "LM")
                {
                    splitLine.Clear();
                    return;
                }
                splitLine.RemoveAt(24);
                if (double.TryParse(splitLine[23], NumberStyles.Float, new CultureInfo("en-US"), out double result))
                {
                    result = result * 67;
                    splitLine[23] = result.ToString();
                }

                string rdyLine = string.Join('\t', splitLine);
                allLine.Add(rdyLine);
                splitLine.Clear();
            });
            stopwatch.Stop();

            //foreach (var chunk in fileLine)
            //{
            //    Parallel.ForEach(chunk, (item) =>
            //    {
            //        var splitLine = item.ToString().Split("\t").ToList();
            //        splitLine.RemoveAt(24);
            //        if (double.TryParse(splitLine[23], NumberStyles.Float, new CultureInfo("en-US"), out double result))
            //        {
            //            result = result * 67;
            //            splitLine[23] = result.ToString();
            //        }

            //        string rdyLine = string.Join('\t', splitLine);
            //        if (string.IsNullOrEmpty(firstLine))
            //        {
            //            firstLine = rdyLine;
            //        }
            //        allLine.Add(rdyLine);
            //        splitLine.Clear();
            //    });
            //}

            //stopwatch.Stop();

            //stopwatch.Start();
            //foreach (var item in fileLine)
            //{
            //    var splitLine = item.Split("\t").ToList();
            //    if (splitLine[0] == "TY" || splitLine[0] == "LM")
            //    {
            //        splitLine.Clear();
            //        continue;
            //    }
            //    splitLine.RemoveAt(24);
            //    if (double.TryParse(splitLine[23], NumberStyles.Float, new CultureInfo("en-US"), out double result))
            //    {
            //        result = result * 67;
            //        splitLine[23] = result.ToString();
            //    }

            //    string rdyLine = string.Join('\t', splitLine);
            //    if (string.IsNullOrEmpty(firstLine))
            //    {
            //        firstLine = rdyLine;
            //    }
            //    allLine.Add(rdyLine);
            //    splitLine.Clear();
            //}

            //stopwatch.Stop();
            allLine.RemoveAt(0);
            allLine.Sort();
            //List<string> list1 = new List<string>() { "sep=" ,firstLine };
            //List<string> list2 = new List<string>() { "sep=", firstLine };
            //List<string> list3 = new List<string>() { "sep=", firstLine };

            foreach (var chunk in allLine.Chunk(3))
            {
                try
                {
                    list1.Add(chunk[0].ToString());
                    list2.Add(chunk[1].ToString());
                    list3.Add(chunk[2].ToString());
                }
                catch (Exception)
                {
                    string pathToOut1 = _directory + "\\download\\outpute1.txt";
                    string pathToOut2 = _directory + "\\download\\outpute2.txt";
                    string pathToOut3 = _directory + "\\download\\outpute3.txt";

                    File.WriteAllLines(pathToOut1, list1.ToArray(), Encoding.GetEncoding(1251));
                    File.Move(pathToOut1, Path.ChangeExtension(pathToOut1, ".csv"));

                    File.WriteAllLines(pathToOut3, list2.ToArray(), Encoding.GetEncoding(1251));
                    File.Move(pathToOut3, Path.ChangeExtension(pathToOut2, ".csv"));

                    File.WriteAllLines(pathToOut3, list3.ToArray(), Encoding.GetEncoding(1251));
                    File.Move(pathToOut3, Path.ChangeExtension(pathToOut3, ".csv"));
                }
            }

            MessageBox.Show("Файлы csv успешно созданы");
        }

        private void zipFile()
        {

            Directory.CreateDirectory(_directory + "\\download\\zip");
            string pathToZip = _directory + "\\download\\zip\\zip.rar";
            string file1 = _directory + "\\download\\outpute1.csv";
            string file2 = _directory + "\\download\\outpute2.csv";
            string file3 = _directory + "\\download\\outpute3.csv";

            Process process = new Process();
            //ProcessStartInfo ps = new ProcessStartInfo();
            process.StartInfo.FileName = @"C:\Program Files\WinRAR\Rar";
            process.StartInfo.Arguments = $"a -ep {pathToZip} {file1} {file2} {file3}";
            process.Start();
            process.WaitForExit();
            MessageBox.Show("Архив создан в папке загрузки zip архива");
        }

    }
}