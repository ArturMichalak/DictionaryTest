using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProject.View
{
    class BasicObjects
    {
        public static void Dialog(string massage, int height)
        {
            int start = 0;
            int top = 0;
            var msg = new Dictionary<string, int>();

            while (start < massage.Length)
            {
                string text;
                if ((massage.Length - start - Console.WindowWidth - 6) >= 0)
                    text = massage.Substring(start, Console.WindowWidth - 6);
                else
                    text = massage.Substring(start, massage.Length - start);
                msg.Add(text, (Console.WindowWidth - text.Length - 2) / 2);
                start += Console.WindowWidth - 6;
            }
            Console.SetCursorPosition(0, Console.WindowHeight - height - 1);
            Console.Write("+" + new String('-', Console.WindowWidth - 2) + "+");
            if (height < msg.Count) throw new ArgumentException();
            else if (height != msg.Count)
            {
                top = (height - msg.Count) / 2;
                top = top > 0 ? top-- : top;
                for (int i = 0; i < top; i++)
                {
                    Console.Write("|" + new String(' ', Console.WindowWidth - 2) + "|");
                }
            }
            foreach (var item in msg)
            {
                Console.Write("|" + new String(' ', item.Value) + item.Key + new String(' ', Console.WindowWidth - item.Key.Length - item.Value - 2) + "|");
            }
            while (Console.CursorTop < Console.WindowHeight)
            {
                Console.Write("|" + new String(' ', Console.WindowWidth - 2) + "|");
            }
        }
    }
}
