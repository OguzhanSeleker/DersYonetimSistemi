// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace DYS.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
                {
            new ApiResource("resource_lesson"){Scopes={"lesson_fullpermission"}},
            new ApiResource("resource_message"){Scopes={"message_fullpermission"}},
            new ApiResource("resource_notification"){Scopes={"notification_fullpermission"}},
            new ApiResource("resource_survey"){ Scopes={ "survey_fullpermission"} },
            new ApiResource("resource_gateway"){Scopes={"gateway_fullpermission"}},
            new ApiResource("resource_fileSystem"){Scopes={"fileSystem_fullpermission"}},
            new ApiResource("resource_attendance"){Scopes={"attendance_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
                };

        public static IEnumerable<IdentityResource> IdentityResources =>
                new IdentityResource[]
                {
                    new IdentityResources.Email(),
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),                    
                    new IdentityResource(){Name = "Roles",DisplayName="Roles",Description="Kullanıcı rolleri",UserClaims= new []{ "role"} }
                };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("lesson_fullpermission","Lesson API için full erişim"),
                new ApiScope("message_fullpermission","Message API için full erişim"),
                new ApiScope("notification_fullpermission","Notification API için full erişim"),
                new ApiScope("survey_fullpermission","Survey API için full erişim"),
                new ApiScope("gateway_fullpermission","Gateway API için full erişim"),
                new ApiScope("fileSystem_fullpermission","Dosya Yönetim API için full erişim"),
                new ApiScope("attendance_fullpermission","Yoklama API için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),

            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                 new Client
                {
                    ClientName="DYS Web Client",
                    ClientId = "WebMvcClientForUser",
                    AllowOfflineAccess = true,
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ "lesson_fullpermission", "attendance_fullpermission", "fileSystem_fullpermission", "message_fullpermission", "notification_fullpermission", "survey_fullpermission","gateway_fullpermission",IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess,"Roles", IdentityServerConstants.LocalApi.ScopeName},
                    AccessTokenLifetime = 1*60*60, // 1 saat
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse
                    
                }
            };
    }
}