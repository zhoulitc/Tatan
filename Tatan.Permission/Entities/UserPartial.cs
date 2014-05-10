﻿namespace Tatan.Permission.Entities
{
    using Collections;
    using UserExtension;

    /// <summary>
    /// 用户，用户的权限为自身权限和关联角色、关联组权限的集合
    /// </summary>
    public partial class User
    {
        private GroupRelationCollection _groups;
        private RoleRelationCollection _roles;
        private PermissionRelationCollection _permissions;

        /// <summary>
        /// 用户登录信息
        /// </summary>
        public UserLoginInfo Login { get; set; }

        /// <summary>
        /// 用户联系信息
        /// </summary>
        public UserContactInfo Contact { get; set; }

        /// <summary>
        /// 用户包含的组关联集合
        /// </summary>
        public GroupRelationCollection Groups
        {
            get { return _groups ?? (_groups = new GroupRelationCollection(this, "UserId", "UserGroup")); }
        }

        /// <summary>
        /// 用户包含的角色关联集合
        /// </summary>
        public RoleRelationCollection Roles
        {
            get { return _roles ?? (_roles = new RoleRelationCollection(this, "UserId", "UserRole")); }
        }

        /// <summary>
        /// 用户包含的权限关联集合
        /// </summary>
        public PermissionRelationCollection Permissions
        {
            get { return _permissions ?? (_permissions = new PermissionRelationCollection(this, "UserId", "UserPermission")); }
        }
    }
}