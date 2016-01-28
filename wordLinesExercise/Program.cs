using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordLinesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> bufferBucket = new List<string>(args);

            Console.WriteLine("Helloooooo! :) Let's begin...");
            int lineLength = 0;
            string lineLengthInput = null;
            while (lineLengthInput == null)
            {
                Console.WriteLine("Enter line length: ");
                lineLengthInput = Console.ReadLine();
                try
                {
                    lineLength = Convert.ToInt32(lineLengthInput);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Listen, you doing it wrong. Try not to brake my program, plzkthxbye.");
                    Console.WriteLine("Just enter numbers; 0-9");
                    lineLengthInput = null;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Jeez-fricking-shit, man!");
                    Console.WriteLine("What kind of crazy number is that, wtf? Just, no.");
                    Console.WriteLine(string.Format("Okay, so value no less than {0}, or more than {1}.", 1, Int32.MaxValue));
                    lineLengthInput = null;
                }

                if (lineLength < 0)
                {
                    Console.WriteLine("Okay, so you tried to go negative, congrats.");
                    Console.WriteLine("Thing is, that's obviously dumbdumb, you dumbdumb.");
                    Console.WriteLine(string.Format("Value no less than {0}, or more than {1}, remember that.", 1, Int32.MaxValue));
                    lineLengthInput = null;
                }
                else if (lineLength == 0)
                {
                    Console.WriteLine("...The hell would this program do with a zero line length, genius?");
                    Console.WriteLine(string.Format("Value no less than {0}, or more than {1}.", 1, Int32.MaxValue));
                    lineLengthInput = null;
                }

                if (bufferBucket.Any(x => x.Length > lineLength))
                {
                    Console.WriteLine("No, I get it, you thought it would do some fancy word-wrap type shiz ...it doesn't.");
                    Console.WriteLine("...To be clear, seems one of your words be longer than the line length. I know, it's okay.");
                    lineLengthInput = null;
                }
            }
            List<string> lines = new List<string>();

            while(bufferBucket.Count > 0)
            {
                string line;
                bufferBucket = BuildLine(bufferBucket, lineLength, out line);
                lines.Add(line);
            }

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey(true);
        }

        static List<string> BuildLine(List<string> words, int lineLength, out string line)
        {
            List<string> workingWordsBuffer = new List<string>(words);
            List<string> newLine = new List<string>();

            while (LineCount(newLine) < lineLength)
            {
                string word = workingWordsBuffer.Find(x => x.Length <= lineLength - LineCount(newLine));

                if (word == null)
                {
                    break;
                }
                else
                {
                    newLine.Add(word);
                    newLine.Add(" ");
                    workingWordsBuffer.Remove(word);
                }
            }
   
            if (newLine.Count == 2)
            {
                if (LineCount(newLine) > lineLength)
                {
                    line = newLine.ElementAt<string>(0);
                    return workingWordsBuffer;
                }

                int paddingCount = lineLength - LineCount(newLine);
                string padding = " ".PadRight(paddingCount);
                newLine.Add(padding);
                line = string.Join("", newLine);
                return workingWordsBuffer;
            }

            newLine.RemoveAt(newLine.Count - 1);

            int missingCount = lineLength - LineCount(newLine);
            while (missingCount > 0)
            {
                for (int i = 1; i < newLine.Count - 1; i += 2)
                {
                    if (missingCount == 0)
                        break;
                    newLine[i] = newLine[i] + " ";
                    missingCount--;
                } 
            }
            line = string.Join("", newLine);
            return workingWordsBuffer;
        }

        static int LineCount(List<string> line)
        {
            int count = 0;
            foreach (string item in line)
            {
                count += item.Length;
            }
            return count;
        }
    }
}
