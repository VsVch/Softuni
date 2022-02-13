using Git.Data.Models;
using System;
using System.Collections.Generic;

namespace Git.Controllers
{
    public class AllReposotoriesModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        public string Owner { get; set; }

        public int CommitsCount { get; set; }

    }
}