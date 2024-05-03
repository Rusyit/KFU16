using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tipograph;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Method1()
        {
            // Arrange
            var form = new Form1();
            string input = "Rustam";
            string expected = ".-. ..- ... - .- --";

            // Act
            string actual = form.TranslateToMorse(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Method2()
        {
            // Arrange
            var form = new Form1();
            string input = "11 @ 22";
            string expected = ".---- .----   ?   ..--- ..---";

            // Act
            string actual = form.TranslateToMorse(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Method3()
        {
            // Arrange
            var form = new Form1();
            string input = "rus — proga";
            string expected = "rus—proga";

            // Act
            string actual = form.RemoveSpacesAroundHyphens(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Method4()
        {
            // Arrange 
            var form = new Form1();
            form.richTextBox1 = new System.Windows.Forms.RichTextBox();
            form.richTextBox2 = new System.Windows.Forms.RichTextBox();
            form.richTextBox1.Text = "Мне 18(+-) лет";

            string expected = "Мне 18± лет";

            // Act
            form.richTextBox1_plusminus();

            // Assert 
            Assert.AreEqual(expected, form.richTextBox2.Text);
        }

        [TestMethod]
        public void Test_Method5()
        {
            // Arrange 
            var form = new Form1();
            form.richTextBox1 = new System.Windows.Forms.RichTextBox();
            form.richTextBox2 = new System.Windows.Forms.RichTextBox();
            form.richTextBox1.Text = "Я написал 5-ый юнит-тест...";

            string expected = "Я написал 5-ый юнит-тест…";

            // Act
            form.richTextBox1_threepoints();

            // Assert 
            Assert.AreEqual(expected, form.richTextBox2.Text);
        }

        [TestMethod]
        public void Test_Method6()
        {
            // Arrange
            var form = new Form1();
            string input = "\"Hello, World!\"";
            string expected = "«Hello, World!»";

            // Act
            string actual = form.ReplaceQuotes(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Method7()
        {
            // Arrange 
            var form = new Form1();
            form.richTextBox1 = new System.Windows.Forms.RichTextBox();
            form.richTextBox2 = new System.Windows.Forms.RichTextBox();
            form.richTextBox1.Text = "!!!";

            string expected = "(Здесь смотреть внимательно)!!!";

            // Act
            form.richTextBox1_zametka();

            // Assert 
            Assert.AreEqual(expected, form.richTextBox2.Text);
        }

        [TestMethod]
        public void Test_Method8()
        {
            // Arrange 
            var form = new Form1();
            form.richTextBox1 = new System.Windows.Forms.RichTextBox();
            form.richTextBox2 = new System.Windows.Forms.RichTextBox();
            form.richTextBox1.Text = "разработчик плохой";

            string expected = "разработчик хороший";

            // Act
            form.razrab();

            // Assert 
            Assert.AreEqual(expected, form.richTextBox2.Text);
        }

        [TestMethod]
        public void Test_Method9()
        {
            // Arrange
            var form = new Form1();
            string input = "Проверка русских слов";
            string expected = ".--. .-. --- .-- . .-.     .-. ..- ... ...  .. ....   ... .-.. --- .--";

            // Act
            string actual = form.TranslateToMorse(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Method10()
        {
            // Arrange
            var form = new Form1();
            string input = "Проверка random набора 3344";
            string expected = ".--. .-. --- .-- . .-.     .-   -.. --- --   -.   --- .-.    ...-- ...-- ....- ....-";

            // Act
            string actual = form.TranslateToMorse(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
