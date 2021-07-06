using System;

namespace Document_Task_
{
    public class DocumentProgram
    {
        public void OpenDocument()
        {
            Console.WriteLine("Document Opened.");
        }

        public virtual void EditDocument()
        {
            Console.WriteLine("Can Edit in Pro and Expert versions.");
        }

        public virtual void SaveDocument()
        {
            Console.WriteLine("Can Save in Pro and Expert versions.");
        }

    }

    public class ProDocumentProgram : DocumentProgram
    {
        public sealed override void EditDocument()
        {
            Console.WriteLine("Document Edited!");
        }
        public override void SaveDocument()
        {
            Console.WriteLine("Document Saved in doc format, for pdf format buy Expert packet.");
        }
    }

    public class ExpertDocument : ProDocumentProgram
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Document Saved in pdf format.");
        }
    }

    public static class ProgramKeys
    {
        public static string Basic => "basic";
        public static string Pro => "pro";
        public static string Expert => "expert";
    }

    public class ProgramKeyException : ApplicationException
    {
        public ProgramKeyException(string message) : base(message)
        {
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string key;
                DocumentProgram program = null;
                do
                {
                    Console.WriteLine("Please enter your key");
                    Console.WriteLine("basic");
                    Console.WriteLine("pro");
                    Console.WriteLine("expert");

                    Console.Write("Enter key: ");
                    key = Console.ReadLine();
                } while (String.IsNullOrEmpty(key));


                if (key == ProgramKeys.Basic)
                {
                    program = new DocumentProgram();
                }
                else if (key == ProgramKeys.Pro)
                {
                    program = new ProDocumentProgram();
                }
                else if (key == ProgramKeys.Expert)
                {
                    program = new ExpertDocument();
                }
                else
                {
                    throw new ProgramKeyException($"There is no key equal to -> {key}");
                }
                program.OpenDocument();
                program.EditDocument();
                program.SaveDocument();
                Console.WriteLine("Document Closed");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}
