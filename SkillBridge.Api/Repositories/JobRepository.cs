using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkillBridge.Api.Entities;

public class JobRepository : IJobRepository
{
    private readonly SkillBridgeDbContext _context;

    public JobRepository(SkillBridgeDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<JobDto>> GetJobListAsync()
    {
        var jobList = await _context.Jobs.ToListAsync();
        if(jobList != null)
        {
            return jobList.Select(job => new JobDto
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Company = job.Company,
                Location = job.Location,
                JobType = job.JobType,
                MaximumSalary = job.MaximumSalary,
                MinimumSalary = job.MinimumSalary,
                PostedDate = job.PostedDate,
                DeadLineDate = job.DeadLineDate,
                IsActive = job.IsActive

            }).ToList();
        }
        return new List<JobDto>();
        // {
        //     new JobDto { Id = 1, Title = "Software Engineer", Description = " Develop and maintain software applications"},
        //     new JobDto { Id = 2, Title = " Product Manager", Description = " Manage product development and strategy"}
        // };
        
    }
    public async Task<JobDto> GetJobByIdAsync(int id)
    {
        var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);
        if(job != null)
        {
            return new JobDto
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Company = job.Company,
                Location = job.Location,
                JobType = job.JobType,
                MaximumSalary = job.MaximumSalary,
                MinimumSalary = job.MinimumSalary,
                PostedDate = job.PostedDate,
                DeadLineDate = job.DeadLineDate,
                IsActive = job.IsActive
            };
        }
        return new JobDto();
    }
}