using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlDataApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };

            //Load trang web, nạp html vào document
            HtmlDocument document = htmlWeb.Load("https://www.thegioididong.com/dtdd");

            //Load các tag li trong tag ul
            var threadItems = document.DocumentNode.SelectNodes("//ul[@class='homeproduct  ']/li");

            var items = new List<object>();

            foreach (var item in threadItems.ToList())
            {
                //Extract các giá trị từ các tag con của tag li
                var linkNode = item.SelectSingleNode(".//a[contains(@href,'dtdd')]");
                var link = "thegioididong.com"+linkNode.Attributes["href"].Value;
                var text = linkNode.SelectSingleNode(".//h3").InnerText;
                var price = linkNode.SelectSingleNode(".//div[@class='price']/strong").InnerText;
                items.Add(new { text, price, link });
            }
        }
    }
}
