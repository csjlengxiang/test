﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntranetService
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL.SPService spService = new BLL.SPService("com5", true);
            
            Console.WriteLine("内网服务开启");
            Console.ReadKey();
        }
    }
}
