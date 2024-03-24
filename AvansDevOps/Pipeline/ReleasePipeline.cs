using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class ReleasePipeline : PipelineTemplate
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
            Finish();
        }
    }
}
