using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

public class Crawler
{
    // HttpClient используется для выполнения HTTP-запросов
    private static readonly HttpClient client = new HttpClient();

    public static async Task Main(string[] args)
    {
        // URL для начала краулинга
        string url = "https://ru.wikipedia.org/";

        // Запуск асинхронного метода краулинга
        await CrawlAsync(1, url, new HashSet<string>());
    }

    // Асинхронный метод для краулинга веб-страниц
    private static async Task CrawlAsync(int level, string url, HashSet<string> visited)
    {
        // Проверка уровня глубины и уникальности URL
        if (level <= 5 && !visited.Contains(url))
        {
            // Запрос документа HTML
            var doc = await RequestAsync(url, visited);
            if (doc != null)
            {
                // Поиск всех ссылок на странице
                foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    // Извлечение абсолютного URL
                    string nextLink = link.GetAttributeValue("href", string.Empty);
                    if (!string.IsNullOrEmpty(nextLink) && !visited.Contains(nextLink))
                    {
                        // Рекурсивный вызов метода для следующего уровня
                        await CrawlAsync(level + 1, nextLink, visited);
                    }
                }
            }
        }
    }

    // Асинхронный метод для выполнения HTTP-запроса и получения HTML-документа
    private static async Task<HtmlDocument> RequestAsync(string url, HashSet<string> visited)
    {
        try
        {
            // Выполнение HTTP-запроса
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // Чтение содержимого страницы
                var pageContents = await response.Content.ReadAsStringAsync();

                // Создание и загрузка HTML-документа
                var doc = new HtmlDocument();
                doc.LoadHtml(pageContents);

                // Вывод информации о ссылке и заголовке страницы
                Console.WriteLine("Link: " + url);
                Console.WriteLine(doc.DocumentNode.SelectSingleNode("//title").InnerText);

                // Добавление URL в список посещенных
                visited.Add(url);

                return doc;
            }
            return null;
        }
        catch (Exception ex)
        {
            // Обработка ошибок
            Console.WriteLine("Error: " + ex.Message);
            return null;
        }
    }
}
