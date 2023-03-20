// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Duende.IdentityServer.Test;
using IdentityModel;
using System.Security.Claims;

namespace Marvin.IDP.Pages;

public class TestUsers
{
  public static List<TestUser> Users
  {
    get
    {
      var address = new
      {
        street_address = "One Hacker Way",
        locality = "Heidelberg",
        postal_code = 69118,
        country = "Germany"
      };

      return new List<TestUser>
        {
          new TestUser
          {
            SubjectId = "1",
            Username = "David",
            Password = "password",
            Claims =
            {
              new Claim("role", "FreeUser"),
              new Claim(JwtClaimTypes.GivenName, "David"),
              new Claim(JwtClaimTypes.FamilyName, "Flagg"),
            }
},
        new TestUser
        {
            SubjectId = "2",
            Username = "Emma",
            Password = "password",
            Claims =
            {
              new Claim("role", "PayingUser"),
              new Claim(JwtClaimTypes.GivenName, "Emma"),
              new Claim(JwtClaimTypes.FamilyName, "Flagg"),
            }
          }
      };
    }
  }
}