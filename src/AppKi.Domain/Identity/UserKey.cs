using System.ComponentModel.DataAnnotations;

namespace AppKi.Domain.Identity;

public class UserKey : BaseEntity<int>
{
    [MaxLength(512)] public string ApiName { get; set; }
    [MaxLength(512)] public string ApiKey { get; set; }
    [MaxLength(512)] public string ApiSecret { get; set; }
    public int Exchange { get; set; }

    public int UserId { get; set; }
    public AppKiUser User { get; set; }
}