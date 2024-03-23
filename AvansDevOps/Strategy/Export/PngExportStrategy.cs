namespace AvansDevOps.Strategy.Export
{
    public class PngExportStrategy : IExportStrategy
    {
        public void Export(Report report)
        {
            Console.WriteLine("Report has now been exported in PNG format.");

        }
    }
}