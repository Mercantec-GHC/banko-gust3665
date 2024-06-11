using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Security.Cryptography.X509Certificates;



namespace Selenium
{
    internal class Selenium
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://mercantec-ghc.github.io/MAGS-Banko/");


                for (var i = 0; i < 10; i++)
                {
                    GeneratePlate($"Gustav{i}");
                }
            }
            catch (WebDriverException e)
            {
                Console.WriteLine("WebDriver exception: " + e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            finally
            {
                driver.Quit();
            }

            void GeneratePlate(string plateId)
            {
                IWebElement inputElement = driver.FindElement(By.Id("tekstboks"));
                inputElement.Clear();
                inputElement.SendKeys(plateId);
                IWebElement submitButton = driver.FindElement(By.Id("knap"));
                submitButton.Click();

                System.Threading.Thread.Sleep(1000);
                var tdElements = driver.FindElements(By.TagName("td"));

                List<int> row1 = new List<int>();
                List<int> row2 = new List<int>();
                List<int> row3 = new List<int>();

                int counter = 1;
                foreach (var tdElement in tdElements)
                {
                    string text = tdElement.Text;

                    if (int.TryParse(text, out int number))
                    {
                        if (int.TryParse(text, out int number))
                        {
                            if (counter <= 5)
                            {
                                row1.Add(number);
                            }
                            else if (counter <= 10)
                            { row2.Add(number); }
                            else
                            { row3.Add(number); }
                            counter++;
                        }
                    }
                    Data data = new Data
                    {
                        Id = plateId,
                        Row1 = row1,
                        Row2 = row2,
                        Row3 = row3
                    };




                    driver.Quit();



                }

            }
        }
            public class Data
        {
            public string Id { get; set; }
            public List<int> Row1 { get; set; }
            public List<int> Row2 { get; set; }
            public List<int> Row3 { get; set; }
        }
    }
}