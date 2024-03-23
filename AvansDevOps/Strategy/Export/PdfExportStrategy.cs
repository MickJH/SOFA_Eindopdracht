namespace AvansDevOps.Strategy.Export
{
    public class PdfExportStrategy : IExportStrategy
    {
        public void Export(Report report)
        {
            Console.WriteLine("Report has now been exported in PDF format.");
        }
    }
}