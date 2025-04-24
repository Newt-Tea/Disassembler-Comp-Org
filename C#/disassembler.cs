using System;
using System.IO;


/// How to run the code ///

//  1. Ensure that DotNet is setup on your system
//  You simply need a dotnet runtime
//    Run dotnet --version to check

//    dotnet --version Output Example
//       8.0.110


//  2. Go to the directory where your files are located 
//  You can check if your files are there by running 'ls' in the terminal

//  3. Run the following
//  dotnet new console (this creates a new project)
//  rm Program.cs (removes the default project file)
//  dotnet run ./Add.Hack (this is executing your program)



namespace Disassembler
{
   class Program
   {
      static void Main(string[] args)
      {
         // Check if appropriate file extension
         if (args[0].Contains(".hack"))
         {
            // Check if file exists
            if (File.Exists(args[0]))
            {
               string[] Lines = File.ReadLines(args[0]).ToArray();

               // List to be used for storing HACK instructions
               List<string> hackList = new List<string>();

               // Computation Dictionary
               Dictionary<string, string> compTable =
               new Dictionary<string, string>()
               {
                  {"0101010", "0"},
                  {"0111111", "1"},
                  {"0111010", "-1"},
                  {"0001100", "D"},
                  {"0110000", "A"},
                  {"1110000", "M"},
                  {"0001101", "!D"},
                  {"0110001", "!A"},
                  {"1110001", "!M"},
                  {"0001111", "-D"},
                  {"0110011", "-A"},
                  {"1110011", "-M"},
                  {"0011111", "D+1"},
                  {"0110111", "A+1"},
                  {"1110111", "M+1"},
                  {"0001110", "D-1"},
                  {"0110010", "A-1"},
                  {"1110010", "M-1"},
                  {"0000010", "D+A"},
                  {"1000010", "D+M"},
                  {"0010011", "D-A"},
                  {"1010011", "D-M"},
                  {"0000111", "A-D"},
                  {"1000111", "M-D"},
                  {"0000000", "D&A"},
                  {"1000000", "D&M"},
                  {"0010101", "D|A"},
                  {"1010101", "D|M"}
               };


               // Destination Dictionary
               Dictionary<string, string> destTable =
               new Dictionary<string, string>()
               {
                  {"000", ""},
                  {"001", "M="},
                  {"010", "D="},
                  {"011", "DM="},
                  {"100", "A="},
                  {"101", "AM="},
                  {"110", "AD="},
                  {"111", "ADM="}
               };

               // Jump Dictionary
               Dictionary<string, string> jumpTable =
               new Dictionary<string, string>()
               {
                  {"000", ""},
                  {"001", ";JGT"},
                  {"010", ";JEQ"},
                  {"011", ";JGE"},
                  {"100", ";JLT"},
                  {"101", ";JNE"},
                  {"110", ";JLE"},
                  {"111", ";JMP"}
               };

               // Loop through all assembly lines in the HACK file
               foreach (string line in Lines)
               {
                  // A Instruction
                  // if - Check instruction op-code (the first char in the char[])
                          
                     // Get the remaining substring and convert to decimal
                     // Conversion (just uncomment)
                     //       string value = line.Substring(1, 15);
                     //       int binVal = Convert.ToInt32(value, 2);
                     //       string val = binVal.ToString();

                     // Construct the appropriate HACK instruction
                     // https://docs.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings


                     // Append to hackList
                     // https://thedeveloperblog.com/c-sharp/list-add

                  // C Instruction
                  // else if - Check instruction op-code (the first char in the char[])

                     // Create strings from the appropriate substrings
                     // cBit, dBit, jBit
                     // https://www.geeksforgeeks.org/c-sharp-substring-method/

                     // Return HACK destination string from destTable using dBit
                     // https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/

                     // Return HACK computation string from compTable using cBit

                     // Return HACK jump string from jumpTable using jBit

                     // Construct the appropriate HACK instruction

                     // Append to hackList
               }

               // Write to file
               File.WriteAllLines(args[0].Replace(".hack", ".asm"), hackList);
            }
         }
      }
   }
}
