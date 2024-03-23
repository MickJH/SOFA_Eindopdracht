using AvansDevOps.Strategy.Export;

namespace AvansDevOps.Strategy
{
    public class ReportExporter
    {
        private IExportStrategy _exportStrategy;

        public ReportExporter(IExportStrategy exportStrategy)
        {
            _exportStrategy = exportStrategy;
        }

        public void SetExportStrategy(IExportStrategy exportStrategy)
        {
            _exportStrategy = exportStrategy;
        }

        public void ExportReport(Report report)
        {
            _exportStrategy.Export(report);
        }
    }
}


