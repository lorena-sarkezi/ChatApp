CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [chat_app].[AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [chat_app].[AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [chat_app].[AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [chat_app].[AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [chat_app].[AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [chat_app].[AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [chat_app].[AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_DeviceCodes_DeviceCode] ON [chat_app].[DeviceCodes] ([DeviceCode]);

GO

CREATE INDEX [IX_DeviceCodes_Expiration] ON [chat_app].[DeviceCodes] ([Expiration]);

GO

CREATE INDEX [IX_PersistedGrants_Expiration] ON [chat_app].[PersistedGrants] ([Expiration]);

GO

CREATE INDEX [IX_PersistedGrants_SubjectId_ClientId_Type] ON [chat_app].[PersistedGrants] ([SubjectId], [ClientId], [Type]);

GO