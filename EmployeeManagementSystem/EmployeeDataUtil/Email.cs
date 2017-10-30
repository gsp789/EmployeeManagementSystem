using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDataUtil
{
    public class Email
    {
        public string subject { get; set; }
        public List<String> toAddress { get; set; }
        public List<string> ccAddress { get; set; }
        public string body { get; set; }
        public string fromAddress { get; set; }
      
    }
}
