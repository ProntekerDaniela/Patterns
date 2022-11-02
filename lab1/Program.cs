using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateXML X1 = new CreateXML("Rook Knight Bishop Queen","King Bishop Knight Rook");
            CreateXML X2 = new CreateXML("Pawn  Pawn   Pawn   Pawn","Pawn  Pawn   Pawn  Pawn");
            CreateXML X3 = new CreateXML("","");
            CreateXML X4 = new CreateXML("", "");
            CreateXML X5 = new CreateXML("","");
            CreateXML X6 = new CreateXML("", "");
            CreateXML X7 = new CreateXML("Pawn  Pawn   Pawn   Pawn","Pawn  Pawn   Pawn  Pawn");
            CreateXML X8 = new CreateXML("Rook Knight Bishop Queen","King Bishop Knight Rook");

            List<CreateXML> createXMLs = new List<CreateXML>();
            createXMLs.Add(X1);
            createXMLs.Add(X2);
            createXMLs.Add(X3);
            createXMLs.Add(X4);
            createXMLs.Add(X5);
            createXMLs.Add(X6);
            createXMLs.Add(X7);
            createXMLs.Add(X8);


            Console.WriteLine("Select situations on the chessboard");
            Console.WriteLine("> 1-list of chess pieces");
            Console.WriteLine("> 2-chess board");

            int levelType = Int32.Parse(Console.ReadLine());

            F f = null;
            if (levelType == 1)
            {
                f = new JSONF("1 King,1 Queen", "2 Rooks,2 Bishops", "2 Knights,8 Pawns");
            }
            else if (levelType == 2)
            {
                f = new XMLF(createXMLs);
            }

            IFile file = f.GetLevel();
            string[] a= file.CreateFile();

            for (int i = 0; i < a.Length; i++)
            {
               Console.WriteLine(a[i]);
            }
            Console.ReadLine();
        }

    }
}
