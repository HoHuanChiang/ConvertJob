using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PhilipsProject.Models
{
    public class ConvertProcess
    {
        private Process process;

        public void Start()
        {
            process = new Process();
            process.StartInfo.FileName = @"C:\philips\isyntaxConverter.exe";
            process.StartInfo.Arguments = @"convert C:\philips\1.isyntax 0 0 0";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            //* Set your output and error (asynchronous) handlers
            process.OutputDataReceived += (sendingProcess, outLine) => OutputConvertHandler(sendingProcess, outLine);
            process.ErrorDataReceived += (sendingProcess, outLine) => ErrorConvertHandler(sendingProcess, outLine);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        private void OutputConvertHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                Debug.WriteLine(outLine.Data);
                if (outLine.Data.Trim() == "TIFF Successfully Generated")
                {
                    Debug.WriteLine("Success");
                }
            }


        }
        private void ErrorConvertHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                Debug.WriteLine("error: " + outLine.Data);
            }
        }
    }
}