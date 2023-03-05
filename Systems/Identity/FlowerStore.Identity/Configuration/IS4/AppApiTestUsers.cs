using Duende.IdentityServer.Test;

namespace FlowerStore.Identity.Configuration.IS4;

public static class AppApiTestUsers
{
    public static List<TestUser> ApiUsers => new List<TestUser> 
    {
        new TestUser
        {
            SubjectId = "1",
            Username = "test1@test.com",
            Password = "password",
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "test2@test.com",
            Password = "password",
        }
    };
}
