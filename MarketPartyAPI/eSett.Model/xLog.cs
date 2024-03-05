using System.Text;

namespace eSett.Model
{
    public class xLog
    {
        string[] patern = { "\n" };
        public string Filename { get; set; }
        StreamWriter escriba;
        DateTime creationDate;

        static xLog _log;

        private xLog(string path, string head)
        {
            creationDate = DateTime.Now;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            Filename = path + creationDate.ToString("yyMMdd") + ".log";
            escriba = new StreamWriter(Filename, true, Encoding.UTF8);
            escriba.AutoFlush = true;
            if (!File.Exists(Filename))
                OpenLog(head);
        }

        public static void CreateLog(string path, string head = "")
        {
            if (_log == null) _log = new xLog(path, head);
        }

        public static xLog Logger { get { return _log; } }

        public void OpenLog(string head = "")
        {
            if (head != "")
            {
                string cuadro = string.Empty;
                for (int i = -4; i < head.Length; i++)
                    cuadro += "-";
                escriba.WriteLine(cuadro);
                escriba.WriteLine("| " + head + " |");
                escriba.WriteLine(cuadro);
            }
        }

        public string writeLog(string text)
        {
            escriba.WriteLine(text);
            return text;
        }

        public string AddLog(string text)
        {
            if (text != null)
            {
                string[] loger = text.Split(patern, StringSplitOptions.RemoveEmptyEntries);
                foreach (string elem in loger)
                    escriba.WriteLine(string.Format("[{0}] -> {1}.", DateTime.Now.ToString("HH:mm:ss"), elem));
            }
            else
                text = string.Empty;
            return text;
        }

        public string AddFailure(string text)
        {
            return this.AddLog("WARNING <- " + text);
        }

        public bool CloseLog()
        {
            try
            {
                escriba.Close();
                File.Move(Filename, Filename + ".txt");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CloseAndSendLog(string remotePath, string name = "")
        {
            bool result;
            try
            {
                escriba.Flush();
                escriba.Close();
                if (name != "")
                    File.Move(Filename, remotePath + name.Replace(".log", ".txt"));
                else
                    name = Filename;
                result = true;
            }
            catch
            {
                result = false;
            }
            //_log = null;
            return result;
        }
    }
}
