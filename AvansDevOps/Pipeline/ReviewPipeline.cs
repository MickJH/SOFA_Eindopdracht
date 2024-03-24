using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class ReviewPipeline : PipelineTemplate
    {
        public override void RunPipeline()
        {
            FetchSource();
            InstallPackages();
            Build();
            Test();
            Analyze();
            Deploy();
            ExecuteUtilities();
            // Add this method
            AddReviewSummary();
            Finish();
        }

        private void AddReviewSummary()
        {
            Console.WriteLine("Uploading summary of review...");
        }
    }
}
