using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ResumeParserService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserService.Context
{
    public class AppDBContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<ResumeStatus> ResumeStatuses { get; set; }
        public DbSet<ResumeSave> ResumeSaves { get; set; }
        public DbSet<CandidateDetail> CandidateDetails { get; set; }
        public DbSet<CandidateResumeTracker> CandidateResumeTrackers { get; set; }
    }
}
