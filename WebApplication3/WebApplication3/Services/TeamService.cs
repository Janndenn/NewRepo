using TeamApi.Models;

namespace TeamApi.Services
{
    public class TeamService
    {
        public List<TeamMember> GetTeamMembers()
        {
            return new List<TeamMember>
            {
                new TeamMember { Name = "chan", Gender = "Male", Age = 30, Address = "123", Email = "chan@example.com" },
                new TeamMember { Name = "Jane", Gender = "Female", Age = 28, Address = "456", Email = "jane@example.com" }
            };
        }
    }
}

