using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarterTemplate.Models
{
    public class BaseGuidModel
    {
        [Key, Column("Id")]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset DeletedAt { get; set; }
        public Boolean Deleted { get; set; } = false;
    }
}
