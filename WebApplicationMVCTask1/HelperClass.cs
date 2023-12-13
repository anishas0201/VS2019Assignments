using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMVCTask1
{
    public class Helper
    {
        public static void WriteLog(string message)
        {
            // string ErrorLogDir = "D:\\AssignmentProject\\VS2019Projects\\DotNet_TrainingAssignments\\ERROR";
            string ErrorLogDir = "D:\\AssignmentProject\\VS2019Assignments\\WebApplicationMVCTask1\\ErrorLog\\";
            if (!Directory.Exists(ErrorLogDir))
                Directory.CreateDirectory(ErrorLogDir);

            ErrorLogDir += "\\anisha_error" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";
            using (StreamWriter sr = new StreamWriter(ErrorLogDir, true))
            {
                sr.WriteLine(DateTime.Now.ToString("DD-MM-yyyy HH-mm-ss") + message);
            }

        }
    }
}
