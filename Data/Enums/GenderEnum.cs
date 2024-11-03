using System.Runtime.Serialization;

namespace API.Data.Enums
{
    public enum GenderEnum
    {
        [EnumMember(Value = "Male")]
        Male = 0,
        [EnumMember(Value = "Female")]
        Female = 1
    }
}
