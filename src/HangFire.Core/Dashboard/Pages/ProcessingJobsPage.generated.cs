﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 2 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class ProcessingJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");







            
            #line 7 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
  
    Layout = new LayoutPage { Title = "Processing Jobs" };

    int from, perPage;

    int.TryParse(Request.Query["from"], out from);
    int.TryParse(Request.Query["count"], out perPage);

    var monitor = JobStorage.Current.GetMonitoringApi();
    Pager pager = new Pager(from, perPage, monitor.ProcessingCount())
    {
        BasePageUrl = Request.LinkTo("/processing")
    };

    JobList<ProcessingJobDto> processingJobs = monitor
        .ProcessingJobs(pager.FromRecord, pager.RecordsPerPage);


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 25 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-info\">\r\n        No jobs are being processed right now" +
".\r\n    </div>\r\n");


            
            #line 30 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"js-jobs-list\">\r\n        <div class=\"btn-toolbar btn-toolbar-top\">" +
"\r\n            <button class=\"js-jobs-list-command btn btn-sm btn-primary\"\r\n     " +
"               data-url=\"");


            
            #line 36 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                         Write(Request.LinkTo("/processing/requeue"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Enqueueing..."">
                <span class=""glyphicon glyphicon-repeat""></span>
                Requeue jobs
            </button>

            <button class=""js-jobs-list-command btn btn-sm btn-default""
                    data-url=""");


            
            #line 43 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                         Write(Request.LinkTo("/processing/delete"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                    data-loading-text=""Deleting...""
                    data-confirm=""Do you really want to DELETE ALL selected jobs?"">
                <span class=""glyphicon glyphicon-remove""></span>
                Delete selected
            </button>

            ");


            
            #line 50 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
       Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
WriteLiteral(@"
        </div>

        <table class=""table"">
            <thead>
                <tr>
                    <th class=""min-width"">
                        <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                    </th>
                    <th class=""min-width"">Id</th>
                    <th class=""min-width"">Server</th>
                    <th>Job</th>
                    <th class=""align-right"">Started</th>
                </tr>
            </thead>
            <tbody>
");


            
            #line 66 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                 foreach (var job in processingJobs)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr class=\"js-jobs-list-row ");


            
            #line 68 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                                            Write(!job.Value.InProcessingState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 68 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                                                                                                     Write(job.Value.InProcessingState ? "hover" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <td>\r\n");


            
            #line 70 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                             if (job.Value.InProcessingState)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <input type=\"checkbox\" class=\"js-jobs-list-checkb" +
"ox\" name=\"jobs[]\" value=\"");


            
            #line 72 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                                                                                                     Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n");


            
            #line 73 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td class=\"min-width\">\r\n  " +
"                          <a href=\"");


            
            #line 76 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                                Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 77 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                           Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n");


            
            #line 79 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                             if (!job.Value.InProcessingState)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span title=\"Job\'s state has been changed while f" +
"etching data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 82 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td class=\"min-width\">\r\n  " +
"                          ");


            
            #line 85 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                       Write(job.Value.ServerId.ToUpperInvariant());

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                  " +
"          <a class=\"job-method\" href=\"");


            
            #line 88 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                                                   Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 89 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                           Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n                        </td>\r\n              " +
"          <td class=\"align-right\">\r\n");


            
            #line 93 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                             if (job.Value.StartedAt.HasValue)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <span data-moment=\"");


            
            #line 95 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                                              Write(JobHelper.ToTimestamp(job.Value.StartedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                    ");


            
            #line 96 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                               Write(job.Value.StartedAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </span>\r\n");


            
            #line 98 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                    </tr>\r\n");


            
            #line 101 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");


            
            #line 105 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 105 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 105 "..\..\Dashboard\Pages\ProcessingJobsPage.cshtml"
                                        
}

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
