namespace Week2
{
    public class JournalEntry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public JournalEntry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }
    }
}
