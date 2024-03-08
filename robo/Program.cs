using HtmlAgilityPack;
class Program
{
    static async Task main()
    {
        string mercadoLivreSite = "https://lista.mercadolivre.com.br/notebook#D[A:notebook]";
        string magazineLuizaSite = "https://www.magazineluiza.com.br/busca/notebook/";

        string nomeProdutoMercadoLivre = "";
        string precoProdutoMercadoLivre = "";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(mercadoLivreSite);
            if (response.IsSuccessStatusCode)
            {
                string html = await response.Content.ReadAsStringAsync();

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);

                HtmlNode nomeNode = document.DocumentNode.SelectSingleNode("//*[@id=\":ra:\"]/div[2]/div[1]/div[2]/a");
                nomeProdutoMercadoLivre = nomeNode.InnerText.Trim();

                HtmlNode precoNode = document.DocumentNode.SelectSingleNode("//*[@id=\":ra:\"]/div[2]/div[1]/div[3]/div/div/div");
                precoProdutoMercadoLivre = precoNode.InnerText.Trim();
            }

            else
            {
                Console.WriteLine("Falha ao fazer a requisição");
            }
            Console.WriteLine(nomeProdutoMercadoLivre);
            Console.WriteLine(precoProdutoMercadoLivre);
        }
    }
}