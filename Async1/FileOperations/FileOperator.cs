using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Async1.FileOperations
{
    internal class FileOperator
    {
        private const string HelloString = "Hello", WorldString = "World";
        public void WriteTextInFile(string text, string path)
        {
            ThrowArgumentNullExceptionIfStringIsNullOrEmpty(text, nameof(text));
            ThrowArgumentNullExceptionIfStringIsNullOrEmpty(path, nameof(path));

            var bytes = Encoding.UTF8.GetBytes(text);
            using (var f = File.Open(path, FileMode.Create))
            {
                f.Write(bytes, 0, bytes.Length);
            }
        }
        public async Task<string> ReadHelloWorldFromFile(string pathHello, string pathWorld)
        {
            var hello = await ReadWordFromFile(pathHello, HelloString);
            var world = await ReadWordFromFile(pathWorld, WorldString);
            return hello + world;
        }

        private async Task<string> ReadWordFromFile(string path, string word)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"There is no file \"{path}\"");
            }

            ThrowArgumentNullExceptionIfStringIsNullOrEmpty(word, nameof(word));
            string assumedWord = await File.ReadAllTextAsync(path);
            if (word != assumedWord)
            {
                throw new Exception("There is no word in the file");
            }
            return word;
        }
        private void ThrowArgumentNullExceptionIfStringIsNullOrEmpty(string text, string parameterName)
        {
            if (text == null || string.Empty == text)
            {
                throw new ArgumentNullException($"{parameterName} is null or empty");
            }
        }
        private void ThrowFileNotFoundExceptionIFFileIsNotFound(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"There is no file \"{path}\"");
            }
        }
    }
}
