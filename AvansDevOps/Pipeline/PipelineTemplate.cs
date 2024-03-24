using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public abstract class PipelineTemplate
    {
        public void FetchSource()
        {
            Console.WriteLine("Fetching source...");
        }

        public void InstallPackages()
        {
            Console.WriteLine("Installing packages...");
        }

        public void Build()
        {
            Console.WriteLine("Building...");
        }

        public void Test()
        {
            Console.WriteLine("Testing...");
        }

        public void Analyze()
        {
            Console.WriteLine("Analyzing...");
        }

        public void Deploy()
        {
            Console.WriteLine("Deploying...");
        }

        public void ExecuteUtilities()
        {
            Console.WriteLine("Executing utilities...");
        }

        public void Finish()
        {
            Console.WriteLine("Finishing...");
            Console.WriteLine("Pipeline completed without complications");
        }

        public abstract void RunPipeline();
    }
}
