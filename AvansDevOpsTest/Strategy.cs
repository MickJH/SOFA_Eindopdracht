using Xunit;
using NSubstitute;
using AvansDevOps.Strategy.Export;
using AvansDevOps.Strategy;

namespace AvansDevOpsTest
{
    public class ReportExporterTests
    {
        [Fact]
        public void ExportReport_UsesPdfExportStrategy()
        {
            // Arrange
            var mockPdfExportStrategy = Substitute.For<IExportStrategy>();
            var reportExporter = new ReportExporter(mockPdfExportStrategy);
            var report = new Report("Test Report");

            // Act
            reportExporter.ExportReport(report);

            // Assert
            Assert.Same(mockPdfExportStrategy, reportExporter.GetExportStrategy());
        }

        [Fact]
        public void SetExportStrategy_ChangesExportStrategy()
        {
            // Arrange
            var mockPngExportStrategy = Substitute.For<IExportStrategy>();
            var reportExporter = new ReportExporter(mockPngExportStrategy);
            var report = new Report("Test Report");
            var newStrategy = new PngExportStrategy();

            // Act
            reportExporter.SetExportStrategy(newStrategy);
            reportExporter.ExportReport(report);

            // Assert
            Assert.Same(newStrategy, reportExporter.GetExportStrategy());
        }

        [Fact]
        public void ExportReport_UsesPngExportStrategyAfterChange()
        {
            // Arrange
            var mockPngExportStrategy = Substitute.For<IExportStrategy>();
            var reportExporter = new ReportExporter(mockPngExportStrategy);
            var report = new Report("Test Report");
            var newStrategy = new PngExportStrategy();

            // Act
            reportExporter.SetExportStrategy(newStrategy);
            reportExporter.ExportReport(report);

            // Assert
            mockPngExportStrategy.Received(0).Export(report);
        }
    }
}
