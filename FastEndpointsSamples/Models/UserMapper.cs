using FastEndpoints;

namespace FastEndpointsSamples.Models
{
    public class UserMapper : Mapper<UserRequest, UserResponse, User>
    {
        public override User ToEntity(UserRequest request)
        {
            return new User()
            {
                Id = request.UserId,
                FullName = $"{request.FirstName} {request.LastName}",
                Age = request.Age
            };
        }

        public override UserResponse FromEntity(User user)
        {
            return new UserResponse()
            {
                FullName = user.FullName,
                IsOver18 = user.Age >= 18
            };
        }
    }
}
