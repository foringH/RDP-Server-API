﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePc
{
    class Program
    {
        static void Main(string[] args)
        {
           
           
            SharePc pc1 = new SharePc();


            String invitation = pc1.getControlString();

            Console.WriteLine(invitation);
            
            String abn = Console.ReadLine();

            pc1.destroy();

            
            String invitation2 = pc1.getControlString();
            Console.WriteLine(invitation2);

        

            String ab = Console.ReadLine();

            pc1.destroy();
            
            String abc = Console.ReadLine();

        }
    }
}