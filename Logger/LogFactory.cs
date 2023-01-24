using System;
using System.ComponentModel;
using System.IO;

namespace Logger
{
   
    
    public class LogFactory
    {   
        public string Name { get; set; }
        private string filePath = null;

        public BaseLogger CreateLogger(string className){
            if (className.Equals("FileLogger"))
            {
                if (filePath != null)
                    return new FileLogger(filePath);
                //else
                //    throw new InvalidOperationException("You need to call ConfigureFileLogger first to set the path");
            }
            return null;
        }
    }
}
