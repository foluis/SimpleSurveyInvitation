using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NA.SimpleSurveyInvitation.Web.Models
{
    public class GitHubBranch
    {
        public string Name { get; set; }
        public Commit Commit { get; set; }
        public bool Protected { get; set; }
    }
}
