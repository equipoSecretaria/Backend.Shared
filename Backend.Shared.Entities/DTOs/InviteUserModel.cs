using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Shared.Entities.DTOs
{
    public class InviteUserModel
    {

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [JsonIgnore]
        public bool SendInviteMessage { get; set; }
        [JsonIgnore]
        public string Status { get; set; }
        [JsonIgnore]
        public string InvitedUser { get; set; }
    }
}
