using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Tipograph
{
    public partial class Form1 : Form
    {
        Dictionary<char, string> morseDictionary = new Dictionary<char, string>
        {
            { 'a', ".-" }, { 'b', "-..." }, { 'c', "-.-." }, { 'd', "-.." }, { 'e', "." },
            { 'f', "..-." }, { 'g', "--." }, { 'h', "...." }, { 'i', ".." }, { 'j', ".---" },
            { 'k', "-.-" }, { 'l', ".-.." }, { 'm', "--" }, { 'n', "-." },
            { 'o', "---" }, { 'p', ".--." }, { 'q', "--.-" }, { 'r', ".-." },
            { 's', "..." }, { 't', "-" }, { 'u', "..-" }, { 'v', "...-" },
            { 'w', ".--" }, { 'x', "-..-" }, { 'y', "-.--" }, { 'z', "--.." },
            { 'A', ".-" }, { 'B', "-..." }, { 'C', "-.-." }, { 'D', "-.." }, { 'E', "." },
            { 'F', "..-." }, { 'G', "--." }, { 'H', "...." }, { 'I', ".." }, { 'J', ".---" },
            { 'K', "-.-" }, { 'L', ".-.." }, { 'M', "--" }, { 'N', "-." }, { 'O', "---" },
            { 'P', ".--." }, { 'Q', "--.-" }, { 'R', ".-." }, { 'S', "..." }, { 'T', "-" },
            { 'U', "..-" }, { 'V', "...-" }, { 'W', ".--" }, { 'X', "-..-" }, { 'Y', "-.--" },
            { 'Z', "--.." }, { '1', ".----" }, { '2', "..---" }, { '3', "...--" },
            { '4', "....-" }, { '5', "....." }, { '6', "-...." }, { '7', "--..." },
            { '8', "---.." }, { '9', "----." }, { '0', "-----" }, { 'А', ".-" }, { 'Б', "-..." },
            { 'В', ".--" }, { 'Г', "--." }, { 'Д', " -.." }, { 'Е', "." }, { 'Ё', "." }, 
            { 'Ж', "...-" }, { 'З', " --.." }, { 'И', ".." }, { 'Й', ".---" }, { 'К', "-.-" }, 
            { 'Л', ".-.." }, { 'М', "--" }, { 'Н', "-." }, { 'О', "---" }, { 'П', ".--." }, 
            { 'Р', ".-." }, { 'С', "..." }, { 'Т', "-" }, { 'У', "..-" }, { 'Ф', "..-." }, { 'Х', "...." },
            { 'Ц', "-.-." }, { 'Ч', "---" }, { 'Ш', "----" }, { 'Щ', "--.-" }, { 'Ъ', "-..-" }, 
            { 'Ы', " -.--" }, { 'Ь', "-..-" }, { 'Э', "..-.." }, { 'Ю', "..--" }, 
            { 'Я', ".-." }, { 'а', "" }, { 'б', "" }, { 'в', ".--" }, { 'г', "--." },
            { 'д', " -.." },{ 'е', "." }, { 'ё', "." }, { 'ж', "...-" }, { 'з', " --.." }, 
            { 'и', ".." }, { 'й', ".---" }, { 'к', "" }, { 'л', ".-.." }, { 'м', "--" }, 
            { 'н', "-." }, { 'о', "---" }, { 'п', ".--." }, { 'р', ".-." }, { 'с', "..." }, 
            { 'т', "-" }, { 'у', "..-" }, { 'ф', "..-." }, { 'х', "...." }, { 'ц', "-.-." }, 
            { 'ч', "---" }, { 'ш', "----" }, { 'щ', "--.-" }, { 'ъ', "-..-" }, { 'ы', " -.--" }, 
            { 'ь', "-..-" }, { 'э', "..-.." }, { 'ю', "..--" }, 
            { 'я', ".-." }, 
            { ' ', " " }
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox1.Text;
            richTextBox2.Text = ReplaceQuotes(richTextBox1.Text);
            richTextBox2.Text = RemoveSpacesAroundHyphens(richTextBox1.Text);
            richTextBox1_plusminus();
            richTextBox1_threepoints();
            razrab();
            richTextBox1_zametka();
        }

        //Метод1, который отменяет ввод пробела, если уже есть один пробел(т.к. в задании было сказано нельзя именно писать более одного проебла)
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && (sender as RichTextBox).Text.EndsWith(" "))
            {
                e.SuppressKeyPress = true;
            }
        }

        //Метод2 замены "кавычек" на кавычки «елочки»
        public string ReplaceQuotes(string input)
        {

            bool insideQuotes = false;

            var builder = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (c == '"')
                {
                    builder.Append(insideQuotes ? '»' : '«');
                    insideQuotes = !insideQuotes;
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }

        //Метод3, котрый убирает пробеелы вокруг дефиса
        public string RemoveSpacesAroundHyphens(string input)
        {
            return Regex.Replace(input, " — ", "—");
        }

        //Метод4, котрый меняет (+-) на ±
        public void richTextBox1_plusminus()
        {
            string text = richTextBox1.Text;
            string replacedText = text.Replace("(+-)", "±");
            richTextBox2.Text = replacedText;
        }

        //Метод5, которые меняет "..." на троеточие "…"
        public void richTextBox1_threepoints()
        {
            string text = richTextBox1.Text;
            string replacedText = text.Replace("...", "…");
            richTextBox2.Text = replacedText;
        }

        //Метод6(cобственный), который ставит все на свои места
        public void razrab()
        {
            string text = richTextBox1.Text;
            string replacedText = text.Replace("разработчик плохой", "разработчик хороший");
            richTextBox2.Text = replacedText;
        }

        //Метод7(cобственный), который делает заметки
        public void richTextBox1_zametka()
        {
            string text = richTextBox1.Text;
            string replacedText = text.Replace("!!!", "(Здесь смотреть внимательно)!!!");
            richTextBox2.Text = replacedText;
        }

        private void richTextBoxMorse()
        {
            richTextBox2.Text = TranslateToMorse(richTextBox1.Text);
        }

        //Метод8(собственный), который переводит текст на азбуку Морзе
        public string TranslateToMorse(string input)
        {
            List<string> morseWords = new List<string>();
            string[] words = input.Split(new char[] { ' ', 'r', 'n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                List<string> morseLetters = new List<string>();
                foreach (var character in word.ToLower())
                {
                    if (morseDictionary.TryGetValue(character, out string morseCode))
                    {
                        morseLetters.Add(morseCode);
                    }
                    else
                    {
                        morseLetters.Add("?"); // Неизвестные символы
                    }
                }
                morseWords.Add(string.Join(" ", morseLetters));
            }
            return string.Join("   ", morseWords); // 3 пробела между словами в азбуке Морзе
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBoxMorse();
        }
    }
}

